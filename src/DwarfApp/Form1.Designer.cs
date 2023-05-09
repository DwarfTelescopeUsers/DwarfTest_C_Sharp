namespace DwarfApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_Up = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button_Right = new System.Windows.Forms.Button();
            this.button_Left = new System.Windows.Forms.Button();
            this.button_Down = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Up
            // 
            this.button_Up.Location = new System.Drawing.Point(59, 12);
            this.button_Up.Name = "button_Up";
            this.button_Up.Size = new System.Drawing.Size(75, 23);
            this.button_Up.TabIndex = 1;
            this.button_Up.Text = "Up";
            this.button_Up.UseVisualStyleBackColor = true;
            this.button_Up.Click += new System.EventHandler(this.button_Up_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(39, 156);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Open WA Camera";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(39, 197);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Close WA Camera";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button_Right
            // 
            this.button_Right.Location = new System.Drawing.Point(120, 53);
            this.button_Right.Name = "button_Right";
            this.button_Right.Size = new System.Drawing.Size(75, 23);
            this.button_Right.TabIndex = 4;
            this.button_Right.Text = "Right";
            this.button_Right.UseVisualStyleBackColor = true;
            this.button_Right.Click += new System.EventHandler(this.button_Right_Click);
            // 
            // button_Left
            // 
            this.button_Left.Location = new System.Drawing.Point(7, 53);
            this.button_Left.Name = "button_Left";
            this.button_Left.Size = new System.Drawing.Size(75, 23);
            this.button_Left.TabIndex = 5;
            this.button_Left.Text = "Left";
            this.button_Left.UseVisualStyleBackColor = true;
            this.button_Left.Click += new System.EventHandler(this.button_Left_Click);
            // 
            // button_Down
            // 
            this.button_Down.Location = new System.Drawing.Point(59, 99);
            this.button_Down.Name = "button_Down";
            this.button_Down.Size = new System.Drawing.Size(75, 23);
            this.button_Down.TabIndex = 6;
            this.button_Down.Text = "Down";
            this.button_Down.UseVisualStyleBackColor = true;
            this.button_Down.Click += new System.EventHandler(this.button_Down_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 253);
            this.Controls.Add(this.button_Down);
            this.Controls.Add(this.button_Left);
            this.Controls.Add(this.button_Right);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button_Up);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_Up;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button_Right;
        private System.Windows.Forms.Button button_Left;
        private System.Windows.Forms.Button button_Down;
    }
}

