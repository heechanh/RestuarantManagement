using RestuarantManagement;
using RestuarantManagement.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestuarantManagement.Forms
{
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
            Instance = this;
        }

        public frmMain Instance { get; }


        //Methood to add Controls in Main Form
        public void AddControls(Form f) //public static
        {
            ControlsPanel.Controls.Clear();  
            //f.Dock = DockStyle.Fill;
            //f.TopLevel = false;
            //ControlsPanel.Controls.Add(f);
            //f.Show();
        }
        

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            lblUser.Text = Program.maNV;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            //AddControls(new frmHome());
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            //frmNhanVien frm = new frmNhanVien();
            StaffManagement frmNv = new StaffManagement();
            frmNv.TopLevel = false;
            frmNv.FormBorderStyle = FormBorderStyle.None;

            ControlsPanel.Controls.Clear();
            ControlsPanel.Controls.Add(frmNv);
            frmNv.Show();
           
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

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            frmThongKe thongKe = new frmThongKe();
            thongKe.TopLevel = false;
            thongKe.Dock = DockStyle.Fill;
            thongKe.FormBorderStyle = FormBorderStyle.None;

            ControlsPanel.Controls.Clear();
            ControlsPanel.Controls.Add(thongKe);
            thongKe.Show();
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

        private void frmMain_Load_1(object sender, EventArgs e)
        {

        }

        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            frmLichLam frmLichLam = new frmLichLam();
            frmLichLam.TopLevel = false;
            frmLichLam.Dock = DockStyle.Fill;
            frmLichLam.FormBorderStyle = FormBorderStyle.None;

            ControlsPanel.Controls.Clear();
            ControlsPanel.Controls.Add(frmLichLam);
            frmLichLam.Show();
        }
    }
}
