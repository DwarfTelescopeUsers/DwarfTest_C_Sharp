using System.Diagnostics;
using System.Net.WebSockets;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using static ClientTest.ApiCaller;

namespace ClientTest
{
    internal class ApiCaller
    {
        public enum CameraId
        {
            Telephoto = 0,
            WideAngle = 1
        }

        public enum ShotMode
        {
            Single = 0,
            Continuous = 1
        }

        private const int autofocusGlobal = 0;
        private const int autofocusArea = 1;

        private const int IRCut = 0;
        private const int IRPass = 3;

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
        private const int binning1x1 = 0;
        private const int binning2x2 = 1;
        private const int fileFits = 0;
        private const int fileTiff = 1;

        // raw preview
        private const int rawPreviewContinousSuperimpose = 0;
        private const int rawPreviewSingle15 = 1;
        private const int rawPreviewSingleComposite = 2;


        // "wss://localhost:7122/ws"
        private static readonly string uri = "ws://192.168.1.162:9900";

        private static readonly JsonSerializerOptions jsoptions = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        // ===============
        // 3.1 image transmission
        // ===============
        public static async Task TurnOnCamera(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.TurnOnCameraCmd,
                CamId = (int)cameraId,
                Binning = 0
            };

            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task TurnOffCamera(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.TurnOffCameraCmd,
                CamId = (int)cameraId
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task SetPreviewImageQuality(CameraId cameraId, ShotMode shotMode)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetPreviewImageQualityCmd,
                CamId = (int)cameraId,
                Mode = (int)shotMode
            };
            D2Message? response = await SendMessage(d2Message);
        }

        // ===============
        // 3.2 photo and video
        // ===============
        //TODO: write these mwthods

        public static async Task TakePhoto(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.TakePhotoCmd,
                CamId = (int)cameraId,
                Mode = 0,
                Count = 1,
                Name = $"DwarfTest-Photo-{DateTime.Now}"
            };

            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task StartRecording(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.StartRecordingCmd,
                CamId = (int)cameraId,
                Name = $"DwarfTest-Video-{DateTime.Now}"
            };

            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task StopRecording(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.StopRecordingCmd,
                CamId = (int)cameraId
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task StartTimeLapsePhotography(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.StartTimeLapsePhotographyCmd,
                CamId = (int)cameraId,
                Interval = 1,
                OutTime = 1,
                Name = $"DwarfTest-TimeLapse-{DateTime.Now}"
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task StopTimeLapsePhotography(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.StopTimeLapsePhotographyCmd,
                CamId = (int)cameraId
            };
            D2Message? response = await SendMessage(d2Message);
        }

        // ===============
        // 3.3 Adjust ISP parameters
        // ===============

        public static async Task SetBrightnessValue(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetBrightnessValueCmd,
                CamId = (int)cameraId,
                Value = 50
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task SetContrastValue(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetContrastValueCmd,
                CamId = (int)cameraId,
                Value = 50
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task SetSaturationValue(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetSaturationValueCmd,
                CamId = (int)cameraId,
                Value = 50
            };
            D2Message? response = await SendMessage(d2Message);
        }
        public static async Task SetHueValue(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetHueValueCmd,
                CamId = (int)cameraId,
                Value = 50
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task SetSharpnessValue(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetSharpnessValueCmd,
                CamId = (int)cameraId,
                Value = 50
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task SetExposureMode(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetExposureModeCmd,
                CamId = (int)cameraId,
                Mode = 0
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task SetExposureValue(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetExposureValueCmd,
                CamId = (int)cameraId,
                Value = 50
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task SetGainMode(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetGainModeCmd,
                CamId = (int)cameraId,
                Mode = 0
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task SetGainValue(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetGainValueCmd,
                CamId = (int)cameraId,
                Value = 50
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task StartAutoFocus(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.StartAutofocusCmd,
                CamId = (int)cameraId,
                Mode = 0,
                CenterX = 0,
                CenterY = 0
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task SetWhiteBalanceMode(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetWhiteBalanceModeCmd,
                CamId = (int)cameraId,
                Mode = 0
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task SetWhiteBalanceScene(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetWhiteBalanceSceneCmd,
                CamId = (int)cameraId,
                Mode = 0
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task SetWhiteBalanceColor(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetWhiteBalanceColorTemperatureCmd,
                CamId = (int)cameraId,
                Value = 50
            };
            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task SetIRCut(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetIRCutCmd,
                CamId = (int)cameraId,
                Value = 50
            };
            D2Message? response = await SendMessage(d2Message);
        }

        // ===============
        // 3.4 Gets DWARF running status and parameters
        // ===============
        public static async Task GetTelephotoIspParameters(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.GetTelephotoIspParametersCmd,
                CamId = (int)cameraId
            };
            await SendMessage(d2Message);
        }

        public static async Task GetTelephotoIrCutState(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.GetTelephotoIrCutStateCmd,
                CamId = (int)cameraId,
                Value = 50
            };
            await SendMessage(d2Message);
        }

        public static async Task GetTelephotoWorkingState(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.GetTelephotoIspParametersCmd,
                CamId = (int)cameraId
            };
            await SendMessage(d2Message);
        }

        public static async Task GetWideangleIspParameter(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.GetWideangleIspParameterCmd,
                CamId = (int)cameraId,
                Value = 50
            };
            await SendMessage(d2Message);
        }


        // 4. Advanced function API
        // Before using the astronomy function, you must set the UTC+0 time
        // HTTP reques: http://192.168.88.1:8092/date?date=yyyy-mm-dd hh:mm:ss
        // ===============
        // 4.1 Astronomical function
        // ===============
        public static async Task Correction(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.CorrectionCmd,
                CamId = (int)cameraId,
                Value = 50
            };
            await SendMessage(d2Message);
        }

        public static async Task StartGoto(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.StartGotoCmd,
                CamId = (int)cameraId,
                Value = 50
            };
            await SendMessage(d2Message);
        }

        public static async Task TakeRawPictures()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.TakeRawPicturesCmd,
                CamId = 0, // Long focal camera
                Target = "target",
                RA = "09h45m51.10s",
                DEC = "+23°46'27.0",
                Exp = 50,
                Gain = 75,
                Binning = 0,
                Count = 1,
                Name = "name",
                OverlayCount = 1,
                Format = 0
            };
            await SendMessage(d2Message);
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
        public static async Task StopTakingRawImages()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.StopTakingRawImagesCmd
            };
            await SendMessage(d2Message);
        }
        /*
         * 4.1.8 RAW image preview
RAW image preview interface for jpeg video stream, need the receiver to parse the jpeg video stream and display, you can use a browser to test the interface.
RAW image preview：
         * http://192.168.88.1:8092/rawstream
         */

        public static async Task SwitchRawPreviewSource(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.StartGotoCmd,
                CamId = (int)cameraId,
                Source = 0
            };
            await SendMessage(d2Message);
        }

