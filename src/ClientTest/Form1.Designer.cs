namespace ClientTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BtnPowerOn = new Button();
            BtnRotateAnti = new Button();
            BtnStop1 = new Button();
            BtnRotateClock = new Button();
            SuspendLayout();
            // 
            // BtnPowerOn
            // 
            BtnPowerOn.Location = new Point(23, 28);
            BtnPowerOn.Name = "BtnPowerOn";
            BtnPowerOn.Size = new Size(75, 23);
            BtnPowerOn.TabIndex = 0;
            BtnPowerOn.Text = "Power On";
            BtnPowerOn.UseVisualStyleBackColor = true;
            BtnPowerOn.Click += BtnPowerOn_Click;
            // 
            // BtnRotateAnti
            // 
            BtnRotateAnti.Location = new Point(152, 28);
            BtnRotateAnti.Name = "BtnRotateAnti";
            BtnRotateAnti.Size = new Size(75, 23);
            BtnRotateAnti.TabIndex = 1;
            BtnRotateAnti.Text = "Rotate Anti";
            BtnRotateAnti.UseVisualStyleBackColor = true;
            BtnRotateAnti.Click += BtnRotateAnti_Click;
            // 
            // BtnStop1
            // 
            BtnStop1.Location = new Point(233, 28);
            BtnStop1.Name = "BtnStop1";
            BtnStop1.Size = new Size(75, 23);
            BtnStop1.TabIndex = 2;
            BtnStop1.Text = "Stop 1";
            BtnStop1.UseVisualStyleBackColor = true;
            BtnStop1.Click += BtnStop1_Click;
            // 
            // BtnRotateClock
            // 
            BtnRotateClock.Location = new Point(314, 28);
            BtnRotateClock.Name = "BtnRotateClock";
            BtnRotateClock.Size = new Size(85, 23);
            BtnRotateClock.TabIndex = 3;
            BtnRotateClock.Text = "Rotate Clock";
            BtnRotateClock.UseVisualStyleBackColor = true;
            BtnRotateClock.Click += BtnRotateClock_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnRotateClock);
            Controls.Add(BtnStop1);
            Controls.Add(BtnRotateAnti);
            Controls.Add(BtnPowerOn);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button BtnPowerOn;
        private Button BtnRotateAnti;
        private Button BtnStop1;
        private Button BtnRotateClock;
    }
}