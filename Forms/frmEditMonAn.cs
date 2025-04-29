using QLBanHang.Classes;
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
    public partial class frmEditMonAn : Form
    {
        public static string QLaction = "";
        DataProcesser dtb_ma = new DataProcesser();
        public static DataGridViewRow _dgvr = new DataGridViewRow();
        
        public frmEditMonAn()
        {
            InitializeComponent();
            //_dgv = dgv;
            cboLoai.DataSource = dtb_ma.ReadData("Select * from LoaiMon");
            cboLoai.DisplayMember = "TenLoai";
            cboLoai.ValueMember = "MaLoai";
        }

        private void frmEditMonAn_Load(object sender, EventArgs e)
        {
            LoadData();
            
        }

        void LoadData()
        {
            if(QLaction == "Sửa")
            {
                //txtMaMon.Text = _dgv.CurrentRow.Cells[0].Value.ToString();
                //txtTenMon.Text = _dgv.CurrentRow.Cells[1].Value.ToString();
                ////cboLoai.DisplayMember = _dgvr.Cells[3].Value.ToString();
                //txtGia.Text = _dgv.CurrentRow.Cells[3].Value.ToString();

                txtMaMon.Text = _dgvr.Cells[0].Value.ToString();
                txtTenMon.Text = _dgvr.Cells[1].Value.ToString();
                //cboLoai.DisplayMember = _dgvr.Cells[3].Value.ToString();
                txtGia.Text = _dgvr.Cells[3].Value.ToString();

                btnOk.Text = "Sửa";
                txtMaMon.Enabled = false;
            }

            if(QLaction == "Thêm")
            {
                btnOk.Text = "Thêm";
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
