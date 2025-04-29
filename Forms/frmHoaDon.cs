using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using TestPhanCa;
using RestuarantManagement.Forms;
using QLBanHang.Classes;

namespace RestuarantManagement.Forms
{
    public partial class frmHoaDon : Form
    {
        DataProcesser data = new DataProcesser();
        string date = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
        public frmHoaDon()
        {
            InitializeComponent();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParse(cbTimNgay.Text, out DateTime ngayBan)) {
                DataTable dtHoaDon = data.ReadData("select MaHDB,TenBan,TongTien,NgayBan " +
                    "from HoaDonBan join Ban on HoaDonBan.MaBan=Ban.MaBan where NgayBan='" + ngayBan.ToString("yyyy/MM/dd") + "'");
                dgvHoaDon.DataSource = dtHoaDon;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dtHoaDon = data.ReadData("select MaHDB,TenBan,TongTien,NgayBan " +
                "from HoaDonBan join Ban on HoaDonBan.MaBan=Ban.MaBan where NgayBan>='"+date+"'");
            dgvHoaDon.DataSource = dtHoaDon;

            
            DataTable dtNgay = data.ReadData("select distinct(NgayBan) from HoaDonBan where NgayBan>='"+date+"'");
            cbTimNgay.DataSource = dtNgay;
            cbTimNgay.DisplayMember = "NgayBan";

            DataTable dtNV = data.ReadData("select ManV from NhanVien");
            cbMaNV.DataSource = dtNV;
            cbMaNV.DisplayMember = "MaNV";

            DataTable dtBan = data.ReadData("select * from Ban");
            cbTenBan.DataSource = dtBan;
            cbTenBan.DisplayMember = "TenBan";

            DataTable dtMon = data.ReadData("select * from MonAn");
            cbMaMon.DataSource = dtMon;
            cbMaMon.DisplayMember = "MaMon";
        }
        private void cbMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(cbMaNV.Text);
            DataTable dtMaNV = data.ReadData("select TenNV from NhanVien where MaNV='" + cbMaNV.Text + "'");

            if (dtMaNV.Rows.Count > 0)
            {


                txtTenNV.Text = dtMaNV.Rows[0]["TenNV"].ToString();
            }
        }

        private void cbMaMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtMaNV = data.ReadData("select TenMon,GiaThanh from MonAn where MaMon='" + cbMaMon.Text + "'");

