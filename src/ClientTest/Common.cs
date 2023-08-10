using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static ClientTest.ApiCaller;
using System.CodeDom;
using System.Runtime.InteropServices;
using System.Data.Common;

namespace ClientTest
{
    internal static class Common
    {
        private static readonly string _configFileName = "Config.json";
        public static bool Configured {get; set;} = false;

        public struct ConfigData
        {
            public string? IP { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
        }


        public struct DSOData
        {
            public string Name { get; set; }
            public double RA { get; set; }
            public double Dec { get; set; }
            public string Description { get; set; }
        }

        static Common()
        {
            DSOData dsoList = new DSOData();
        }

        public static (bool,ConfigData) CheckConfig()
        {
            var configData = new ConfigData();
            // Check for and load Config Data
            if (!Configured && File.Exists(_configFileName))
            {
                configData = JsonSerializer.Deserialize<ConfigData>(File.ReadAllText(_configFileName));
                Configured = ((configData.IP != null) && (configData.Longitude != 0.0) && (configData.Latitude != 0.0));
            }

            return (Configured, configData);
        }

        public static double CalculateExposureValue(string expString)
        {
            double value = 0.0;
            // Deal with Integers
            if (!expString.Contains("/"))
            {
                value = Double.Parse(expString);
            }
            else
            { 
                var fraction = expString.Split('/');
                value = (Double)int.Parse(fraction[0]) / int.Parse(fraction[1]);
            }

            return value;
        }
       
        public async static void DoCorrection(ConfigData cnfigData)
        {
            var response = await Correction(CameraId.Telephoto, cnfigData.Longitude,cnfigData.Latitude, DateTime.Now,DateTime.Now);
        }

        public static double ConvertLatitude(string latString)
        {
            double latDouble = 0.0;
            try
            {
                // Check if it is already in decimal format...
                latDouble = Double.Parse(latString);
            }
            catch (FormatException e)
            {
                // ...otherwise try to handle DMS values
                var dms = latString.Split(' ');
                double deg = 0.0;
                double mins = 0.0;
                double secs = 0.0;
                try
                {
                    if (dms.Length <= 3)
                    {
                        deg = Double.Parse(dms[0]);
                        mins = Double.Parse(dms[1]) / 60;
                        secs = Double.Parse(dms[2]) / 3600;
                        if ((Math.Abs(deg) > 89) || (Math.Abs(mins) > 59) || (Math.Abs(secs) > 60))
                        {
                            throw new OverflowException();
                        }
                        latDouble = deg + mins + secs;
                    }
                }
                catch (Exception e2)
                {
                    MessageBox.Show("Unable to translate Latitude String");
                }

            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show("No latitude value entered");
            }
            catch (OverflowException e)
            {
                MessageBox.Show("Invalid latitude value entered");
            }

            return latDouble;
        }

        public static double ConvertLongitude(string lonString)
        {
            double lonDouble = 0.0;
            try
            {
                // Check if it is already in decimal format...
                lonDouble = Double.Parse(lonString);
            }
            catch (FormatException e)
            {
                // ...otherwise try to handle DMS values
                var dms = lonString.Split(' ');
                double deg = 0.0;
                double mins = 0.0;
                double secs = 0.0;
                try
                {
                    if (dms.Length <= 3)
                    {
                        deg = Double.Parse(dms[0]);
                        mins = Double.Parse(dms[1]) / 60;
                        secs = Double.Parse(dms[2]) / 3600;
                        if ((Math.Abs(deg) > 179) || (Math.Abs(mins) > 59) || (Math.Abs(secs) > 60))
                        {
                            throw new OverflowException();
                        }
                        lonDouble = deg + mins + secs;
                    }
                }
                catch (Exception e2)
                {
                    MessageBox.Show("Unable to translate Longitude String");
                }

            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show("No Longitude value entered");
            }
            catch (OverflowException e)
            {
                MessageBox.Show("Invalid Longitude value entered");
            }

            return lonDouble;
        }

        public static void SaveConfig(string lat, string lon, string ip)
        {
            var configData = new ConfigData
            {
                IP = ip,
                Latitude = Double.Parse(lat),
                Longitude = Double.Parse(lon)
            };

            File.WriteAllText(_configFileName, JsonSerializer.Serialize(configData));

        }

        private static double ConvertRA(string RAString)
        {
            double ra = 0.0;
            var raString = RAString.Replace(" ", string.Empty);
            raString = RAString.Replace("h", " ");
            raString = RAString.Replace("m", " ");
            raString = RAString.Replace("s", string.Empty);
            var raComponents = RAString.Split(" ");
            var noComponents = raComponents.Length;
            for (var idx = 0; idx < noComponents; idx++)
            {
                switch (idx)
                {
                    case 0:
                        {
                            ra = Double.Parse(raComponents[idx]);
                            break;
                        }
                    case 1:
                        {
                            ra += Double.Parse(raComponents[idx]) / 60;
                            break;
                        }
                    case 2:
                        {
                            ra += Double.Parse(raComponents[idx]) / 3600;
                            break;
                        }

                }
            }
            return ra;
        }

        private static double ConvertDec(string DecString)
        {
            double dec = 0.0;
            var decString = DecString.Replace(" ", string.Empty);
            decString = DecString.Replace("°", " ");
            decString = DecString.Replace("′", " ");
            decString = DecString.Replace("″", string.Empty);
            var decComponents = DecString.Split(" ");
            var noComponents = decComponents.Length;
            for (var idx = 0; idx < noComponents; idx++)
            {
                switch (idx)
                {
                    case 0:
                        {
                            dec = Double.Parse(decComponents[idx]);
                            break;
                        }
                    case 1:
                        {
                            dec += Double.Parse(decComponents[idx]) / 60;
                            break;
                        }
                    case 2:
                        {
                            dec += Double.Parse(decComponents[idx]) / 3600;
                            break;
                        }

                }
            }
            return dec;
        }

        public static List<DSOData> ReadDSOData(string DSOType)
        {
            List<DSOData> dsoList = new List<DSOData>();
            // Check for and load Config Data
            if (File.Exists($"{DSOType}.csv"))
            {
                var allDSOData = File.ReadAllText($"{DSOType}.csv").Trim().Split(";");
                foreach (var entry in allDSOData)
                {
                    var cmpnts = entry.Split(",");
                    DSOData dso = new DSOData();
                    for (var idx = 0; idx < cmpnts.Length; idx++)
                    {
                        switch (idx)
                        {
                            case 0:
                                {
                                    dso.Name = cmpnts[idx].Trim();
                                    break;
                                }
                            case 1:
                                {
                                    dso.RA = Double.Parse(cmpnts[idx]);
                                    break;
                                }
                            case 2:
                                {
                                    dso.Dec = Double.Parse(cmpnts[idx]);
                                    break;
                                }
                            case 3:
                                {
                                    dso.Description = cmpnts[idx];
                                    break;
                                }
                        }
                    }

                    dsoList.Add(dso);
                }
            }

            return dsoList;

        }

    }
}
