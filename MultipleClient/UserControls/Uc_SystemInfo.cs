using System;
using System.Drawing;
using System.Windows.Forms;
using winformUI.Common;

namespace winformUI.UserControls
{
    public partial class Uc_SystemInfo : UserControl
    {
        MachineInformation machine;
        public Uc_SystemInfo()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            machine = CommonFunction.GetSystemInformation();
        }

        public void Uc_Sales_Load(object sender, EventArgs e)
        {
            try
            {
                this.label7.Text = machine.ComputerName;
                this.label7.Location = new Point(this.label3.Location.X + this.label3.Width, this.label3.Location.Y);
                this.label9.Text = machine.OS;
                this.label9.Location = new Point(this.label6.Location.X + this.label6.Width, this.label6.Location.Y);
                this.label22.Text = machine.Family;
                this.label22.Location = new Point(this.label12.Location.X + this.label12.Width, this.label12.Location.Y);
            }
            catch (Exception ex)
            {
            }
        }

    }
}
