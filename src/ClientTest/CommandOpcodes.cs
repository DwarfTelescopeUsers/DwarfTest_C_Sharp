namespace ClientTest
{
    public static class CommandOpcodes
    {
        // ===============
        // 3.1 image transmission
        // ===============
        public const int TurnOnCameraCmd = 10000;
        public const int TurnOffCameraCmd = 10017;

        // ===============
        // 3.2 photo and video
        // ===============
        public const int TakePhotoCmd = 10006;
        public const int StartRecordingCmd = 10007;
        public const int StopRecordingCmd = 10009;
        public const int StartTimelapseCmd = 10018;
        public const int StopTimelapseCmd = 10019;

        // ===============
        // 3.3 Adjust ISP parameters
        // ===============
        public const int SetBrightnessValueCmd = 10204;
        public const int SetContrastValueCmd = 10205;
        public const int SetSaturationValueCmd = 10206;
        public const int SetHueValueCmd = 10207;
        public const int SetSharpnessValueCmd = 10208;
        public const int SetExposureModeCmd = 10001;
        public const int SetExposureValueCmd = 10003;
        public const int SetGainModeCmd = 10004;
        public const int SetGainValueCmd = 10005;
        public const int StartAutofocusCmd = 10211;
        public const int SetWhiteBalanceModeCmd = 10212;
        public const int SetWhiteBalanceSceneCmd = 10213;
        public const int SetWhiteBalanceColorTemperatureCmd = 10214;
        public const int SetIRCutCmd = 10203;

        // ===============
        // 3.4 status
        // ===============
        public const int StatusTelephotoCmd = 10215;
        public const int StatusIRTelephotoCmd = 10216;
        public const int StatusWorkingStateTelephotoCmd = 10022;
        public const int StatusWideangleCmd = 10217;

        // ===============
        // 4.1 Astro
        // ===============
        public const int SetupGotoCmd = 11205;
        public const int StartGotoCmd = 11203;
        public const int TakeAstroPhotoCmd = 10011;
        public const int StopAstroPhotoCmd = 10015;
        public const int TakeAstroDarkFramesCmd = 10026;
        public const int QueryShotFieldCmd = 10026;

        // ===============
        // 4.2 tracking
        // ===============
        public const int TraceInitCmd = 11200;
        public const int StartTrackingCmd = 11201;
        public const int StopTrackingCmd = 11202;

        // ===============
        // 4.3 panoromic
        // ===============
        public const int StartPanoCmd = 10103;
        public const int StopPanoCmd = 10106;

        // ===============
        // 5 motion control
        // ===============
        public const int StartMotionCmd = 10100;
        public const int StopMotionCmd = 10101;
        public const int SetSpeedCmd = 10107;
        public const int SetDirectionCmd = 10108;
        public const int SetSubdivideCmd = 10109;

        // ===============
        // 7.1 system status
        // ===============
        public const int SystemStatusCmd = 11407;

        // ===============
        // 7.2 microsd card status
        // ===============
        public const int MicrosdStatusCmd = 11405;
        public const int MicrosdAvailableCmd = 11409;

        // ===============
        // 7.4 dwarf status
        // ===============
        public const int DwarfSoftwareVersionCmd = 11410;
        public const int DwarfChargingStatusCmd = 11011;
    }
}