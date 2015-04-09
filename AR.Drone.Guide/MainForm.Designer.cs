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
            this.btnEmergency = new System.Windows.Forms.Button();
            this.tmrStateUpdate = new System.Windows.Forms.Timer(this.components);
            this.tvInfo = new System.Windows.Forms.TreeView();
            this.tmrVideoUpdate = new System.Windows.Forms.Timer(this.components);
            this.btnReset = new System.Windows.Forms.Button();
            this.btn_sendGuideConfig = new System.Windows.Forms.Button();
            this.btn_startGuide = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_tagDistText = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_runnerSpeed = new System.Windows.Forms.Label();
            this.txt_targetDist = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_maxTilt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_maxVel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_chaseVel = new System.Windows.Forms.TextBox();
            this.txt_DetectTime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_currentState = new System.Windows.Forms.Label();
            this.btn_Left = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(70, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Connect";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(151, 12);
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
            this.pbVideo.Location = new System.Drawing.Point(70, 41);
            this.pbVideo.Name = "pbVideo";
            this.pbVideo.Size = new System.Drawing.Size(640, 360);
            this.pbVideo.TabIndex = 2;
            this.pbVideo.TabStop = false;
            // 
            // btnEmergency
            // 
            this.btnEmergency.Location = new System.Drawing.Point(627, 12);
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
            // tvInfo
            // 
            this.tvInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvInfo.Location = new System.Drawing.Point(722, 41);
            this.tvInfo.Name = "tvInfo";
            this.tvInfo.Size = new System.Drawing.Size(257, 483);
            this.tvInfo.TabIndex = 18;
            // 
            // tmrVideoUpdate
            // 
            this.tmrVideoUpdate.Interval = 20;
            this.tmrVideoUpdate.Tick += new System.EventHandler(this.tmrVideoUpdate_Tick);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(538, 12);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(83, 23);
            this.btnReset.TabIndex = 19;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btn_sendGuideConfig
            // 
            this.btn_sendGuideConfig.Enabled = false;
            this.btn_sendGuideConfig.Location = new System.Drawing.Point(232, 12);
            this.btn_sendGuideConfig.Name = "btn_sendGuideConfig";
            this.btn_sendGuideConfig.Size = new System.Drawing.Size(89, 23);
            this.btn_sendGuideConfig.TabIndex = 22;
            this.btn_sendGuideConfig.Text = "Create Guide";
            this.btn_sendGuideConfig.UseVisualStyleBackColor = true;
            this.btn_sendGuideConfig.Click += new System.EventHandler(this.btn_sendGuideConfig_Click);
            // 
            // btn_startGuide
            // 
            this.btn_startGuide.Enabled = false;
            this.btn_startGuide.Location = new System.Drawing.Point(327, 12);
            this.btn_startGuide.Name = "btn_startGuide";
            this.btn_startGuide.Size = new System.Drawing.Size(89, 23);
            this.btn_startGuide.TabIndex = 23;
            this.btn_startGuide.Text = "Start Guide";
            this.btn_startGuide.UseVisualStyleBackColor = true;
            this.btn_startGuide.Click += new System.EventHandler(this.btn_startGuide_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 404);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "Tag Dist";
            // 
            // lbl_tagDistText
            // 
            this.lbl_tagDistText.AutoSize = true;
            this.lbl_tagDistText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tagDistText.Location = new System.Drawing.Point(70, 424);
            this.lbl_tagDistText.Name = "lbl_tagDistText";
            this.lbl_tagDistText.Size = new System.Drawing.Size(27, 20);
            this.lbl_tagDistText.TabIndex = 25;
            this.lbl_tagDistText.Text = "---";
            this.lbl_tagDistText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(70, 444);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "Est Runner Speed";
            // 
            // lbl_runnerSpeed
            // 
            this.lbl_runnerSpeed.AutoSize = true;
            this.lbl_runnerSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_runnerSpeed.Location = new System.Drawing.Point(70, 464);
            this.lbl_runnerSpeed.Name = "lbl_runnerSpeed";
            this.lbl_runnerSpeed.Size = new System.Drawing.Size(27, 20);
            this.lbl_runnerSpeed.TabIndex = 27;
            this.lbl_runnerSpeed.Text = "---";
            this.lbl_runnerSpeed.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txt_targetDist
            // 
            this.txt_targetDist.Location = new System.Drawing.Point(425, 420);
            this.txt_targetDist.Name = "txt_targetDist";
            this.txt_targetDist.Size = new System.Drawing.Size(69, 20);
            this.txt_targetDist.TabIndex = 28;
            this.txt_targetDist.Text = "50";
            this.txt_targetDist.TextChanged += new System.EventHandler(this.txt_targetDist_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(417, 404);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Target Dist (cm)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(526, 404);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "MaxTilt";
            // 
            // txt_maxTilt
            // 
            this.txt_maxTilt.Location = new System.Drawing.Point(512, 420);
            this.txt_maxTilt.Name = "txt_maxTilt";
            this.txt_maxTilt.Size = new System.Drawing.Size(69, 20);
            this.txt_maxTilt.TabIndex = 31;
            this.txt_maxTilt.Text = ".05";
            this.txt_maxTilt.TextChanged += new System.EventHandler(this.txt_maxTilt_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(598, 404);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Max Velocity";
            // 
            // txt_maxVel
            // 
            this.txt_maxVel.Location = new System.Drawing.Point(597, 420);
            this.txt_maxVel.Name = "txt_maxVel";
            this.txt_maxVel.Size = new System.Drawing.Size(69, 20);
            this.txt_maxVel.TabIndex = 33;
            this.txt_maxVel.Text = "2";
            this.txt_maxVel.TextChanged += new System.EventHandler(this.txt_maxVel_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(422, 451);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Chase Velocity";
            // 
            // txt_chaseVel
            // 
            this.txt_chaseVel.Location = new System.Drawing.Point(426, 467);
            this.txt_chaseVel.Name = "txt_chaseVel";
            this.txt_chaseVel.Size = new System.Drawing.Size(69, 20);
            this.txt_chaseVel.TabIndex = 35;
            this.txt_chaseVel.Text = "2";
            this.txt_chaseVel.TextChanged += new System.EventHandler(this.txt_chaseVel_TextChanged);
            // 
            // txt_DetectTime
            // 
            this.txt_DetectTime.Location = new System.Drawing.Point(512, 467);
            this.txt_DetectTime.Name = "txt_DetectTime";
            this.txt_DetectTime.Size = new System.Drawing.Size(69, 20);
            this.txt_DetectTime.TabIndex = 37;
            this.txt_DetectTime.Text = ".5";
            this.txt_DetectTime.TextChanged += new System.EventHandler(this.txt_DetectTime_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(505, 451);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Detection Time";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(722, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 23);
            this.button1.TabIndex = 38;
            this.button1.Text = "Stop Guide and Land";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(70, 484);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 20);
            this.label8.TabIndex = 39;
            this.label8.Text = "Current state";
            // 
            // txt_currentState
            // 
            this.txt_currentState.AutoSize = true;
            this.txt_currentState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_currentState.Location = new System.Drawing.Point(70, 504);
            this.txt_currentState.Name = "txt_currentState";
            this.txt_currentState.Size = new System.Drawing.Size(27, 20);
            this.txt_currentState.TabIndex = 40;
            this.txt_currentState.Text = "---";
            this.txt_currentState.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_Left
            // 
            this.btn_Left.Location = new System.Drawing.Point(12, 559);
            this.btn_Left.Name = "btn_Left";
            this.btn_Left.Size = new System.Drawing.Size(104, 95);
            this.btn_Left.TabIndex = 41;
            this.btn_Left.Text = "Left";
            this.btn_Left.UseVisualStyleBackColor = true;
            this.btn_Left.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Left_MouseDown);
            this.btn_Left.MouseLeave += new System.EventHandler(this.btn_Left_MouseLeave);
            this.btn_Left.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Left_MouseUp);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(960, 559);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 95);
            this.button2.TabIndex = 42;
            this.button2.Text = "Right";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button2_MouseDown);
            this.button2.MouseLeave += new System.EventHandler(this.button2_MouseLeave);
            this.button2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button2_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 666);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_Left);
            this.Controls.Add(this.txt_currentState);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_DetectTime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_chaseVel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_maxVel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_maxTilt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_targetDist);
            this.Controls.Add(this.lbl_runnerSpeed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_tagDistText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_startGuide);
            this.Controls.Add(this.btn_sendGuideConfig);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.tvInfo);
            this.Controls.Add(this.btnEmergency);
            this.Controls.Add(this.pbVideo);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "MainForm";
            this.Text = "AR.Drone Control";
            ((System.ComponentModel.ISupportInitialize)(this.pbVideo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.PictureBox pbVideo;
        private System.Windows.Forms.Button btnEmergency;
        private System.Windows.Forms.Timer tmrStateUpdate;
        private System.Windows.Forms.TreeView tvInfo;
        private System.Windows.Forms.Timer tmrVideoUpdate;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btn_sendGuideConfig;
        private System.Windows.Forms.Button btn_startGuide;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_tagDistText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_runnerSpeed;
        private System.Windows.Forms.TextBox txt_targetDist;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_maxTilt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_maxVel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_chaseVel;
        private System.Windows.Forms.TextBox txt_DetectTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label txt_currentState;
        private System.Windows.Forms.Button btn_Left;
        private System.Windows.Forms.Button button2;
    }
}