        public static async Task TakeAstroDarkFrames(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.TakeAstroDarkFramesCmd,
                CamId = (int)cameraId,
                Count = 40,
                Name = "name",
                Binning = 0,
                DarkGain = 3,
                DarkExp = 0
            };
            await SendMessage(d2Message);
        }

        public static async Task QueryShotField(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.QueryShotFieldCmd,
                CamId = (int)cameraId,
                Binning = 0
            };
            await SendMessage(d2Message);
        }
        // ===============
        // 4.2 tracking
        // ===============
        public static async Task TraceInitializationCmd(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetIRCutCmd
            };
            await SendMessage(d2Message);
        }

        public static async Task StartTracking(CameraId cameraId)
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
            await SendMessage(d2Message);
        }

        public static async Task StopTracking(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.StopTrackingCmd,
                CamId = (int)cameraId
            };
            await SendMessage(d2Message);
        }
        // ===============
        // 4.3 panoromic
        // ===============
        public static async Task StartPanorama(CameraId cameraId)
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
            await SendMessage(d2Message);
        }

        public static async Task StopPanorama()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.StopPanoramaCmd
            };
            await SendMessage(d2Message);
        }
        // ===============
        // 5 motion control
        // ===============
        public static async Task StartMotion()
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
        }

        public static async Task StopMotion()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.StopMotionCmd,
                Id = 1,
                DecelStep = 20
            };
            await SendMessage(d2Message);
        }

        public static async Task SetSpeed()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetSpeedCmd,
                Id= 1,
                Speed = 1000,
                AccelStep= 20,
                Trend = 0
            };
            await SendMessage(d2Message);
        }

        public static async Task SetDirection()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetDirectionCmd,
                Id = 1,
                Direction = 0
            };
            await SendMessage(d2Message);
        }

        public static async Task SetSubdivide(CameraId cameraId)
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SetSubdivideCmd,
                Id = 1,
                MStep = 1
            };
            await SendMessage(d2Message);
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
        public static async Task SystemStatus()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.SystemStatusCmd
            };
            await SendMessage(d2Message);
        }
        // ===============
        // 7.2 microsd card status
        // ===============
        public static async Task MicrosdStatus()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.MicrosdStatusCmd
            };
            await SendMessage(d2Message);
        }

        public static async Task CheckMicroSD()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.CheckMicroSDCmd
            };
            await SendMessage(d2Message);
        }

        public static async Task GetDwarfSoftwareVersionNumberCmd()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.GetDwarfSoftwareVersionNumberCmd
            };
            await SendMessage(d2Message);
        }

        public static async Task ChargingStatus()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.ChargingStatusCmd
            };
            await SendMessage(d2Message);
        }

        public static async Task MTPMode()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.MTPModeCmd
            };
            await SendMessage(d2Message);
        }

        public static async Task OTAUpgrade()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.OTAUpgradeCmd
            };
            await SendMessage(d2Message);
        }

        public static async Task PowerAcquisition()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.PowerAcquisitionCmd
            };
            await SendMessage(d2Message);
        }

        public static async Task ShutDown()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.ShutDownCmd
            };
            await SendMessage(d2Message);
        }

        public static async Task RGBControl()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.RGBControlCmd
            };
            await SendMessage(d2Message);
        }

        public static async Task TurnOffRGB()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.TurnOffRGBCmd
            };
            await SendMessage(d2Message);
        }

        public static async Task TurnOnPowerIndicator()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.TurnOnPowerIndicatorCmd
            };
            await SendMessage(d2Message);
        }

        public static async Task TurnOffPowerIndicator()
        {
            D2Message d2Message = new()
            {
                Interface = CommandOpcodes.TurnOffPowerIndicatorCmd
            };
            await SendMessage(d2Message);
        }

        public static async Task RotateAnticlockwise()
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
        }

        public static async Task StopSpin()
        {
            D2Message d2Message = new()
            {
                Interface = 10101,
                Id = 1,
                DecelStep = 20
            };

            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task RotateClockwise()
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
        }




        public static async Task<D2Message?> SendMessage(D2Message d2Message)
        {
            try
            {
                string sendMessage = JsonSerializer.Serialize(d2Message, jsoptions);
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
