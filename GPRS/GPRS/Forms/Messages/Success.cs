using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPRS.Forms.Messages
{
    public partial class Success : Form
    {
        
        public Success(string msg)
        {
            InitializeComponent();
            this.lbMessage.Text = msg;

            Rectangle r = this.ClientRectangle;

            int c = r.Width / 2;

            lbMessage.Location = new Point(c - lbMessage.Width / 2, lbMessage.Location.Y);

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Success_Load(object sender, EventArgs e)
        {

        }
    }
}
