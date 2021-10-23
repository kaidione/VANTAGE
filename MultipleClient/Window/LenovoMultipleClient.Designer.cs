using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using winformUI.Common;

namespace winformUI
{
    partial class LenovoMultipleClient
    {
        public static LenovoMultipleClient MainFormSingle = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LenovoMultipleClient));
            this.panelLeft = new System.Windows.Forms.Panel();
            this.btn_viewlog = new System.Windows.Forms.Button();
            this.btn_system = new System.Windows.Forms.Button();
            this.panel_button = new System.Windows.Forms.Panel();
            this.btn_home = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.version = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.timerMove = new System.Windows.Forms.Timer(this.components);
            this.panel_mid = new System.Windows.Forms.Panel();
            this.panelLeft.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.panelLeft.Controls.Add(this.btn_viewlog);
            this.panelLeft.Controls.Add(this.btn_system);
            this.panelLeft.Controls.Add(this.panel_button);
            this.panelLeft.Controls.Add(this.btn_home);
            this.panelLeft.Controls.Add(this.panel3);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(145, 473);
            this.panelLeft.TabIndex = 0;
            this.panelLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // btn_viewlog
            // 
            this.btn_viewlog.AutoSize = true;
            this.btn_viewlog.FlatAppearance.BorderSize = 0;
            this.btn_viewlog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_viewlog.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_viewlog.ForeColor = System.Drawing.Color.White;
            this.btn_viewlog.Image = ((System.Drawing.Image)(resources.GetObject("btn_viewlog.Image")));
            this.btn_viewlog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_viewlog.Location = new System.Drawing.Point(11, 225);
            this.btn_viewlog.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_viewlog.Name = "btn_viewlog";
            this.btn_viewlog.Size = new System.Drawing.Size(191, 46);
            this.btn_viewlog.TabIndex = 8;
            this.btn_viewlog.Text = "  日志信息";
            this.btn_viewlog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_viewlog.UseVisualStyleBackColor = true;
            this.btn_viewlog.Click += new System.EventHandler(this.btn_home_Click);
            // 
            // btn_system
            // 
            this.btn_system.AutoSize = true;
            this.btn_system.FlatAppearance.BorderSize = 0;
            this.btn_system.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_system.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_system.ForeColor = System.Drawing.Color.White;
            this.btn_system.Image = ((System.Drawing.Image)(resources.GetObject("btn_system.Image")));
            this.btn_system.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_system.Location = new System.Drawing.Point(6, 144);
            this.btn_system.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_system.Name = "btn_system";
            this.btn_system.Size = new System.Drawing.Size(199, 54);
            this.btn_system.TabIndex = 4;
            this.btn_system.Text = "  系统信息";
            this.btn_system.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_system.UseVisualStyleBackColor = true;
            this.btn_system.Click += new System.EventHandler(this.btn_home_Click);
            // 
            // panel_button
            // 
            this.panel_button.BackColor = System.Drawing.Color.White;
            this.panel_button.Location = new System.Drawing.Point(2, 78);
            this.panel_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel_button.Name = "panel_button";
            this.panel_button.Size = new System.Drawing.Size(1, 46);
            this.panel_button.TabIndex = 0;
            // 
            // btn_home
            // 
            this.btn_home.AutoSize = true;
            this.btn_home.FlatAppearance.BorderSize = 0;
            this.btn_home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_home.Font = new System.Drawing.Font("Georgia", 10.2F);
            this.btn_home.ForeColor = System.Drawing.Color.White;
            this.btn_home.Image = ((System.Drawing.Image)(resources.GetObject("btn_home.Image")));
            this.btn_home.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_home.Location = new System.Drawing.Point(14, 78);
            this.btn_home.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_home.Name = "btn_home";
            this.btn_home.Size = new System.Drawing.Size(191, 46);
            this.btn_home.TabIndex = 3;
            this.btn_home.Text = "  执行信息";
            this.btn_home.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_home.UseVisualStyleBackColor = true;
            this.btn_home.Click += new System.EventHandler(this.btn_home_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(145, 74);
            this.panel3.TabIndex = 2;
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 71);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(145, 2);
            this.panel1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "BJ Automation OneToMoreClient";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(145, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(711, 23);
            this.panel2.TabIndex = 1;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "usernobinding.png");
            this.imageList1.Images.SetKeyName(1, "userbinding.png");
            this.imageList1.Images.SetKeyName(2, "oempic.png");
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.version);
            this.panel4.Controls.Add(this.nameLabel);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(145, 23);
            this.panel4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(711, 51);
            this.panel4.TabIndex = 2;
            this.panel4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.Font = new System.Drawing.Font("Cambria", 12F);
            this.version.ForeColor = System.Drawing.Color.White;
            this.version.Location = new System.Drawing.Point(557, 16);
            this.version.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(112, 19);
            this.version.TabIndex = 14;
            this.version.Text = "Version: 1.10.4";
            this.version.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.ForeColor = System.Drawing.Color.White;
            this.nameLabel.Location = new System.Drawing.Point(64, 16);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(0, 19);
            this.nameLabel.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(-4, 16);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "Welcome:";
            // 
            // timerMove
            // 
            this.timerMove.Tick += new System.EventHandler(this.timerMove_Tick);
            // 
            // panel_mid
            // 
            this.panel_mid.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_mid.Location = new System.Drawing.Point(145, 74);
            this.panel_mid.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel_mid.Name = "panel_mid";
            this.panel_mid.Size = new System.Drawing.Size(700, 399);
            this.panel_mid.TabIndex = 10;
            this.panel_mid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // LenovoMultipleClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(856, 473);
            this.Controls.Add(this.panel_mid);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelLeft);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "LenovoMultipleClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LenovoMultipleClient";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PNTop_MouseDown);
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }


        #region 让窗体变成可移动
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        [DllImport("User32.dll")]
        public static extern IntPtr WindowFromPoint(Point p);

        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        public IntPtr moveObject = IntPtr.Zero;    //拖动窗体的句柄

        public void PNTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (moveObject == IntPtr.Zero)
            {
                if (this.Parent != null)
                {
                    moveObject = this.Parent.Handle;
                }
                else
                {
                    moveObject = this.Handle;
                }
            }
            ReleaseCapture();
            SendMessage(moveObject, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        #endregion


        #endregion

        public System.Windows.Forms.Panel panelLeft;
        public System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button btn_home;
        public System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Panel panel_button;
        public System.Windows.Forms.Button btn_viewlog;
        public System.Windows.Forms.Button btn_system;
        public System.Windows.Forms.Label nameLabel;
        public System.Windows.Forms.Timer timerMove;
        public System.Windows.Forms.Panel panel_mid;
        public System.Windows.Forms.Label label1;
        private System.ComponentModel.IContainer components;
        public ImageList imageList1;
        private Panel panel1;
        private Label version;
        public Label label6;
    }
}