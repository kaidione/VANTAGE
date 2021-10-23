using System;
using System.Windows.Forms;
using winformUI.Common;
using winformUI.UserControls;

namespace winformUI
{
    public partial class LenovoMultipleClient : Form
    {
        int panelWidth;
        bool moveEnable = false;
        Uc_HardwareInfo hardwareInfo;
        Uc_SystemInfo systemInfo;
        Uc_ViewLog viewLog;
        string name = string.Empty;
        private static LenovoMultipleClient _instance = null;
        private const int VM_NCLBUTTONDOWN = 0XA1;//定义鼠标左键按下

        public static LenovoMultipleClient GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new LenovoMultipleClient();
            }
            return _instance;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public LenovoMultipleClient()
        {
            InitializeComponent();
        }

        public void MainForm_Activated(object sender, EventArgs e)
        {
            //Close The exe
            HotKey.RegisterHotKey(Handle, 100, HotKey.KeyModifiers.Alt, Keys.C);
            // Restart the exe
            HotKey.RegisterHotKey(Handle, 102, HotKey.KeyModifiers.Alt, Keys.R);
            // Hide the exe
            HotKey.RegisterHotKey(Handle, 103, HotKey.KeyModifiers.Alt, Keys.H);
            // Show the exe
            HotKey.RegisterHotKey(Handle, 104, HotKey.KeyModifiers.Alt, Keys.S);
        }

        /// 
        /// 监视Windows消息
        /// 重载WndProc方法，用于实现热键响应
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            //按快捷键 
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    switch (m.WParam.ToInt32())
                    {
                        case 100:  //ALT + C
                            CommonFunction.KillProcess(CommonConstStr.OneToMoreClientName, true);
                            break;
                        case 102:  //ALT + R
                            CommonFunction.RunProcess(CommonConstStr.ExternalProcaseePath, "restartclient");
                            break;
                        case 103:  //ALT + H
                            this.Visible = !this.Visible;
                            break;
                        case 104:  //ALT + S
                            this.Visible = !this.Visible;
                            break;
                    }
                    break;
            }
            base.WndProc(ref m);
        }


        public void MainForm_Load(object sender, EventArgs e)
        {
            string ipAddress = CommonConstStr.CurrentMachneIp;
            CommonConstStr.CurrentMachneIp = ipAddress;
            CheckForIllegalCrossThreadCalls = false;
            hardwareInfo = new Uc_HardwareInfo();
            AddControlToPanelMid(hardwareInfo);

            CommonFunction.SetMeAutoStart();
            MethodInvoker threadInsertValue = new MethodInvoker(InsertCardValue);
            threadInsertValue.BeginInvoke(null, null);

        }

        public void BackgroundOnceTask()
        {
            //开机执行一次
            //var upgrade = new ThreadStart(AccessToUpgradeVersionResourcesTask.GetUpgradeClientsResourcesThread);//threadStart委托 
            //Thread upgradeThread = new Thread(upgrade);
            //upgradeThread.Priority = ThreadPriority.BelowNormal;
            //upgradeThread.IsBackground = true;
            //upgradeThread.Start();

            // 发送状态
            //Thread setStatusThread = new Thread(new ThreadStart(CommonFunction.ThreadSetStatus));
            //setStatusThread.Priority = ThreadPriority.BelowNormal;
            //setStatusThread.IsBackground = true;
            //setStatusThread.Start();
        }

        public void HideWin()
        {
            this.Visible = false;
        }

        private void InsertCardValue()
        {
            panelWidth = this.panelLeft.Width;
            name = Environment.UserName;
            this.nameLabel.Text = name + "  Ip: " + CommonConstStr.CurrentMachneIp;
            CommonFunction.RestartTestServer();

            // 在线升级 发送状态
            BackgroundOnceTask();

            // 接收指令
            CommonFunction.RunReceiveCommand();
            // 接收运行指令
            CommonFunction.RunTest();

        }

        public void timerMove_Tick(object sender, EventArgs e)
        {
            if (moveEnable)
            {
                panelLeft.Width += 10;
                if (panelLeft.Width >= panelWidth)
                {
                    this.timerMove.Stop();
                    moveEnable = false;
                    panelLeft.Width = 215;
                    this.Refresh();
                }
            }
            else
            {
                panelLeft.Width -= 10;
                if (panelLeft.Width <= 65)
                {
                    this.timerMove.Stop();
                    moveEnable = true;
                    panelLeft.Width = 65;
                    this.Refresh();
                }
            }
        }

        public void btn_home_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            MovePanelBtn(btn);
            if (sender == btn_home)
            {
                if (hardwareInfo == null)
                {
                    hardwareInfo = new Uc_HardwareInfo();
                    AddControlToPanelMid(hardwareInfo);
                    systemInfo = null;
                    viewLog = null;
                }
            }
            if (sender == btn_system)
            {
                if (systemInfo == null)
                {
                    systemInfo = new Uc_SystemInfo();
                    AddControlToPanelMid(systemInfo);
                    hardwareInfo = null;
                    viewLog = null;
                }
            }

            if (sender == btn_viewlog)
            {
                if (viewLog == null)
                {
                    viewLog = new Uc_ViewLog();
                    AddControlToPanelMid(viewLog);
                    hardwareInfo = null;
                    systemInfo = null;
                }
            }

        }
        //导航栏左侧-白panel
        public void MovePanelBtn(Control btn)
        {
            panel_button.Top = btn.Top;
            panel_button.Height = btn.Height;
        }

        //给中间Panel填充  自定义控件
        public void AddControlToPanelMid(Control ctrl)
        {
            ctrl.Dock = DockStyle.Fill;
            this.panel_mid.Controls.Clear();//清除中间Panel的内容
            this.panel_mid.Controls.Add(ctrl);//填充新的control
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage((IntPtr)this.Handle, VM_NCLBUTTONDOWN, HTCAPTION, 0);
        }
    }
}
