using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
       
        public static void DoCorrection()
        {

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

    }
}
