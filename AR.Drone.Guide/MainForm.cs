using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AR.Drone.Client;
using AR.Drone.Client.Command;
using AR.Drone.Client.Configuration;
using AR.Drone.Data;
using AR.Drone.Data.Navigation;
using AR.Drone.Data.Navigation.Native;
using AR.Drone.Media;
using AR.Drone.Video;
using AR.Drone.Avionics;
using AR.Drone.Avionics.Objectives;
using AR.Drone.Avionics.Objectives.IntentObtainers;

namespace AR.Drone.Guide
{
    public partial class MainForm : Form
    {
        private const string ARDroneTrackFileExt = ".ardrone";
        private const string ARDroneTrackFilesFilter = "AR.Drone track files (*.ardrone)|*.ardrone";

        private readonly DroneClient _droneClient;
        private readonly VideoPacketDecoderWorker _videoPacketDecoderWorker;
        private Settings _settings;
        private VideoFrame _frame;
        private Bitmap _frameBitmap;
        private uint _frameNumber;
        private NavigationData _navigationData;
        private NavigationPacket _navigationPacket;
        private PacketRecorder _packetRecorderWorker;

        private GuideWorker _guideWorker;

        public MainForm()
        {
            InitializeComponent();

            _videoPacketDecoderWorker = new VideoPacketDecoderWorker(PixelFormat.BGR24, true, OnVideoPacketDecoded);
            _videoPacketDecoderWorker.Start();

            _droneClient = new DroneClient("192.168.1.1");
            _droneClient.NavigationPacketAcquired += OnNavigationPacketAcquired;
            _droneClient.VideoPacketAcquired += OnVideoPacketAcquired;
            _droneClient.NavigationDataAcquired += data => _navigationData = data;

            tmrStateUpdate.Enabled = true;
            tmrVideoUpdate.Enabled = true;

            _videoPacketDecoderWorker.UnhandledException += UnhandledException;

            //init values from default values
            txt_DetectTime.Text = GuideWorker.DetectionTime.ToString();
            txt_chaseVel.Text = GuideWorker.ChaseVelocity.ToString();
            txt_maxTilt.Text = GuideWorker.MaxTilt.ToString();
            txt_maxVel.Text = GuideWorker.MaxVelocity.ToString();
            txt_targetDist.Text = GuideWorker.TargetDistance.ToString();
        }


