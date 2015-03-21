namespace AR.Drone.Guide
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.pbVideo = new System.Windows.Forms.PictureBox();
            this.btnFlatTrim = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnEmergency = new System.Windows.Forms.Button();
            this.tmrStateUpdate = new System.Windows.Forms.Timer(this.components);
            this.btnSwitchCam = new System.Windows.Forms.Button();
            this.btnHover = new System.Windows.Forms.Button();
            this.tvInfo = new System.Windows.Forms.TreeView();
            this.tmrVideoUpdate = new System.Windows.Forms.Timer(this.components);
            this.btnReset = new System.Windows.Forms.Button();
            this.btnReadConfig = new System.Windows.Forms.Button();
            this.btnSendConfig = new System.Windows.Forms.Button();
            this.btn_sendGuideConfig = new System.Windows.Forms.Button();
            this.btn_startGuide = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Connect";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(93, 12);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Disconnect";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // pbVideo
            // 
            this.pbVideo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pbVideo.Location = new System.Drawing.Point(12, 41);
            this.pbVideo.Name = "pbVideo";
            this.pbVideo.Size = new System.Drawing.Size(640, 360);
            this.pbVideo.TabIndex = 2;
            this.pbVideo.TabStop = false;
            // 
            // btnFlatTrim
            // 
            this.btnFlatTrim.Location = new System.Drawing.Point(12, 407);
            this.btnFlatTrim.Name = "btnFlatTrim";
            this.btnFlatTrim.Size = new System.Drawing.Size(75, 23);
            this.btnFlatTrim.TabIndex = 3;
            this.btnFlatTrim.Text = "Flat Trim";
            this.btnFlatTrim.UseVisualStyleBackColor = true;
            this.btnFlatTrim.Click += new System.EventHandler(this.btnFlatTrim_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(174, 407);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Takeoff";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(256, 407);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Land";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnEmergency
            // 
            this.btnEmergency.Location = new System.Drawing.Point(569, 12);
            this.btnEmergency.Name = "btnEmergency";
            this.btnEmergency.Size = new System.Drawing.Size(83, 23);
            this.btnEmergency.TabIndex = 6;
            this.btnEmergency.Text = "Emergency";
            this.btnEmergency.UseVisualStyleBackColor = true;
            this.btnEmergency.Click += new System.EventHandler(this.btnEmergency_Click);
            // 
            // tmrStateUpdate
            // 
            this.tmrStateUpdate.Interval = 500;
            this.tmrStateUpdate.Tick += new System.EventHandler(this.tmrStateUpdate_Tick);
            // 
            // btnSwitchCam
            // 
            this.btnSwitchCam.Location = new System.Drawing.Point(563, 407);
            this.btnSwitchCam.Name = "btnSwitchCam";
            this.btnSwitchCam.Size = new System.Drawing.Size(89, 23);
            this.btnSwitchCam.TabIndex = 8;
            this.btnSwitchCam.Text = "Video Channel";
            this.btnSwitchCam.UseVisualStyleBackColor = true;
            this.btnSwitchCam.Click += new System.EventHandler(this.btnSwitchCam_Click);
            // 
            // btnHover
            // 
            this.btnHover.Location = new System.Drawing.Point(338, 407);
            this.btnHover.Name = "btnHover";
            this.btnHover.Size = new System.Drawing.Size(75, 23);
            this.btnHover.TabIndex = 17;
            this.btnHover.Text = "Hover";
            this.btnHover.UseVisualStyleBackColor = true;
            this.btnHover.Click += new System.EventHandler(this.btnHover_Click);
            // 
            // tvInfo
            // 
            this.tvInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvInfo.Location = new System.Drawing.Point(661, 41);
            this.tvInfo.Name = "tvInfo";
            this.tvInfo.Size = new System.Drawing.Size(291, 480);
            this.tvInfo.TabIndex = 18;
            // 
            // tmrVideoUpdate
            // 
            this.tmrVideoUpdate.Interval = 20;
            this.tmrVideoUpdate.Tick += new System.EventHandler(this.tmrVideoUpdate_Tick);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(480, 12);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(83, 23);
            this.btnReset.TabIndex = 19;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnReadConfig
            // 
            this.btnReadConfig.Location = new System.Drawing.Point(563, 442);
            this.btnReadConfig.Name = "btnReadConfig";
            this.btnReadConfig.Size = new System.Drawing.Size(89, 23);
            this.btnReadConfig.TabIndex = 20;
            this.btnReadConfig.Text = "Read Config";
            this.btnReadConfig.UseVisualStyleBackColor = true;
            this.btnReadConfig.Click += new System.EventHandler(this.btnReadConfig_Click);
            // 
            // btnSendConfig
            // 
            this.btnSendConfig.Location = new System.Drawing.Point(563, 471);
            this.btnSendConfig.Name = "btnSendConfig";
            this.btnSendConfig.Size = new System.Drawing.Size(89, 23);
            this.btnSendConfig.TabIndex = 21;
            this.btnSendConfig.Text = "Send Config";
            this.btnSendConfig.UseVisualStyleBackColor = true;
            this.btnSendConfig.Click += new System.EventHandler(this.btnSendConfig_Click);
            // 
            // btn_sendGuideConfig
            // 
            this.btn_sendGuideConfig.Location = new System.Drawing.Point(174, 12);
            this.btn_sendGuideConfig.Name = "btn_sendGuideConfig";
            this.btn_sendGuideConfig.Size = new System.Drawing.Size(89, 23);
            this.btn_sendGuideConfig.TabIndex = 22;
            this.btn_sendGuideConfig.Text = "Guide Config";
            this.btn_sendGuideConfig.UseVisualStyleBackColor = true;
            this.btn_sendGuideConfig.Click += new System.EventHandler(this.btn_sendGuideConfig_Click);
            // 
            // btn_startGuide
            // 
            this.btn_startGuide.Location = new System.Drawing.Point(269, 12);
            this.btn_startGuide.Name = "btn_startGuide";
            this.btn_startGuide.Size = new System.Drawing.Size(89, 23);
            this.btn_startGuide.TabIndex = 23;
            this.btn_startGuide.Text = "Start Guide";
            this.btn_startGuide.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 533);
            this.Controls.Add(this.btn_startGuide);
            this.Controls.Add(this.btn_sendGuideConfig);
            this.Controls.Add(this.btnSendConfig);
            this.Controls.Add(this.btnReadConfig);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.tvInfo);
            this.Controls.Add(this.btnHover);
            this.Controls.Add(this.btnSwitchCam);
            this.Controls.Add(this.btnEmergency);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnFlatTrim);
            this.Controls.Add(this.pbVideo);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "MainForm";
            this.Text = "AR.Drone Control";
            ((System.ComponentModel.ISupportInitialize)(this.pbVideo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.PictureBox pbVideo;
        private System.Windows.Forms.Button btnFlatTrim;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnEmergency;
        private System.Windows.Forms.Timer tmrStateUpdate;
        private System.Windows.Forms.Button btnSwitchCam;
        private System.Windows.Forms.Button btnHover;
        private System.Windows.Forms.TreeView tvInfo;
        private System.Windows.Forms.Timer tmrVideoUpdate;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnReadConfig;
        private System.Windows.Forms.Button btnSendConfig;
        private System.Windows.Forms.Button btn_sendGuideConfig;
        private System.Windows.Forms.Button btn_startGuide;
    }
}

