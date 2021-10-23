namespace winformUI.UserControls
{
    partial class Uc_HardwareInfo
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        public System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        public void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.currentStatus = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.shutdown_btn = new System.Windows.Forms.Button();
            this.getStatus = new System.Windows.Forms.Button();
            this.clearAndReboot = new System.Windows.Forms.Button();
            this.startbtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label2.Location = new System.Drawing.Point(132, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(104, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "当前状态";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label10.Location = new System.Drawing.Point(83, 39);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 26);
            this.label10.TabIndex = 5;
            this.label10.Text = "执行:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.currentStatus);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(22, 7);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(622, 85);
            this.panel1.TabIndex = 18;
            // 
            // currentStatus
            // 
            this.currentStatus.AutoSize = true;
            this.currentStatus.Location = new System.Drawing.Point(245, 46);
            this.currentStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currentStatus.Name = "currentStatus";
            this.currentStatus.Size = new System.Drawing.Size(40, 19);
            this.currentStatus.TabIndex = 2;
            this.currentStatus.Text = "Stop";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.shutdown_btn);
            this.panel4.Controls.Add(this.getStatus);
            this.panel4.Controls.Add(this.clearAndReboot);
            this.panel4.Controls.Add(this.startbtn);
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.btn_save);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Location = new System.Drawing.Point(22, 112);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(622, 264);
            this.panel4.TabIndex = 20;
            // 
            // shutdown_btn
            // 
            this.shutdown_btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.shutdown_btn.AutoSize = true;
            this.shutdown_btn.BackColor = System.Drawing.Color.OrangeRed;
            this.shutdown_btn.FlatAppearance.BorderSize = 0;
            this.shutdown_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shutdown_btn.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shutdown_btn.ForeColor = System.Drawing.Color.White;
            this.shutdown_btn.Location = new System.Drawing.Point(402, 180);
            this.shutdown_btn.Margin = new System.Windows.Forms.Padding(2);
            this.shutdown_btn.Name = "shutdown_btn";
            this.shutdown_btn.Size = new System.Drawing.Size(117, 47);
            this.shutdown_btn.TabIndex = 97;
            this.shutdown_btn.Text = "Shutdown";
            this.shutdown_btn.UseVisualStyleBackColor = false;
            this.shutdown_btn.Click += new System.EventHandler(this.shutdown_btn_Click);
            // 
            // getStatus
            // 
            this.getStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.getStatus.AutoSize = true;
            this.getStatus.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.getStatus.FlatAppearance.BorderSize = 0;
            this.getStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.getStatus.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getStatus.ForeColor = System.Drawing.Color.White;
            this.getStatus.Location = new System.Drawing.Point(286, 180);
            this.getStatus.Margin = new System.Windows.Forms.Padding(2);
            this.getStatus.Name = "getStatus";
            this.getStatus.Size = new System.Drawing.Size(92, 47);
            this.getStatus.TabIndex = 96;
            this.getStatus.Text = "SetStatus";
            this.getStatus.UseVisualStyleBackColor = false;
            this.getStatus.Click += new System.EventHandler(this.getStatus_Click);
            // 
            // clearAndReboot
            // 
            this.clearAndReboot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.clearAndReboot.AutoSize = true;
            this.clearAndReboot.BackColor = System.Drawing.Color.RoyalBlue;
            this.clearAndReboot.FlatAppearance.BorderSize = 0;
            this.clearAndReboot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearAndReboot.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearAndReboot.ForeColor = System.Drawing.Color.White;
            this.clearAndReboot.Location = new System.Drawing.Point(101, 180);
            this.clearAndReboot.Margin = new System.Windows.Forms.Padding(2);
            this.clearAndReboot.Name = "clearAndReboot";
            this.clearAndReboot.Size = new System.Drawing.Size(139, 47);
            this.clearAndReboot.TabIndex = 95;
            this.clearAndReboot.Text = "ClearAndReboot";
            this.clearAndReboot.UseVisualStyleBackColor = false;
            this.clearAndReboot.Click += new System.EventHandler(this.clearAndReboot_Click);
            // 
            // startbtn
            // 
            this.startbtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.startbtn.AutoSize = true;
            this.startbtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.startbtn.FlatAppearance.BorderSize = 0;
            this.startbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startbtn.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startbtn.ForeColor = System.Drawing.Color.White;
            this.startbtn.Location = new System.Drawing.Point(101, 116);
            this.startbtn.Margin = new System.Windows.Forms.Padding(2);
            this.startbtn.Name = "startbtn";
            this.startbtn.Size = new System.Drawing.Size(139, 47);
            this.startbtn.TabIndex = 94;
            this.startbtn.Text = "Start";
            this.startbtn.UseVisualStyleBackColor = false;
            this.startbtn.Click += new System.EventHandler(this.startbtn_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.AutoSize = true;
            this.button2.BackColor = System.Drawing.Color.OrangeRed;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(286, 116);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 47);
            this.button2.TabIndex = 93;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_save
            // 
            this.btn_save.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_save.AutoSize = true;
            this.btn_save.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_save.FlatAppearance.BorderSize = 0;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location = new System.Drawing.Point(402, 116);
            this.btn_save.Margin = new System.Windows.Forms.Padding(2);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(117, 47);
            this.btn_save.TabIndex = 92;
            this.btn_save.Text = "Rerun";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(22, 94);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(624, 1);
            this.label5.TabIndex = 34;
            this.label5.Text = "label5";
            // 
            // Uc_HardwareInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Uc_HardwareInfo";
            this.Size = new System.Drawing.Size(700, 389);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Button startbtn;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label currentStatus;
        public System.Windows.Forms.Button clearAndReboot;
        public System.Windows.Forms.Button getStatus;
        public System.Windows.Forms.Button shutdown_btn;
        public System.Windows.Forms.Label label5;
    }
}
