namespace WindowsFormsApplication1
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
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.Ancortek98 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LeapMotionC = new System.Windows.Forms.Label();
            this.LeapMotion = new System.Windows.Forms.CheckBox();
            this.Xethru1C = new System.Windows.Forms.Label();
            this.Xethru1 = new System.Windows.Forms.CheckBox();
            this.Ancortek58C = new System.Windows.Forms.Label();
            this.Ancortek58 = new System.Windows.Forms.CheckBox();
            this.RFBeamC = new System.Windows.Forms.Label();
            this.RFBeam = new System.Windows.Forms.CheckBox();
            this.XethruC = new System.Windows.Forms.Label();
            this.Xethru = new System.Windows.Forms.CheckBox();
            this.KinectC = new System.Windows.Forms.Label();
            this.Kinect = new System.Windows.Forms.CheckBox();
            this.Ancortek25C = new System.Windows.Forms.Label();
            this.Ancortek25 = new System.Windows.Forms.CheckBox();
            this.Ancortek98C = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.NetworkLog = new System.Windows.Forms.TextBox();
            this.NetworkEnableButton = new System.Windows.Forms.Button();
            this.NetworkDisableButton = new System.Windows.Forms.Button();
            this.NetworkStatusLabel = new System.Windows.Forms.Label();
            this.IpLabel = new System.Windows.Forms.Label();
            this.directory = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Items.AddRange(new object[] {
            "Subject1",
            "Subject2",
            "Subject3",
            "Subject4",
            "Subject5",
            "Subject6",
            "Subject7",
            "Subject8",
            "Subject9"});
            this.listBox1.Location = new System.Drawing.Point(29, 48);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(135, 388);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Action:";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 16;
            this.listBox2.Items.AddRange(new object[] {
            "FSU Chop",
            "Come Here",
            "Wave Goodbye",
            "Finger L/R",
            "Finger F/B",
            "Walking Towards Radar",
            "Walking Away from Radar",
            "Picking up object",
            "Bending",
            "Sitting",
            "Kneeling",
            "Crawling"});
            this.listBox2.Location = new System.Drawing.Point(189, 48);
            this.listBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(168, 388);
            this.listBox2.TabIndex = 3;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(378, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Angle:";
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 16;
            this.listBox3.Items.AddRange(new object[] {
            "0",
            "15",
            "30",
            "45",
            "60",
            "75",
            "90"});
            this.listBox3.Location = new System.Drawing.Point(381, 48);
            this.listBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(107, 116);
            this.listBox3.TabIndex = 5;
            this.listBox3.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 451);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 25);
            this.button1.TabIndex = 8;
            this.button1.Text = "Add New Subject";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(511, 87);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 28);
            this.button2.TabIndex = 9;
            this.button2.Text = "Start Recording";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(508, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Seconds:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(511, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(147, 22);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "5";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(511, 121);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(113, 28);
            this.button3.TabIndex = 12;
            this.button3.Text = "Delayed Start";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(630, 122);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(28, 27);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = "2";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(189, 451);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(168, 25);
            this.button4.TabIndex = 14;
            this.button4.Text = "Add New Motion";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(511, 156);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(147, 33);
            this.button5.TabIndex = 15;
            this.button5.Text = "Delete Previous Rec";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Ancortek98
            // 
            this.Ancortek98.AutoSize = true;
            this.Ancortek98.Enabled = false;
            this.Ancortek98.Location = new System.Drawing.Point(6, 17);
            this.Ancortek98.Name = "Ancortek98";
            this.Ancortek98.Size = new System.Drawing.Size(131, 21);
            this.Ancortek98.TabIndex = 17;
            this.Ancortek98.Text = "Ancortek 9.8 Hz";
            this.Ancortek98.UseVisualStyleBackColor = true;
            this.Ancortek98.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LeapMotionC);
            this.groupBox1.Controls.Add(this.LeapMotion);
            this.groupBox1.Controls.Add(this.Xethru1C);
            this.groupBox1.Controls.Add(this.Xethru1);
            this.groupBox1.Controls.Add(this.Ancortek58C);
            this.groupBox1.Controls.Add(this.Ancortek58);
            this.groupBox1.Controls.Add(this.RFBeamC);
            this.groupBox1.Controls.Add(this.RFBeam);
            this.groupBox1.Controls.Add(this.XethruC);
            this.groupBox1.Controls.Add(this.Xethru);
            this.groupBox1.Controls.Add(this.KinectC);
            this.groupBox1.Controls.Add(this.Kinect);
            this.groupBox1.Controls.Add(this.Ancortek25C);
            this.groupBox1.Controls.Add(this.Ancortek25);
            this.groupBox1.Controls.Add(this.Ancortek98C);
            this.groupBox1.Controls.Add(this.Ancortek98);
            this.groupBox1.Location = new System.Drawing.Point(381, 196);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 240);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Devices";
            // 
            // LeapMotionC
            // 
            this.LeapMotionC.AutoSize = true;
            this.LeapMotionC.BackColor = System.Drawing.Color.Red;
            this.LeapMotionC.Location = new System.Drawing.Point(173, 209);
            this.LeapMotionC.Name = "LeapMotionC";
            this.LeapMotionC.Size = new System.Drawing.Size(82, 17);
            this.LeapMotionC.TabIndex = 34;
            this.LeapMotionC.Text = "Unavailable";
            // 
            // LeapMotion
            // 
            this.LeapMotion.AutoSize = true;
            this.LeapMotion.Enabled = false;
            this.LeapMotion.Location = new System.Drawing.Point(7, 208);
            this.LeapMotion.Name = "LeapMotion";
            this.LeapMotion.Size = new System.Drawing.Size(104, 21);
            this.LeapMotion.TabIndex = 33;
            this.LeapMotion.Text = "LeapMotion";
            this.LeapMotion.UseVisualStyleBackColor = true;
            // 
            // Xethru1C
            // 
            this.Xethru1C.AutoSize = true;
            this.Xethru1C.BackColor = System.Drawing.Color.LawnGreen;
            this.Xethru1C.Location = new System.Drawing.Point(173, 181);
            this.Xethru1C.Name = "Xethru1C";
            this.Xethru1C.Size = new System.Drawing.Size(89, 17);
            this.Xethru1C.TabIndex = 32;
            this.Xethru1C.Text = "Local Device";
            // 
            // Xethru1
            // 
            this.Xethru1.AutoSize = true;
            this.Xethru1.Location = new System.Drawing.Point(7, 181);
            this.Xethru1.Name = "Xethru1";
            this.Xethru1.Size = new System.Drawing.Size(104, 21);
            this.Xethru1.TabIndex = 29;
            this.Xethru1.Text = "Xethru1/2/3";
            this.Xethru1.UseVisualStyleBackColor = true;
            // 
            // Ancortek58C
            // 
            this.Ancortek58C.AutoSize = true;
            this.Ancortek58C.BackColor = System.Drawing.Color.Red;
            this.Ancortek58C.Location = new System.Drawing.Point(181, 153);
            this.Ancortek58C.Name = "Ancortek58C";
            this.Ancortek58C.Size = new System.Drawing.Size(81, 17);
            this.Ancortek58C.TabIndex = 28;
            this.Ancortek58C.Text = "No Network";
            // 
            // Ancortek58
            // 
            this.Ancortek58.AutoSize = true;
            this.Ancortek58.Enabled = false;
            this.Ancortek58.Location = new System.Drawing.Point(6, 153);
            this.Ancortek58.Name = "Ancortek58";
            this.Ancortek58.Size = new System.Drawing.Size(131, 21);
            this.Ancortek58.TabIndex = 27;
            this.Ancortek58.Text = "Ancortek 5.8 Hz";
            this.Ancortek58.UseVisualStyleBackColor = true;
            // 
            // RFBeamC
            // 
            this.RFBeamC.AutoSize = true;
            this.RFBeamC.BackColor = System.Drawing.Color.Red;
            this.RFBeamC.Location = new System.Drawing.Point(181, 126);
            this.RFBeamC.Name = "RFBeamC";
            this.RFBeamC.Size = new System.Drawing.Size(81, 17);
            this.RFBeamC.TabIndex = 26;
            this.RFBeamC.Text = "No Network";
            // 
            // RFBeam
            // 
            this.RFBeam.AutoSize = true;
            this.RFBeam.Enabled = false;
            this.RFBeam.Location = new System.Drawing.Point(6, 125);
            this.RFBeam.Name = "RFBeam";
            this.RFBeam.Size = new System.Drawing.Size(72, 21);
            this.RFBeam.TabIndex = 25;
            this.RFBeam.Text = "77Ghz";
            this.RFBeam.UseVisualStyleBackColor = true;
            // 
            // XethruC
            // 
            this.XethruC.AutoSize = true;
            this.XethruC.BackColor = System.Drawing.Color.Red;
            this.XethruC.Location = new System.Drawing.Point(173, 98);
            this.XethruC.Name = "XethruC";
            this.XethruC.Size = new System.Drawing.Size(82, 17);
            this.XethruC.TabIndex = 24;
            this.XethruC.Text = "Unavailable";
            this.XethruC.Click += new System.EventHandler(this.XethruC_Click);
            // 
            // Xethru
            // 
            this.Xethru.AutoSize = true;
            this.Xethru.Enabled = false;
            this.Xethru.Location = new System.Drawing.Point(6, 98);
            this.Xethru.Name = "Xethru";
            this.Xethru.Size = new System.Drawing.Size(72, 21);
            this.Xethru.TabIndex = 23;
            this.Xethru.Text = "Xethru";
            this.Xethru.UseVisualStyleBackColor = true;
            // 
            // KinectC
            // 
            this.KinectC.AutoSize = true;
            this.KinectC.BackColor = System.Drawing.Color.LawnGreen;
            this.KinectC.Location = new System.Drawing.Point(173, 71);
            this.KinectC.Name = "KinectC";
            this.KinectC.Size = new System.Drawing.Size(89, 17);
            this.KinectC.TabIndex = 22;
            this.KinectC.Text = "Local Device";
            // 
            // Kinect
            // 
            this.Kinect.AutoSize = true;
            this.Kinect.Location = new System.Drawing.Point(6, 71);
            this.Kinect.Name = "Kinect";
            this.Kinect.Size = new System.Drawing.Size(69, 21);
            this.Kinect.TabIndex = 21;
            this.Kinect.Text = "Kinect";
            this.Kinect.UseVisualStyleBackColor = true;
            // 
            // Ancortek25C
            // 
            this.Ancortek25C.AutoSize = true;
            this.Ancortek25C.BackColor = System.Drawing.Color.LawnGreen;
            this.Ancortek25C.Location = new System.Drawing.Point(173, 44);
            this.Ancortek25C.Name = "Ancortek25C";
            this.Ancortek25C.Size = new System.Drawing.Size(89, 17);
            this.Ancortek25C.TabIndex = 20;
            this.Ancortek25C.Text = "Local Device";
            // 
            // Ancortek25
            // 
            this.Ancortek25.AutoSize = true;
            this.Ancortek25.Location = new System.Drawing.Point(6, 44);
            this.Ancortek25.Name = "Ancortek25";
            this.Ancortek25.Size = new System.Drawing.Size(131, 21);
            this.Ancortek25.TabIndex = 19;
            this.Ancortek25.Text = "Ancortek 25 Hz ";
            this.Ancortek25.UseVisualStyleBackColor = true;
            // 
            // Ancortek98C
            // 
            this.Ancortek98C.AutoSize = true;
            this.Ancortek98C.BackColor = System.Drawing.Color.Red;
            this.Ancortek98C.Location = new System.Drawing.Point(181, 18);
            this.Ancortek98C.Name = "Ancortek98C";
            this.Ancortek98C.Size = new System.Drawing.Size(81, 17);
            this.Ancortek98C.TabIndex = 18;
            this.Ancortek98C.Text = "No Network";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.NetworkLog);
            this.groupBox2.Controls.Add(this.NetworkEnableButton);
            this.groupBox2.Controls.Add(this.NetworkDisableButton);
            this.groupBox2.Controls.Add(this.NetworkStatusLabel);
            this.groupBox2.Controls.Add(this.IpLabel);
            this.groupBox2.Location = new System.Drawing.Point(807, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 446);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Networking";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Network Log:";
            // 
            // NetworkLog
            // 
            this.NetworkLog.Location = new System.Drawing.Point(18, 126);
            this.NetworkLog.Multiline = true;
            this.NetworkLog.Name = "NetworkLog";
            this.NetworkLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.NetworkLog.Size = new System.Drawing.Size(288, 302);
            this.NetworkLog.TabIndex = 4;
            this.NetworkLog.Text = "Application Started...";
            this.NetworkLog.WordWrap = false;
            // 
            // NetworkEnableButton
            // 
            this.NetworkEnableButton.Location = new System.Drawing.Point(166, 57);
            this.NetworkEnableButton.Name = "NetworkEnableButton";
            this.NetworkEnableButton.Size = new System.Drawing.Size(140, 28);
            this.NetworkEnableButton.TabIndex = 3;
            this.NetworkEnableButton.Text = "Enable Network";
            this.NetworkEnableButton.UseVisualStyleBackColor = true;
            this.NetworkEnableButton.Click += new System.EventHandler(this.NetworkEnableButton_Click);
            // 
            // NetworkDisableButton
            // 
            this.NetworkDisableButton.Enabled = false;
            this.NetworkDisableButton.Location = new System.Drawing.Point(18, 57);
            this.NetworkDisableButton.Name = "NetworkDisableButton";
            this.NetworkDisableButton.Size = new System.Drawing.Size(142, 28);
            this.NetworkDisableButton.TabIndex = 2;
            this.NetworkDisableButton.Text = "Disable Network";
            this.NetworkDisableButton.UseVisualStyleBackColor = true;
            this.NetworkDisableButton.Click += new System.EventHandler(this.NetworkDisableButton_Click);
            // 
            // NetworkStatusLabel
            // 
            this.NetworkStatusLabel.AutoSize = true;
            this.NetworkStatusLabel.BackColor = System.Drawing.Color.Red;
            this.NetworkStatusLabel.Location = new System.Drawing.Point(134, 24);
            this.NetworkStatusLabel.Name = "NetworkStatusLabel";
            this.NetworkStatusLabel.Size = new System.Drawing.Size(137, 17);
            this.NetworkStatusLabel.TabIndex = 1;
            this.NetworkStatusLabel.Text = "Networking Disabled";
            // 
            // IpLabel
            // 
            this.IpLabel.AutoSize = true;
            this.IpLabel.Location = new System.Drawing.Point(15, 24);
            this.IpLabel.Name = "IpLabel";
            this.IpLabel.Size = new System.Drawing.Size(95, 17);
            this.IpLabel.TabIndex = 0;
            this.IpLabel.Text = "IPv4 Address:";
            // 
            // directory
            // 
            this.directory.Location = new System.Drawing.Point(449, 452);
            this.directory.Name = "directory";
            this.directory.Size = new System.Drawing.Size(291, 22);
            this.directory.TabIndex = 20;
            this.directory.Text = "C:\\Users\\RSL\\Documents\\GestureDataRepo\\";
            this.directory.TextChanged += new System.EventHandler(this.directory_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(378, 455);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "Directory";
            this.label4.Click += new System.EventHandler(this.label4_Click_1);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(746, 451);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(55, 23);
            this.button6.TabIndex = 22;
            this.button6.Text = "Load";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1166, 502);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.directory);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Radar Data Collection";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Ancortek98C;
        private System.Windows.Forms.CheckBox Ancortek25;
        private System.Windows.Forms.Label KinectC;
        private System.Windows.Forms.CheckBox Kinect;
        private System.Windows.Forms.Label Ancortek25C;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label IpLabel;
        private System.Windows.Forms.Label NetworkStatusLabel;
        private System.Windows.Forms.Button NetworkEnableButton;
        private System.Windows.Forms.Button NetworkDisableButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox NetworkLog;
        private System.Windows.Forms.Label XethruC;
        private System.Windows.Forms.CheckBox Xethru;
        private System.Windows.Forms.CheckBox RFBeam;
        private System.Windows.Forms.Label RFBeamC;
        private System.Windows.Forms.CheckBox Ancortek98;
        private System.Windows.Forms.Label Ancortek58C;
        private System.Windows.Forms.CheckBox Ancortek58;
        private System.Windows.Forms.Label Xethru1C;
        private System.Windows.Forms.CheckBox Xethru1;
        private System.Windows.Forms.Label LeapMotionC;
        private System.Windows.Forms.CheckBox LeapMotion;
        private System.Windows.Forms.TextBox directory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button6;
    }
}

