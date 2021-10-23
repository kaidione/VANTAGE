using System;

namespace winformUI.UserControls
{
    partial class Uc_ViewLog
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        public System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Uc_ViewLog));
            this.fresh_btn = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.deleteAllLog = new System.Windows.Forms.Button();
            this.viewListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.download_btn = new System.Windows.Forms.Button();
            this.close_log_btn = new System.Windows.Forms.Button();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // fresh_btn
            // 
            this.fresh_btn.BackColor = System.Drawing.Color.OrangeRed;
            this.fresh_btn.FlatAppearance.BorderSize = 0;
            this.fresh_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fresh_btn.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fresh_btn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.fresh_btn.Image = ((System.Drawing.Image)(resources.GetObject("fresh_btn.Image")));
            this.fresh_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.fresh_btn.Location = new System.Drawing.Point(38, 327);
            this.fresh_btn.Margin = new System.Windows.Forms.Padding(2);
            this.fresh_btn.Name = "fresh_btn";
            this.fresh_btn.Size = new System.Drawing.Size(79, 39);
            this.fresh_btn.TabIndex = 12;
            this.fresh_btn.Text = "更新";
            this.fresh_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fresh_btn.UseVisualStyleBackColor = false;
            this.fresh_btn.Click += new System.EventHandler(this.fresh_btn_Click);
            // 
            // panel5
            // 
            this.panel5.AutoSize = true;
            this.panel5.Controls.Add(this.deleteAllLog);
            this.panel5.Controls.Add(this.viewListBox);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.download_btn);
            this.panel5.Controls.Add(this.close_log_btn);
            this.panel5.Controls.Add(this.fresh_btn);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(700, 389);
            this.panel5.TabIndex = 19;
            // 
            // deleteAllLog
            // 
            this.deleteAllLog.BackColor = System.Drawing.Color.Goldenrod;
            this.deleteAllLog.FlatAppearance.BorderSize = 0;
            this.deleteAllLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteAllLog.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteAllLog.ForeColor = System.Drawing.Color.White;
            this.deleteAllLog.Image = ((System.Drawing.Image)(resources.GetObject("deleteAllLog.Image")));
            this.deleteAllLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deleteAllLog.Location = new System.Drawing.Point(238, 327);
            this.deleteAllLog.Margin = new System.Windows.Forms.Padding(2);
            this.deleteAllLog.Name = "deleteAllLog";
            this.deleteAllLog.Size = new System.Drawing.Size(79, 39);
            this.deleteAllLog.TabIndex = 18;
            this.deleteAllLog.Text = "清空";
            this.deleteAllLog.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deleteAllLog.UseVisualStyleBackColor = false;
            this.deleteAllLog.Click += new System.EventHandler(this.deleteAllLog_Click);
            // 
            // viewListBox
            // 
            this.viewListBox.FormattingEnabled = true;
            this.viewListBox.ItemHeight = 19;
            this.viewListBox.Location = new System.Drawing.Point(38, 46);
            this.viewListBox.Margin = new System.Windows.Forms.Padding(2);
            this.viewListBox.Name = "viewListBox";
            this.viewListBox.Size = new System.Drawing.Size(625, 251);
            this.viewListBox.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(4, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(800, 1);
            this.label2.TabIndex = 16;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "本地系统日志服务";
            // 
            // download_btn
            // 
            this.download_btn.BackColor = System.Drawing.Color.Transparent;
            this.download_btn.FlatAppearance.BorderSize = 0;
            this.download_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.download_btn.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.download_btn.ForeColor = System.Drawing.Color.White;
            this.download_btn.Image = ((System.Drawing.Image)(resources.GetObject("download_btn.Image")));
            this.download_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.download_btn.Location = new System.Drawing.Point(606, 318);
            this.download_btn.Margin = new System.Windows.Forms.Padding(2);
            this.download_btn.Name = "download_btn";
            this.download_btn.Size = new System.Drawing.Size(57, 56);
            this.download_btn.TabIndex = 14;
            this.download_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.download_btn.UseVisualStyleBackColor = false;
            this.download_btn.Click += new System.EventHandler(this.download_btn_Click);
            // 
            // close_log_btn
            // 
            this.close_log_btn.BackColor = System.Drawing.Color.Green;
            this.close_log_btn.FlatAppearance.BorderSize = 0;
            this.close_log_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_log_btn.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close_log_btn.ForeColor = System.Drawing.Color.White;
            this.close_log_btn.Image = ((System.Drawing.Image)(resources.GetObject("close_log_btn.Image")));
            this.close_log_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.close_log_btn.Location = new System.Drawing.Point(138, 329);
            this.close_log_btn.Margin = new System.Windows.Forms.Padding(2);
            this.close_log_btn.Name = "close_log_btn";
            this.close_log_btn.Size = new System.Drawing.Size(79, 39);
            this.close_log_btn.TabIndex = 13;
            this.close_log_btn.Text = "详情";
            this.close_log_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.close_log_btn.UseVisualStyleBackColor = false;
            this.close_log_btn.Click += new System.EventHandler(this.close_log_btn_Click);
            // 
            // Uc_ViewLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel5);
            this.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Uc_ViewLog";
            this.Size = new System.Drawing.Size(700, 389);
            this.Load += new System.EventHandler(this.viewLog_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button fresh_btn;
        public System.Windows.Forms.Panel panel5;
        public System.Windows.Forms.Button close_log_btn;
        public System.Windows.Forms.Button download_btn;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.ListBox viewListBox;
        public System.Windows.Forms.Button deleteAllLog;
    }
}
