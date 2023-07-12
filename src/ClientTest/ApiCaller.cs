﻿using System.Diagnostics;
using System.Net.WebSockets;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

// https://hj433clxpv.feishu.cn/docx/MiRidJmKOobM2SxZRVGcPCVknQg
namespace ClientTest
{
    internal class ApiCaller
    {
        public enum CameraId
        {
            Telephoto = 0,
            WideAngle = 1
        }
        public enum MotorId
        {
            Spin = 1,
            Pitch = 2
        }
        public enum ShotMode
        {
            Single = 0,
            Continuous = 1
        }

        public enum Binning
        {
            Binning1x1 = 0,
            Binning2x2 = 1
        }

        public enum AutoManual
        {
            Auto = 0,
            Manual = 1
        }

        public enum FocusMode
        {
            GlobalFocus = 0,
            AreaFocus = 1
        }

        public enum WhiteBalanceScene
        {
            IncandescentLamp = 0,
            FluorescentLamp = 1,
            WarmFluorescentLamp = 2,
            Sunlight = 3,
            OvercastSky = 4,
            EveningTwilight = 5,
            Shadow = 6
        }

        public enum MotorDirection
        {
            ACW_Up = 0,
            CW_Down = 1
        }

        public enum IRCut {
            IRCut = 0,
            IRPass = 3
        }

        // goto
        public enum Planets
        {
            Mercury = 0,
            Venus = 1,
            Mars = 2,
            Jupiter = 3,
            Saturn = 4,
            Uranus = 5,
            Neptune = 6,
            Moon = 7
        }

        // RAW astro photo
        private const int fileFits = 0;
        private const int fileTiff = 1;

        // raw preview
        private const int rawPreviewContinousSuperimpose = 0;
        private const int rawPreviewSingle15 = 1;
        private const int rawPreviewSingleComposite = 2;


        // "wss://localhost:7122/ws"
        // private static readonly string baseUri = "192.168.1.162";
        private static readonly string baseUri = "192.168.1.214";
        private static readonly string uri = $"ws://{baseUri}:9900";
        public static readonly string vlcWAUri = $"http://{baseUri}:8092/thirdstream";
        public static readonly string vlcTPUri = $"http://{baseUri}:8092/mainstream";

