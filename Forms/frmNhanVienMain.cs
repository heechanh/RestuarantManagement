using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestuarantManagement.Forms
{
    public partial class frmNhanVienMain : Form
    {
        public frmNhanVienMain()
        {
            InitializeComponent();
        }

        private void btnMonAn_Click(object sender, EventArgs e)
        {
            fmQlMonAn qlma = new fmQlMonAn();
            qlma.TopLevel = false;
            qlma.Dock = DockStyle.Fill;
            qlma.FormBorderStyle = FormBorderStyle.None;

            ControlsPanel.Controls.Clear();
            ControlsPanel.Controls.Add(qlma);
            qlma.Show();
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            frmBan fBan = new frmBan();
            fBan.TopLevel = false;
            fBan.Dock = DockStyle.Fill;
            fBan.FormBorderStyle = FormBorderStyle.None;

            ControlsPanel.Controls.Clear();
            ControlsPanel.Controls.Add(fBan);
            fBan.Show();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            frmHoaDon fhoadon = new frmHoaDon();
            fhoadon.TopLevel = false;
            fhoadon.Dock = DockStyle.Fill;
            fhoadon.FormBorderStyle = FormBorderStyle.None;

            ControlsPanel.Controls.Clear();
            ControlsPanel.Controls.Add(fhoadon);
            fhoadon.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ControlsPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