            if (dtMaNV.Rows.Count > 0)
            {


                txtTenMon.Text = dtMaNV.Rows[0]["TenMon"].ToString();
                txtDonGia.Text = dtMaNV.Rows[0]["GiaThanh"].ToString();
            }


        }
        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbTenBan.Text = dgvHoaDon.CurrentRow.Cells[1].Value.ToString();
            txtTongTien.Text = dgvHoaDon.CurrentRow.Cells[2].Value.ToString();
            dtpNgay.Text = dgvHoaDon.CurrentRow.Cells[3].Value.ToString();

            string HDB = dgvHoaDon.CurrentRow.Cells[0].Value.ToString();
            DataTable dt = data.ReadData("select MaHDB,TenKH,HoaDonBan.SDT,NhanVien.MaNV,TenNV from HoaDonBan join NhanVien on HoaDonBan.MaNV = NhanVien.MaNV where MaHDB='"+HDB+"'");
            txtMaHDB.Text = dt.Rows[0]["MaHDB"].ToString();
            txtTenKH.Text = dt.Rows[0]["TenKH"].ToString();
            txtSDT.Text = dt.Rows[0]["SDT"].ToString();
            cbMaNV.Text = dt.Rows[0]["MaNV"].ToString();
            txtTenNV.Text = dt.Rows[0]["TenNV"].ToString();

            DataTable monAn = data.ReadData("select MonAn.MaMon,TenMon,GiaThanh,SoLuong,KhuyenMai,ThanhTien from ChiTietHDB join MonAn on ChiTietHDB.MaMon=MonAn.MaMon where MaHDB='" + txtMaHDB.Text + "'");
            dgvMonAn.DataSource = monAn;
        }

        private void dgvMonAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbMaMon.Text = dgvMonAn.CurrentRow.Cells[0].Value.ToString();
            txtTenMon.Text = dgvMonAn.CurrentRow.Cells[1].Value.ToString();
            txtDonGia.Text = dgvMonAn.CurrentRow.Cells[2].Value.ToString();
            txtSL.Text = dgvMonAn.CurrentRow.Cells[3].Value.ToString();
            txtGiamGia.Text = dgvMonAn.CurrentRow.Cells[4].Value.ToString();
            txtThanhTien.Text = dgvMonAn.CurrentRow.Cells[5].Value.ToString();
        }
        private void TinhThanhTien()
        {
            if (!string.IsNullOrEmpty(txtSL.Text) &&
            !string.IsNullOrEmpty(txtGiamGia.Text) &&
            !string.IsNullOrEmpty(txtDonGia.Text))
            {
                int soLuong;
                double giamGia, donGia, thanhTien;

                soLuong = int.Parse(txtSL.Text);
                giamGia = double.Parse(txtGiamGia.Text);
                donGia = double.Parse(txtDonGia.Text);
                thanhTien = soLuong * donGia * (1 - giamGia / 100);
                txtThanhTien.Text = thanhTien.ToString("F2");
            }
            else
            {
                txtThanhTien.Text = "";
            }

            if (txtSL.Text.ToString() != "")
            {
                //if (Int32.Parse(txtGiamGia.Text) == 0)
                if (txtGiamGia.Text == "" || Int32.Parse(txtGiamGia.Text) == 0)
                {
                    float thanhtien = Convert.ToInt32(txtSL.Text) * float.Parse(txtDonGia.Text);
                    txtThanhTien.Text = thanhtien.ToString();
                }
                else
                {
                    float thanhtien = Convert.ToInt32(txtSL.Text) * float.Parse(txtDonGia.Text);
                    float giamgia = float.Parse(txtGiamGia.Text) / 100;
                    txtThanhTien.Text = (thanhtien - giamgia * thanhtien).ToString();
                }
            }
            else txtThanhTien.Text = "0";
        }
        private void txtSL_TextChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }
        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }
        private void txtGiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //sua
            string sql;
            DateTime ngay = dtpNgay.Value;
            DataTable dtBan = data.ReadData("select * from Ban where TenBan=N'"+cbTenBan.Text+"'");
            string maBan = dtBan.Rows[0]["MaBan"].ToString();

            sql = "update HoaDonBan set NgayBan='" + ngay.ToString("yyyy/MM/dd") + "'," +
                "MaNV='"+cbMaNV.Text+"',TenKH=N'"+txtTenKH.Text+"',MaBan='"+maBan+"',SDT='"+txtSDT.Text+"' where MaHDB='"+txtMaHDB.Text+"'";
            data.ChangeData(sql);
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            if(txtGiamGia.Text.ToString() == "")
            {
                txtGiamGia.Text = "0";
            }
            sql = "update ChiTietHDB set SoLuong=" + int.Parse(txtSL.Text) + ",KhuyenMai=" + double.Parse(txtGiamGia.Text)+ ",ThanhTien="+ double.Parse(txtThanhTien.Text)+" where MaHDB='"+txtMaHDB.Text+ "' and MaMon='"+ cbMaMon.Text + "'";
            data.ChangeData(sql);



            //DataTable dtTongTien =data.ReadData("select sum(ThanhTien) as Tong from ChiTietHDB where MaHDB='" + txtMaHDB.Text + "'");
            //string tongtien = dtTongTien.Rows[0]["Tong"].ToString();

            decimal tongtien = decimal.Parse(txtTongTien.Text.ToString()) + decimal.Parse(txtThanhTien.Text.ToString());

            sql = "update HoaDonBan set TongTien=" + double.Parse(tongtien.ToString()) + " where MaHDB='"+txtMaHDB.Text+"'";
            data.ChangeData(sql);
            txtTongTien.Text = tongtien.ToString();

            DataTable dtHoaDon = data.ReadData("select MaHDB,TenBan,TongTien,NgayBan " +
                "from HoaDonBan join Ban on HoaDonBan.MaBan=Ban.MaBan where NgayBan>='"+date+"'");
            dgvHoaDon.DataSource = dtHoaDon;

            DataTable monAn = data.ReadData("select MonAn.MaMon,TenMon,GiaThanh,SoLuong,KhuyenMai,ThanhTien from ChiTietHDB join MonAn on ChiTietHDB.MaMon=MonAn.MaMon where MaHDB='" + txtMaHDB.Text + "'");
            dgvMonAn.Rows.Clear();
            dgvMonAn.DataSource = monAn;
        }


        private void dgvMonAn_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //xoa 1 mon an
            if (MessageBox.Show("Ban co muon xoa mon an nay khong?","Thong bao",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                string sql = "delete from ChiTietHDB where MaHDB='" + txtMaHDB.Text + "' and MaMon='"+cbMaMon.Text+"'";
                data.ChangeData(sql);

                double ThanhTien, TongTien;
                ThanhTien = double.Parse(dgvMonAn.CurrentRow.Cells[5].Value.ToString());
                TongTien = double.Parse(txtTongTien.Text) - ThanhTien;
                data.ChangeData("update HoaDonBan set TongTien=" + TongTien + " where MaHDB='" + txtMaHDB.Text + "'");
                txtTongTien.Text = TongTien.ToString();

                DataTable dtHoaDon = data.ReadData("select MaHDB,TenBan,TongTien,NgayBan " +
                "from HoaDonBan join Ban on HoaDonBan.MaBan=Ban.MaBan where NgayBan>='"+date+"'");
                dgvHoaDon.DataSource = dtHoaDon;

                DataTable monAn = data.ReadData("select MonAn.MaMon,TenMon,GiaThanh,SoLuong,KhuyenMai,ThanhTien from ChiTietHDB join MonAn on ChiTietHDB.MaMon=MonAn.MaMon where MaHDB='" + txtMaHDB.Text + "'");
                dgvMonAn.DataSource = monAn;
            }
        }

        private void dgvHoaDon_DoubleClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ban co muon xoa hoa don nay khong?", "Thong bao", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                data.ChangeData("delete from ChiTietHDB where MaHDB='" + txtMaHDB.Text + "'");
                data.ChangeData("delete from HoaDonBan where MaHDB='" + txtMaHDB.Text + "'");
            }
            DataTable dtHoaDon = data.ReadData("select MaHDB,TenBan,TongTien,NgayBan " +
                "from HoaDonBan join Ban on HoaDonBan.MaBan=Ban.MaBan where NgayBan>='"+date+"'");
            dgvHoaDon.DataSource = dtHoaDon;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if(txtTimBan.Text.Trim()=="")
            {
                MessageBox.Show("Ban can nhap ten ban");
            }
            else
            {
                DataTable dt =data.ReadData("select MaHDB,TenBan,TongTien,NgayBan from HoaDonBan join Ban on HoaDonBan.MaBan=Ban.MaBan " +
                    "where upper(TenBan)=upper(N'"+txtTimBan.Text+"')");
                if (dt.Rows.Count > 0)
                {
                    dgvHoaDon.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Khong co ban");
                }
            }
        }
    }
}