        private static readonly JsonSerializerOptions jsoptions = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        // ===============
        // 3.1 image transmission
        // ===============
        public static async Task<D2Message?> TurnOnCamera(CameraId cameraId, Binning binning)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.TurnOnCameraCmd,
                CamId = (int)cameraId,
                Binning = (int)binning
            };

            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> TurnOffCamera(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.TurnOffCameraCmd,
                CamId = (int)cameraId
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> SetPreviewImageQuality(CameraId cameraId, ShotMode shotMode)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetPreviewImageQualityCmd,
                CamId = (int)cameraId,
                Mode = (int)shotMode
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        // ===============
        // 3.2 photo and video
        // ===============
        public static async Task<D2Message?> TakePhoto(CameraId cameraId, ShotMode shotMode, int count)
        {
            if (count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Count must be greater than 0");
            }

            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.TakePhotoCmd,
                CamId = (int)cameraId,
                Mode = (int)shotMode,
                Count = count,
                Name = $"DwarfTest-Photo-{DateTime.Now}"
            };

            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> StartRecording(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.StartRecordingCmd,
                CamId = (int)cameraId,
                Name = $"DwarfTest-Video-{DateTime.Now}"
            };

            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> StopRecording(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.StopRecordingCmd,
                CamId = (int)cameraId
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> StartTimeLapsePhotography(CameraId cameraId, int interval, int outTime)
        {
            if(interval is < 1 or > 60)
            {
                throw new ArgumentOutOfRangeException(nameof(interval), "Interval must be between 1 and 60 seconds");
            }
            if (outTime < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(outTime), "OutTime must be greater than 0 seconds");
            }
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.StartTimeLapsePhotographyCmd,
                CamId = (int)cameraId,
                Interval = interval,
                OutTime = outTime,
                Name = $"DwarfTest-TimeLapse-{DateTime.Now}"
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> StopTimeLapsePhotography(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.StopTimeLapsePhotographyCmd,
                CamId = (int)cameraId
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        // ===============
        // 3.3 Adjust ISP parameters
        // ===============

        public static async Task<D2Message?> SetBrightnessValue(CameraId cameraId, int value)
        {
            if (cameraId == CameraId.Telephoto && value is < 0 or > 255)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Telephoto Value must be between 0 and 255");
            }
            if (cameraId == CameraId.WideAngle && value is < -64 or > 64)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "WideAngle Value must be between -64 and 64");
            }
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetBrightnessValueCmd,
                CamId = (int)cameraId,
                Value = value
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> SetContrastValue(CameraId cameraId, int value)
        {
            if (cameraId == CameraId.Telephoto && value is < 0 or > 255)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Telephoto Value must be between 0 and 255");
            }
            if (cameraId == CameraId.WideAngle && value is < 0 or > 95)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "WideAngle Value must be between 0 and 95");
            }
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetContrastValueCmd,
                CamId = (int)cameraId,
                Value = value
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> SetSaturationValue(CameraId cameraId, int value)
        {
            if (cameraId == CameraId.Telephoto && value is < 0 or > 255)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Telephoto Value must be between 0 and 255");
            }
            if (cameraId == CameraId.WideAngle && value is < 0 or > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "WideAngle Value must be between 0 and 100");
            }
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetSaturationValueCmd,
                CamId = (int)cameraId,
                Value = value
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }
        public static async Task<D2Message?> SetHueValue(CameraId cameraId, int value)
        {
            if (cameraId == CameraId.Telephoto && value is < 0 or > 255)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Telephoto Value must be between 0 and 255");
            }
            if (cameraId == CameraId.WideAngle && value is < -2000 or > 2000)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "WideAngle Value must be between -2000 and 2000");
            }
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetHueValueCmd,
                CamId = (int)cameraId,
                Value = value
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> SetSharpnessValue(CameraId cameraId, int value)
        {
            if (cameraId == CameraId.Telephoto && value is < 0 or > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Telephoto Value must be between 0 and 100");
            }
            if (cameraId == CameraId.WideAngle && value is < 1 or > 7)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "WideAngle Value must be between 1 and 7");
            }
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetSharpnessValueCmd,
                CamId = (int)cameraId,
                Value = value
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> SetExposureMode(CameraId cameraId, AutoManual autoManual)
        {
            int mode = (int)autoManual;
            if(cameraId == CameraId.WideAngle && autoManual == AutoManual.Auto)
            {
                mode = 3;
            }
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetExposureModeCmd,
                CamId = (int)cameraId,
                Mode = mode
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> SetExposureValue(CameraId cameraId, double value)
        {
            if (cameraId == CameraId.Telephoto && value is < 0.00 or > 15.00)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Telephoto Value must be between 0.0000 and 15.0000");
            }
            if (cameraId == CameraId.WideAngle && value is < 0.0003 or > 1.0000)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "WideAngle Value must be between 0.0003 and 1.0000");
            }
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetExposureValueCmd,
                CamId = (int)cameraId,
                ValueDouble = value
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> SetGainMode(CameraId cameraId, AutoManual autoManual)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetGainModeCmd,
                CamId = (int)cameraId,
                Mode = (int)autoManual
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> SetGainValue(CameraId cameraId, int value)
        {
            if (cameraId == CameraId.Telephoto && value is < 0 or > 240)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Telephoto Value must be between 0 and 240");
            }
            if (cameraId == CameraId.WideAngle && value is < 64 or > 8000)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "WideAngle Value must be between 64 and 8000");
            }
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetGainValueCmd,
                CamId = (int)cameraId,
                Value = value
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        /// <summary>
        /// 3.3.10 Start autofocus
        /// </summary>
        /// <param name="cameraId"></param>
        /// <param name="focusMode"></param>
        /// <param name="centerX"></param>
        /// <param name="centerY"></param>
        /// <returns></returns>
        public static async Task<D2Message?> StartAutoFocus(CameraId cameraId, FocusMode focusMode, int centerX, int centerY)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.StartAutofocusCmd,
                CamId = (int)cameraId,
                Mode = (int)focusMode,
                CenterX = centerX,
                CenterY = centerY
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> SetWhiteBalanceMode(CameraId cameraId, AutoManual autoManual)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetWhiteBalanceModeCmd,
                CamId = (int)cameraId,
                Mode = (int)autoManual
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> SetWhiteBalanceScene(CameraId cameraId, WhiteBalanceScene whiteBalanceScene)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetWhiteBalanceSceneCmd,
                CamId = (int)cameraId,
                Mode = (int)whiteBalanceScene
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> SetWhiteBalanceColor(CameraId cameraId, int value)
        {
            if (cameraId == CameraId.Telephoto && value is < 2800 or > 7400)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Telephoto Value must be between 2800 and 7400");
            }
            if (cameraId == CameraId.WideAngle && value is < 2800 or > 6000)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "WideAngle Value must be between 2800 and 6000");
            }
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetWhiteBalanceColorTemperatureCmd,
                CamId = (int)cameraId,
                Value = value
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> SetIRCut(CameraId cameraId, IRCut iRCut)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetIRCutCmd,
                CamId = (int)cameraId,
                Value = (int)iRCut
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        // ===============
        // 3.4 Gets DWARF running status and parameters
        // ===============
        public static async Task<D2Message?> GetTelephotoIspParameters(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.GetTelephotoIspParametersCmd,
                CamId = (int)cameraId
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> GetTelephotoIrCutState(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.GetTelephotoIrCutStateCmd,
                CamId = (int)cameraId
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> GetTelephotoWorkingState(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.GetTelephotoIspParametersCmd,
                CamId = (int)cameraId
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> GetWideangleIspParameter(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.GetWideangleIspParameterCmd,
                CamId = (int)cameraId
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }


        // 4. Advanced function API
        // Before using the astronomy function, you must set the UTC+0 time
        // HTTP reques: http://192.168.88.1:8092/date?date=yyyy-mm-dd hh:mm:ss
        // ===============
        // 4.1 Astronomical function
        // ===============
        public static async Task<D2Message?> Correction(CameraId cameraId, double longitude, double latitude, DateTime date, DateTime path)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.CorrectionCmd,
                CamId = (int)cameraId,
                Lon = longitude,
                Lat = latitude,
                Date = date.ToString("yyyy-MM-dd HH:mm:ss"),
                Path = path.ToString("yyyy-MM-dd HH:mm:ss")
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }
        /*
        Wai-Yin Kwan

        Dwarf Lab said to use J2000, not Jnow,
        for RA/Dec when using goto and astro photos commands.
        */
        public static async Task<D2Message?> StartGoto(CameraId cameraId, Planets planet, double ra, double dec, double lon, double lat, DateTime date, DateTime path)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.StartGotoCmd,
                CamId = (int)cameraId,
                Planet = (int)planet,
                RA = ra,
                DEC = dec,
                Lon = lon,
                Lat = lat,
                Date = date.ToString("yyyy-MM-dd HH:mm:ss"),
                Path = path.ToString("yyyy-MM-dd HH:mm:ss")
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> TakeRawPictures(Binning binning)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.TakeRawPicturesCmd,
                CamId = 0, // Long focal camera
                Target = "target",
                RA = 0, //"09h45m51.10s",
                DEC = 0, //"+23°46'27.0",
                Exp = 50,
                Gain = 75,
                Binning = (int)binning,
                Count = 1,
                Name = "name",
                OverlayCount = 1,
                Format = 0
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        /*
4.1.5 Returns the number of raw images
No request is required; dwarf actively returns.

field	        type    	explain
interface	    int     	value:10014
code	        int     	State code
camId	        int     	0
totalCount	    int	        Total number of RAW images shot
currentCount	int	        Number of RAW images taken

4.1.6  Returns the number of superimposed astronomical RAW images
No request is required; dwarf actively returns.

field	        type	    explain
interface	    int	        value: 10023
code	        int	        State code
camId	        int	        0
stackedCount	int	        Number of RAW images stacked

         */
        public static async Task<D2Message?> StopTakingRawImages()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.StopTakingRawImagesCmd
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }
        /*
         * 4.1.8 RAW image preview
RAW image preview interface for jpeg video stream, need the receiver to parse the jpeg video stream and display, you can use a browser to test the interface.
RAW image preview：
         * http://192.168.88.1:8092/rawstream
         */

        public static async Task<D2Message?> SwitchRawPreviewSource(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.StartGotoCmd,
                CamId = (int)cameraId,
                Source = 0
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> TakeAstroDarkFrames(CameraId cameraId, Binning binning)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.TakeAstroDarkFramesCmd,
                CamId = (int)cameraId,
                Count = 40,
                Name = "name",
                Binning = (int)binning,
                DarkGain = 3,
                DarkExp = 0
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> QueryShotField(CameraId cameraId, Binning binning)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.QueryShotFieldCmd,
                CamId = (int)cameraId,
                Binning = (int)binning
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }
        // ===============
        // 4.2 tracking
        // ===============
        public static async Task<D2Message?> TraceInitializationCmd()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetIRCutCmd
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> StartTracking(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.StartTrackingCmd,
                CamId = (int)cameraId,
                X = 50,
                Y = 50,
                W = 50,
                H = 50
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> StopTracking(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.StopTrackingCmd,
                CamId = (int)cameraId
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }
        // ===============
        // 4.3 panoromic
        // ===============
        public static async Task<D2Message?> StartPanorama(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetIRCutCmd,
                CamId = (int)cameraId
                /*
row
col
mStep1(Motor 1 Subdivision)
mStep2(Motor 2Subdivision)
speed1(Motor 1 speed)
speed2(Motor 2 speed)
pulse1(Motor 1 pulse number)
pulse2(Motor 2 pulse number)
imgPath(Panoramic photo path)
accelStep1(Motor 1 Acceleration steps)
accelStep2(Motor 2 Acceleration steps)                 */

            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> StopPanorama()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.StopPanoramaCmd
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }
        // ===============
        // 5 motion control
        // ===============
        public static async Task<D2Message?> StartMotion()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.StartMotionCmd,
                Id = 1,
                Mode = 1,
                MStep = 1,
                Speed = 1000,
                Direction = 0, // Anti-clockwise
                Pulse = 2,
                AccelStep = 20
            };

            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> StopMotion()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.StopMotionCmd,
                Id = 1,
                DecelStep = 20
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> SetSpeed()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetSpeedCmd,
                Id= 1,
                Speed = 1000,
                AccelStep= 20,
                Trend = 0
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> SetDirection()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetDirectionCmd,
                Id = 1,
                Direction = 0
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> SetSubdivide()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetSubdivideCmd,
                Id = 1,
                MStep = 1
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }
        /*
6. File preview and download API

6.1 File preview
Preview using HTTP file server, interface: http://192.168.88.1:8090/file/ + file name, file called/sdcard directory below picture or video file.
6.2 File download
The file download protocol is ftp or sftp.
ftp login：ftp
password：rockchip
sftp login：root
password: rockchip
Note:
1.ftp only has download permission, no file transfer and delete permission, ftp can only access the sdcard directory
2.sftp can access all directories and has the permission to upload and delete files. Ensure that you select /sdcard as the directory to upload and delete files through sftp.
         */
        public static async Task<D2Message?> SystemStatus()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SystemStatusCmd
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }
        // ===============
        // 7.2 microsd card status
        // ===============
        public static async Task<D2Message?> MicrosdStatus()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.MicrosdStatusCmd
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> CheckMicroSD()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.CheckMicroSDCmd
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> GetDwarfSoftwareVersionNumberCmd()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.GetDwarfSoftwareVersionNumberCmd
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> ChargingStatus()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.ChargingStatusCmd
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> MTPMode()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.MTPModeCmd
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> OTAUpgrade()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.OTAUpgradeCmd
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> PowerAcquisition()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.PowerAcquisitionCmd
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> ShutDown()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.ShutDownCmd
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> RGBControl()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.RGBControlCmd
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> TurnOffRGB()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.TurnOffRGBCmd
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> TurnOnPowerIndicator()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.TurnOnPowerIndicatorCmd
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> TurnOffPowerIndicator()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.TurnOffPowerIndicatorCmd
            };
            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> RotateAnticlockwise()
        {
            D2Message d2Message = new()
            {
                Interface = 10100,
                Id = 1,
                Mode = 1,
                MStep = 1,
                Speed = 1000,
                Direction = 0, // Anti-clockwise
                Pulse = 2,
                AccelStep = 20
            };

            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> StopSpin()
        {
            D2Message d2Message = new()
            {
                Interface = 10101,
                Id = 1,
                DecelStep = 20
            };

            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> RotateClockwise()
        {
            D2Message d2Message = new()
            {
                Interface = 10100,
                Id = 1,
                Mode = 1,
                MStep = 1,
                Speed = 1000,
                Direction = 1, // Clockwise
                Pulse = 2,
                AccelStep = 20
            };

            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> StopSpin(MotorId id)
        {
            D2Message d2Message = new()
            {
                Interface = 10101,
                Id = (int)id,
                DecelStep = 20
            };

            D2Message? response = await SendMessage(d2Message);
            return response;
        }

        public static async Task<D2Message?> RotateMotor(MotorId id, MotorDirection drn)
        {
            D2Message d2Message = new()
            {
                Interface = 10100,
                Id = (int)id, 
                Mode = 1,
                MStep = 1,
                Speed = 500,
                Direction = (int)drn, // 0 = AntiClockwise/Up, 1 = Clockwise/Down
                Pulse = 2,
                AccelStep = 20
            };

            D2Message? response = await SendMessage(d2Message);
            return response;
        }



        public static async Task<D2Message?> SendMessage(D2Message d2Message)
        {
            try
            {
                string sendMessage = JsonSerializer.Serialize(d2Message, jsoptions);
                // Handle cases where value is not an integer
                if (sendMessage.Contains($@"""interface"":{CommandOpcodes.SetExposureValueCmd}"))
                {
                    sendMessage = sendMessage.Replace("valueDouble", "value");
                }
                Debug.WriteLine($"Send message: {sendMessage}");

                using ClientWebSocket webSocket = new();
                await webSocket.ConnectAsync(new Uri(uri), CancellationToken.None);

                byte[] sendBuffer = Encoding.UTF8.GetBytes(sendMessage);
                await webSocket.SendAsync(new ArraySegment<byte>(sendBuffer), WebSocketMessageType.Text, true, CancellationToken.None);

                byte[] receiveBuffer = new byte[1024];
                WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(receiveBuffer), CancellationToken.None);
                string receivedMessage = Encoding.UTF8.GetString(receiveBuffer, 0, result.Count);
                Debug.WriteLine($"Received message: {receivedMessage}");
                var receiveD2Message = JsonSerializer.Deserialize<D2Message>(receivedMessage, jsoptions);
                return receiveD2Message;
            }
            catch (NotSupportedException ex)
            {
                Debug.WriteLine($"NotSupportedException: {ex.Message}\r\n{ex.StackTrace}");
                return null;
            }
            catch (ArgumentException ex)
            {

                Debug.WriteLine($"ArgumentException: {ex.ParamName} : {ex.Message}\r\n{ex.StackTrace}");
                return null;
            }
            catch (WebSocketException ex)
            {
                Debug.WriteLine($"WebSocketException: {ex.WebSocketErrorCode} : {ex.Message}\r\n{ex.StackTrace}");
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}\r\n{ex.StackTrace}");
                return null;
            }
        }
    }
}
