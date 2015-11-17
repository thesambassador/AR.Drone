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
            this.btn_Right = new System.Windows.Forms.Button();
            this.lbl_LastCommand = new System.Windows.Forms.Label();
            this.txt_lastCommand = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(22, 18);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(112, 35);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Connect";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(144, 18);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(112, 35);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Disconnect";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // pbVideo
            // 
            this.pbVideo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pbVideo.Location = new System.Drawing.Point(22, 63);
            this.pbVideo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbVideo.Name = "pbVideo";
            this.pbVideo.Size = new System.Drawing.Size(960, 554);
            this.pbVideo.TabIndex = 2;
            this.pbVideo.TabStop = false;
            // 
            // btnEmergency
            // 
            this.btnEmergency.Location = new System.Drawing.Point(858, 18);
            this.btnEmergency.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEmergency.Name = "btnEmergency";
            this.btnEmergency.Size = new System.Drawing.Size(124, 35);
            this.btnEmergency.TabIndex = 6;
            this.btnEmergency.Text = "Emergency";
            this.btnEmergency.UseVisualStyleBackColor = true;
            this.btnEmergency.Click += new System.EventHandler(this.btnEmergency_Click);
            // 
            // tmrStateUpdate
            // 
            this.tmrStateUpdate.Tick += new System.EventHandler(this.tmrStateUpdate_Tick);
            // 
            // tvInfo
            // 
            this.tvInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvInfo.Location = new System.Drawing.Point(992, 63);
            this.tvInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tvInfo.Name = "tvInfo";
            this.tvInfo.Size = new System.Drawing.Size(340, 552);
            this.tvInfo.TabIndex = 18;
            // 
            // tmrVideoUpdate
            // 
            this.tmrVideoUpdate.Interval = 20;
            this.tmrVideoUpdate.Tick += new System.EventHandler(this.tmrVideoUpdate_Tick);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(724, 18);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(124, 35);
            this.btnReset.TabIndex = 19;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btn_sendGuideConfig
            // 
            this.btn_sendGuideConfig.Enabled = false;
            this.btn_sendGuideConfig.Location = new System.Drawing.Point(266, 18);
            this.btn_sendGuideConfig.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_sendGuideConfig.Name = "btn_sendGuideConfig";
            this.btn_sendGuideConfig.Size = new System.Drawing.Size(134, 35);
            this.btn_sendGuideConfig.TabIndex = 22;
            this.btn_sendGuideConfig.Text = "Create Guide";
            this.btn_sendGuideConfig.UseVisualStyleBackColor = true;
            this.btn_sendGuideConfig.Click += new System.EventHandler(this.btn_sendGuideConfig_Click);
            // 
            // btn_startGuide
            // 
            this.btn_startGuide.Enabled = false;
            this.btn_startGuide.Location = new System.Drawing.Point(408, 18);
            this.btn_startGuide.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_startGuide.Name = "btn_startGuide";
            this.btn_startGuide.Size = new System.Drawing.Size(134, 35);
            this.btn_startGuide.TabIndex = 23;
            this.btn_startGuide.Text = "Start Guide";
            this.btn_startGuide.UseVisualStyleBackColor = true;
            this.btn_startGuide.Click += new System.EventHandler(this.btn_startGuide_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(260, 622);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 29);
            this.label1.TabIndex = 24;
            this.label1.Text = "Tag Dist";
            // 
            // lbl_tagDistText
            // 
            this.lbl_tagDistText.AutoSize = true;
            this.lbl_tagDistText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tagDistText.Location = new System.Drawing.Point(260, 652);
            this.lbl_tagDistText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_tagDistText.Name = "lbl_tagDistText";
            this.lbl_tagDistText.Size = new System.Drawing.Size(40, 29);
            this.lbl_tagDistText.TabIndex = 25;
            this.lbl_tagDistText.Text = "---";
            this.lbl_tagDistText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(260, 683);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 29);
            this.label2.TabIndex = 26;
            this.label2.Text = "Est Runner Speed";
            // 
            // lbl_runnerSpeed
            // 
            this.lbl_runnerSpeed.AutoSize = true;
            this.lbl_runnerSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_runnerSpeed.Location = new System.Drawing.Point(260, 714);
            this.lbl_runnerSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_runnerSpeed.Name = "lbl_runnerSpeed";
            this.lbl_runnerSpeed.Size = new System.Drawing.Size(40, 29);
            this.lbl_runnerSpeed.TabIndex = 27;
            this.lbl_runnerSpeed.Text = "---";
            this.lbl_runnerSpeed.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txt_targetDist
            // 
            this.txt_targetDist.Location = new System.Drawing.Point(555, 646);
            this.txt_targetDist.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_targetDist.Name = "txt_targetDist";
            this.txt_targetDist.Size = new System.Drawing.Size(102, 26);
            this.txt_targetDist.TabIndex = 28;
            this.txt_targetDist.Text = "50";
            this.txt_targetDist.TextChanged += new System.EventHandler(this.txt_targetDist_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(543, 622);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 20);
            this.label3.TabIndex = 29;
            this.label3.Text = "Target Dist (cm)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(706, 622);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 20);
            this.label4.TabIndex = 30;
            this.label4.Text = "MaxTilt";
            // 
            // txt_maxTilt
            // 
            this.txt_maxTilt.Location = new System.Drawing.Point(686, 646);
            this.txt_maxTilt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_maxTilt.Name = "txt_maxTilt";
            this.txt_maxTilt.Size = new System.Drawing.Size(102, 26);
            this.txt_maxTilt.TabIndex = 31;
            this.txt_maxTilt.Text = ".05";
            this.txt_maxTilt.TextChanged += new System.EventHandler(this.txt_maxTilt_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(814, 622);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 20);
            this.label5.TabIndex = 32;
            this.label5.Text = "Max Velocity";
            // 
            // txt_maxVel
            // 
            this.txt_maxVel.Location = new System.Drawing.Point(813, 646);
            this.txt_maxVel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_maxVel.Name = "txt_maxVel";
            this.txt_maxVel.Size = new System.Drawing.Size(102, 26);
            this.txt_maxVel.TabIndex = 33;
            this.txt_maxVel.Text = "2";
            this.txt_maxVel.TextChanged += new System.EventHandler(this.txt_maxVel_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(550, 680);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 20);
            this.label6.TabIndex = 34;
            this.label6.Text = "Chase Velocity";
            // 
            // txt_chaseVel
            // 
            this.txt_chaseVel.Location = new System.Drawing.Point(556, 705);
            this.txt_chaseVel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_chaseVel.Name = "txt_chaseVel";
            this.txt_chaseVel.Size = new System.Drawing.Size(102, 26);
            this.txt_chaseVel.TabIndex = 35;
            this.txt_chaseVel.Text = "2";
            this.txt_chaseVel.TextChanged += new System.EventHandler(this.txt_chaseVel_TextChanged);
            // 
            // txt_DetectTime
            // 
            this.txt_DetectTime.Location = new System.Drawing.Point(686, 705);
            this.txt_DetectTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_DetectTime.Name = "txt_DetectTime";
            this.txt_DetectTime.Size = new System.Drawing.Size(102, 26);
            this.txt_DetectTime.TabIndex = 37;
            this.txt_DetectTime.Text = ".5";
            this.txt_DetectTime.TextChanged += new System.EventHandler(this.txt_DetectTime_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(675, 680);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 20);
            this.label7.TabIndex = 36;
            this.label7.Text = "Detection Time";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1083, 18);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(237, 35);
            this.button1.TabIndex = 38;
            this.button1.Text = "Stop Guide and Land";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(260, 745);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(149, 29);
            this.label8.TabIndex = 39;
            this.label8.Text = "Current state";
            // 
            // txt_currentState
            // 
            this.txt_currentState.AutoSize = true;
            this.txt_currentState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_currentState.Location = new System.Drawing.Point(260, 775);
            this.txt_currentState.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txt_currentState.Name = "txt_currentState";
            this.txt_currentState.Size = new System.Drawing.Size(40, 29);
            this.txt_currentState.TabIndex = 40;
            this.txt_currentState.Text = "---";
            this.txt_currentState.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_Left
            // 
            this.btn_Left.Location = new System.Drawing.Point(22, 658);
            this.btn_Left.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_Left.Name = "btn_Left";
            this.btn_Left.Size = new System.Drawing.Size(156, 146);
            this.btn_Left.TabIndex = 41;
            this.btn_Left.Text = "Left";
            this.btn_Left.UseVisualStyleBackColor = true;
            this.btn_Left.Click += new System.EventHandler(this.btn_Left_Click);
            // 
            // btn_Right
            // 
            this.btn_Right.Location = new System.Drawing.Point(1178, 658);
            this.btn_Right.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_Right.Name = "btn_Right";
            this.btn_Right.Size = new System.Drawing.Size(156, 146);
            this.btn_Right.TabIndex = 42;
            this.btn_Right.Text = "Right";
            this.btn_Right.UseVisualStyleBackColor = true;
            this.btn_Right.Click += new System.EventHandler(this.btn_Right_Click);
            // 
            // lbl_LastCommand
            // 
            this.lbl_LastCommand.AutoSize = true;
            this.lbl_LastCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_LastCommand.Location = new System.Drawing.Point(423, 785);
            this.lbl_LastCommand.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_LastCommand.Name = "lbl_LastCommand";
            this.lbl_LastCommand.Size = new System.Drawing.Size(180, 29);
            this.lbl_LastCommand.TabIndex = 43;
            this.lbl_LastCommand.Text = "Last Command:";
            // 
            // txt_lastCommand
            // 
            this.txt_lastCommand.AutoSize = true;
            this.txt_lastCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_lastCommand.Location = new System.Drawing.Point(608, 785);
            this.txt_lastCommand.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txt_lastCommand.Name = "txt_lastCommand";
            this.txt_lastCommand.Size = new System.Drawing.Size(37, 29);
            this.txt_lastCommand.TabIndex = 44;
            this.txt_lastCommand.Text = "---";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(992, 745);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(156, 66);
            this.button2.TabIndex = 45;
            this.button2.Text = "Right";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(992, 665);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(156, 66);
            this.button3.TabIndex = 46;
            this.button3.Text = "switchframe";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 829);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txt_lastCommand);
            this.Controls.Add(this.lbl_LastCommand);
            this.Controls.Add(this.btn_Right);
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
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
        private System.Windows.Forms.Button btn_Right;
        private System.Windows.Forms.Label lbl_LastCommand;
        private System.Windows.Forms.Label txt_lastCommand;
		private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