        private void UnhandledException(object sender, Exception exception)
        {
            MessageBox.Show(exception.ToString(), "Unhandled Exception (Ctrl+C)", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Text += Environment.Is64BitProcess ? " [64-bit]" : " [32-bit]";
        }

        protected override void OnClosed(EventArgs e)
        {

            if (_guideWorker != null)
            {
                _guideWorker.Deactivate();
                _guideWorker.Stop();
            }

            _droneClient.Dispose();
            _videoPacketDecoderWorker.Dispose();

            base.OnClosed(e);
        }

        private void OnNavigationPacketAcquired(NavigationPacket packet)
        {
            if (_packetRecorderWorker != null && _packetRecorderWorker.IsAlive)
                _packetRecorderWorker.EnqueuePacket(packet);

            _navigationPacket = packet;
        }

        private void OnVideoPacketAcquired(VideoPacket packet)
        {
            if (_packetRecorderWorker != null && _packetRecorderWorker.IsAlive)
                _packetRecorderWorker.EnqueuePacket(packet);
            if (_videoPacketDecoderWorker.IsAlive)
                _videoPacketDecoderWorker.EnqueuePacket(packet);
        }

        private void OnVideoPacketDecoded(VideoFrame frame)
        {
            _frame = frame;

            //send video frame to GuideWorker
            if(_guideWorker != null)
                _guideWorker.VideoPacketDecoded(frame);

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _droneClient.Start();
            btn_sendGuideConfig.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _droneClient.Stop();
            btn_startGuide.Enabled = false;
            btn_sendGuideConfig.Enabled = false;
        }

        private void tmrVideoUpdate_Tick(object sender, EventArgs e)
        {
            if (_frame == null || _frameNumber == _frame.Number)
                return;
            _frameNumber = _frame.Number;

            if (_frameBitmap == null)
                _frameBitmap = VideoHelper.CreateBitmap(ref _frame);
            else
                VideoHelper.UpdateBitmap(ref _frameBitmap, ref _frame);

            drawTagDetection();

            pbVideo.Image = _frameBitmap;
        }

        private void tmrStateUpdate_Tick(object sender, EventArgs e)
        {
            tvInfo.BeginUpdate();

            TreeNode node = tvInfo.Nodes.GetOrCreate("ClientActive");
            node.Text = string.Format("Client Active: {0}", _droneClient.IsActive);

            node = tvInfo.Nodes.GetOrCreate("Navigation Data");
            if (_navigationData != null) DumpBranch(node.Nodes, _navigationData);

            node = tvInfo.Nodes.GetOrCreate("Configuration");
            if (_settings != null) DumpBranch(node.Nodes, _settings);

            TreeNode vativeNode = tvInfo.Nodes.GetOrCreate("Native");

            NavdataBag navdataBag;
            if (_navigationPacket.Data != null && NavdataBagParser.TryParse(ref _navigationPacket, out navdataBag))
            {
                var ctrl_state = (CTRL_STATES) (navdataBag.demo.ctrl_state >> 0x10);
                node = vativeNode.Nodes.GetOrCreate("ctrl_state");
                node.Text = string.Format("Ctrl State: {0}", ctrl_state);

                var flying_state = (FLYING_STATES) (navdataBag.demo.ctrl_state & 0xffff);
                node = vativeNode.Nodes.GetOrCreate("flying_state");
                node.Text = string.Format("Ctrl State: {0}", flying_state);

                DumpBranch(vativeNode.Nodes, navdataBag);
            }
            tvInfo.EndUpdate();

            if (_navigationData != null)
            {
                if (_navigationData.Vision.nb_detected == 1)
                    lbl_tagDistText.Text = _navigationData.Vision.dist[0].ToString();
                else
                    lbl_tagDistText.Text = "---";

                if (_guideWorker != null)
                {
                    lbl_runnerSpeed.Text = _guideWorker.EstRunnerSpeed.ToString();
                    txt_currentState.Text = _guideWorker.StateText;
                }
            }
        }

        private void DumpBranch(TreeNodeCollection nodes, object o)
        {
            Type type = o.GetType();
         
            foreach (FieldInfo fieldInfo in type.GetFields())
            {
                TreeNode node = nodes.GetOrCreate(fieldInfo.Name);
                object value = fieldInfo.GetValue(o);

                DumpValue(fieldInfo.FieldType, node, value);
            }

            foreach (PropertyInfo propertyInfo in type.GetProperties())
            {
                TreeNode node = nodes.GetOrCreate(propertyInfo.Name);
                object value = propertyInfo.GetValue(o, null);

                DumpValue(propertyInfo.PropertyType, node, value);
            }
        }

        private void DumpValue(Type type, TreeNode node, object value)
        {
            if (value == null)
                node.Text = node.Name + ": null";
            else
            {
                if (type.Namespace.StartsWith("System") || type.IsEnum)
                    node.Text = node.Name + ": " + value;
                else
                    DumpBranch(node.Nodes, value);
            }
        }

        private void btnFlatTrim_Click(object sender, EventArgs e)
        {
            _droneClient.FlatTrim();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _droneClient.Takeoff();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _droneClient.Land();
        }

        private void btnEmergency_Click(object sender, EventArgs e)
        {
            _droneClient.Emergency();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _droneClient.ResetEmergency();
        }

        private void btnSwitchCam_Click(object sender, EventArgs e)
        {
            var configuration = new Settings();
            configuration.Video.Channel = VideoChannelType.Next;
            _droneClient.Send(configuration);
        }

        private void btnHover_Click(object sender, EventArgs e)
        {
            _droneClient.Hover();
        }

        private void btnReadConfig_Click(object sender, EventArgs e)
        {
            Task<Settings> configurationTask = _droneClient.GetConfigurationTask();
            configurationTask.ContinueWith(delegate(Task<Settings> task)
                {
                    if (task.Exception != null)
                    {
                        Trace.TraceWarning("Get configuration task is faulted with exception: {0}", task.Exception.InnerException.Message);
                        return;
                    }

                    _settings = task.Result;
                });
            configurationTask.Start();
        }

        private void btnSendConfig_Click(object sender, EventArgs e)
        {
            var sendConfigTask = new Task(() =>
                {
                    if (_settings == null) _settings = new Settings();
                    Settings settings = _settings;

                    if (string.IsNullOrEmpty(settings.Custom.SessionId) ||
                        settings.Custom.SessionId == "00000000")
                    {
                        // set new session, application and profile
                        _droneClient.AckControlAndWaitForConfirmation(); // wait for the control confirmation

                        settings.Custom.SessionId = Settings.NewId();
                        _droneClient.Send(settings);
                        
                        _droneClient.AckControlAndWaitForConfirmation();

                        settings.Custom.ProfileId = Settings.NewId();
                        _droneClient.Send(settings);
                        
                        _droneClient.AckControlAndWaitForConfirmation();

                        settings.Custom.ApplicationId = Settings.NewId();
                        _droneClient.Send(settings);
                        
                        _droneClient.AckControlAndWaitForConfirmation();
                    }

                    settings.General.NavdataDemo = false;
                    settings.General.NavdataOptions = NavdataOptions.All;

                    settings.Video.BitrateCtrlMode = VideoBitrateControlMode.Dynamic;
                    settings.Video.Bitrate = 1000;
                    settings.Video.MaxBitrate = 2000;

                    settings.Detect.Type = 13;
                    settings.Detect.EnemyColors = 3;

                    //settings.Leds.LedAnimation = new LedAnimation(LedAnimationType.BlinkGreenRed, 2.0f, 2);
                    //settings.Control.FlightAnimation = new FlightAnimation(FlightAnimationType.Wave);

                    // record video to usb
                    //settings.Video.OnUsb = true;
                    // usage of MP4_360P_H264_720P codec is a requirement for video recording to usb
                    //settings.Video.Codec = VideoCodecType.MP4_360P_H264_720P;
                    // start
                    //settings.Userbox.Command = new UserboxCommand(UserboxCommandType.Start);
                    // stop
                    //settings.Userbox.Command = new UserboxCommand(UserboxCommandType.Stop);


                    //send all changes in one pice
                    _droneClient.Send(settings);
                });
            sendConfigTask.Start();
        }

        //Send the configuration settings for the guide (turn on tag detection mainly)
        private void btn_sendGuideConfig_Click(object sender, EventArgs e)
        {
            if (_guideWorker == null)
            {
                _guideWorker = new GuideWorker(_droneClient);
            }
            btn_startGuide.Enabled = true;
        }

        //start the guide
        private void btn_startGuide_Click(object sender, EventArgs e)
        {

            _guideWorker.Activate();

           
            //_guideWorker.Start();
        }

        private void txt_targetDist_TextChanged(object sender, EventArgs e)
        {
            if (_guideWorker != null)
                float.TryParse(txt_targetDist.Text, out GuideWorker.TargetDistance);
        }

        private void txt_maxTilt_TextChanged(object sender, EventArgs e)
        {
            if (_guideWorker != null)
                float.TryParse(txt_maxTilt.Text, out GuideWorker.MaxTilt);
        }

        private void txt_maxVel_TextChanged(object sender, EventArgs e)
        {
            if (_guideWorker != null)
                float.TryParse(txt_maxVel.Text, out GuideWorker.MaxVelocity);
        }

        private void txt_chaseVel_TextChanged(object sender, EventArgs e)
        {
            if (_guideWorker != null)
                float.TryParse(txt_chaseVel.Text, out GuideWorker.ChaseVelocity);
        }

        private void txt_DetectTime_TextChanged(object sender, EventArgs e)
        {
            if (_guideWorker != null)
                float.TryParse(txt_DetectTime.Text, out GuideWorker.DetectionTime);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _guideWorker.Deactivate();
            _guideWorker.Stop();
            _droneClient.Land();
        }

        private void drawTagDetection()
        {
            if (_navigationData.Vision.nb_detected > 0)
            {
                uint x = _navigationData.Vision.xc[0];
                uint y = _navigationData.Vision.yc[0];
                uint w = _navigationData.Vision.width[0];
                uint h = _navigationData.Vision.height[0];
                uint dist = _navigationData.Vision.dist[0];

                Graphics g = Graphics.FromImage(_frameBitmap);
                Pen redPen = new Pen(Color.Red, 3);

                float pixelW = (float)w / 1000 * _frameBitmap.Width;
                float pixelH = (float)h / 1000 * _frameBitmap.Height;

                float pixelX = (float)x / 1000 * _frameBitmap.Width - (pixelW / 2);
                float pixelY = (float)y / 1000 * _frameBitmap.Height - (pixelH / 2);


                g.DrawRectangle(redPen, pixelX, pixelY, pixelW, pixelH);
                //g.DrawString("Raw Distance: " + dist.ToString(), DefaultFont, new SolidBrush(Color.Red), 0, 0);
            }

        }


       
    }
}