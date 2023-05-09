namespace ClientTest.Models
{
    public class D2Message
    {
        public int Interface { get; set; }

        /// <summary>
        /// 0:Long focal camera 1:Wide-angle camera
        /// </summary>
        public int CamId { get; set; }

        /// <summary>
        /// Error code
        /// </summary>
        /// 
        public int? Code { get; set; }

        /// <summary>
        /// 10006:
        /// 0:Single shot 1:Continuous Capture
        /// 
        /// 10001:
        /// Long focal camera：0:auto 1:man
        /// Wide-angle camera：3:auto 1:man
        /// 
        /// 10004:
        /// 0:auto 1:manual
        /// 
        /// 10211:
        /// 0：Global focus 1：Area focus
        /// 
        /// 10212:
        /// 0：auto 1：manual
        /// 
        /// 10213:
        /// 0：Incandescent lamp
        /// 1：Fluorescent lamp
        /// 2：Warm fluorescent lamp
        /// 3：sunlight
        /// 4：overcast sky
        /// 5：evening twilight
        /// 6：shadow
        /// 
        /// </summary>
        /// 
        public int? Mode { get; set; }

        /// <summary>
        /// Name it with a phone timestamp
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 1s-60s
        /// </summary>
        public int? Interval { get; set; }

        /// <summary>
        /// 1s-
        /// </summary>
        public int? OutTime { get; set; }

        /// <summary>
        /// Long focal range:0-255 default：128
        /// Wide-angle range：-64-64 default：0
        /// </summary>
        public int? Value { get; set; }

        /// <summary>
        /// 0-1920
        /// </summary>
        public int? CenterX { get; set; }

        /// <summary>
        /// 0-1080
        /// </summary>
        public int? CenterY { get; set; }

        /// <summary>
        /// motor id int 1:spin 2:pitch
        /// </summary>
        public int? Id { get; set; }

        public int? MStep { get; set; }

        public int? Speed { get; set; }
        public int? Direction { get; set;}
        public int? Pulse { get; set; }

        public int? AccelStep { get; set; }
        public int? DecelStep { get; set; }
        /*

mode int 1:continuous mode 2:pulse mode
mStep(subdivide) int 1 2 4 8 16 32 64 128 256
speed int range:0-65536（1-50000&&
<1000*mStep）
direction int 0:anticlockwise 1:clockwise
pulse int range:>=2（mStep<=32）
>=5(mStep>32)
accelStep(Acceleration steps) int 0-1000

         */

    }

}
