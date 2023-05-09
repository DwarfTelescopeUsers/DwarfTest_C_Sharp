using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DwarfApp
{
    public partial class Form1 : Form
    {
        private WsClient wsc = new WsClient();

        public Form1()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try { 
            wsc.OpenWACamera();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try { 
            wsc.CloseWACamera();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }
        }

        private void button_Up_Click(object sender, EventArgs e)
        {
            try
            { 
            int motor = (int)Motor.PITCH;
            wsc.MoveCamera(motor, 0);
            Thread.Sleep(1000);
            wsc.StopMove(motor);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }
        }

        private void button_Down_Click(object sender, EventArgs e)
        {
            try { 
            int motor = (int)Motor.PITCH;
            wsc.MoveCamera(motor, 1);
            Thread.Sleep(1000);
            wsc.StopMove(motor);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }
        }

        private void button_Left_Click(object sender, EventArgs e)
        {
            try
            {
                int motor = (int)Motor.SPIN;
                wsc.MoveCamera(motor, 1);
                Thread.Sleep(1000);
                wsc.StopMove(motor);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }
        }

        private void button_Right_Click(object sender, EventArgs e)
        {
            try
            {
                int motor = (int)Motor.SPIN;
                wsc.MoveCamera(motor, 0);
                Thread.Sleep(3000);
                wsc.StopMove(motor);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }
        }
    }
}
