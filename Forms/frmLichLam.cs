
using QLBanHang.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace RestuarantManagement.Forms
{
    public partial class frmLichLam : Form
    {
        DataProcesser data = new DataProcesser();
        public frmLichLam()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Load_Data();
            DataTable dtNgay = data.ReadData("Select distinct (NgayLamViec) from LichLamViec");
            cbTimKiem.DataSource = dtNgay;
            cbTimKiem.DisplayMember = "NgayLamViec";

            DataTable dtID = data.ReadData("select MaNV from NhanVien");
            cbMaNV.DataSource = dtID;
            cbMaNV.DisplayMember = "MaNV";

            cbTimKiem.SelectedIndex = -1;
            //cbMaNV.SelectedIndex = -1;
            //txtTenNV.Text = "";
            //cbBoPhan.SelectedIndex = -1;

            btnLuu.Enabled = false;
        }
        public void Load_Data()
        {
            cbMaNV.SelectedIndex = -1;
            txtTenNV.Text = "";
            cbBoPhan.SelectedItem = -1;
            txtTenNV.Text = "";
            cbSang.Checked = false;
            cbChieu.Checked = false;
            cbToi.Checked = false;
            cbDem.Checked = false;
            cbFulltime.Checked = false;
            dtpNgayLam.Text = "";
        }
        public void Load_DGV()
        {
            DateTime ngayLam = dtpNgayLam.Value;
            //Load lai du lieu trong dgv
            //chuyen doi thanh dinh dang chuan yyyy-MM-dd 
            string chuyenNgay = ngayLam.ToString("yyyy-MM-dd");
            DataTable dtCaLam = data.ReadData(
               "SELECT NhanVien.MaNV,NhanVien.TenNV, NhanVien.BoPhan, " +
               "STRING_AGG(CaLam.TenCaLam, ', ') AS TenCaLam, " +
               "LichLamViec.NgayLamViec " +
               "FROM NhanVien " +
               "JOIN LichLamViec ON NhanVien.MaNV = LichLamViec.MaNV " +
               "JOIN CaLam ON CaLam.MaCaLam = LichLamViec.MaCaLam " +
               "GROUP BY NhanVien.MaNV,NhanVien.TenNV, NhanVien.BoPhan, LichLamViec.NgayLamViec " +
               "having NgayLamViec = '" + chuyenNgay + "'");

            dgvCaLam.DataSource = dtCaLam;
        }

        private void cbSang_CheckedChanged(object sender, EventArgs e)
        {
                    // Nếu bất kỳ CheckBox nào khác được chọn, bỏ chọn Full-time
                    if (cbSang.Checked || cbChieu.Checked || cbToi.Checked || cbDem.Checked)
                    {
                        cbFulltime.Checked = false;
                    }
        }
        private void cbFulltime_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFulltime.Checked)
            {
                // Nếu Full-time được chọn, bỏ chọn tất cả các CheckBox khác
                cbSang.Checked = false;
                cbChieu.Checked = false;
                cbToi.Checked = false;
                cbDem.Checked = false;
            }
        }
        

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            //lay gia tri comboBox -> kieu DateTime
            if (DateTime.TryParse(cbTimKiem.Text,out DateTime ngay))
            {
                //chuyen doi thanh dinh dang chuan yyyy-MM-dd 
                string chuyenNgay = ngay.ToString("yyyy-MM-dd");
                DataTable dtCaLam = data.ReadData(
                   "SELECT NhanVien.MaNV,NhanVien.TenNV, NhanVien.BoPhan, " +
                   "STRING_AGG(CaLam.TenCaLam, ', ') AS TenCaLam, " +
                   "LichLamViec.NgayLamViec " +
                   "FROM NhanVien " +
                   "JOIN LichLamViec ON NhanVien.MaNV = LichLamViec.MaNV " +
                   "JOIN CaLam ON CaLam.MaCaLam = LichLamViec.MaCaLam " +
                   "GROUP BY NhanVien.MaNV,NhanVien.TenNV, NhanVien.BoPhan, LichLamViec.NgayLamViec " +
                   "having NgayLamViec = '"+chuyenNgay+"'");

                dgvCaLam.DataSource = dtCaLam;
            }
        }

        private void dgvCaLam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //dtpNgayLam.Enabled = false;
            //cbMaNV.Enabled = false;
            //txtTenNV.Enabled = false;
            //cbBoPhan.Enabled = false;
            //cbSang.Enabled = false;
            //cbChieu.Enabled = false;
            //cbToi.Enabled = false;
            //cbDem.Enabled = false;
            //cbFulltime.Enabled = false;

            //cbSang.Checked = false;
            //cbChieu.Checked = false;
            //cbToi.Checked = false;
            //cbDem.Checked = false;
            //cbFulltime.Checked = false;
            Load_Data();

            DataTable dtID = data.ReadData("select MaNV from NhanVien");
            cbMaNV.DataSource = dtID;
            cbMaNV.DisplayMember = "MaNV";

            cbMaNV.Text = dgvCaLam.CurrentRow.Cells[0].Value.ToString();
            txtTenNV.Text = dgvCaLam.CurrentRow.Cells[1].Value.ToString();
            cbBoPhan.Text = dgvCaLam.CurrentRow.Cells[2].Value.ToString();
            dtpNgayLam.Text = dgvCaLam.CurrentRow.Cells[4].Value.ToString();
            string caLam = dgvCaLam.CurrentRow.Cells[3].Value.ToString();
            
            if (caLam.Contains("Sang"))
                cbSang.Checked = true;
            if (caLam.Contains("Chieu"))
                cbChieu.Checked = true;
            if (caLam.Contains("Toi"))
                cbToi.Checked = true;
            if (caLam.Contains("Dem"))
                cbDem.Checked = true;
            if (caLam.Contains("Full-time"))
                cbFulltime.Checked = true;
        }

        
        private void cbMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaNV.SelectedIndex != -1)
            {
                //MessageBox.Show(cbMaNV.Text);
                DataTable dtA = data.ReadData("select * from NhanVien where MaNV='" + cbMaNV.Text + "'");
                if (dtA.Rows.Count > 0)
                {
                    

                    txtTenNV.Text = dtA.Rows[0]["TenNV"].ToString();
                    cbBoPhan.Text = dtA.Rows[0]["BoPhan"].ToString();
                }
                

                cbSang.Checked = false;
                cbChieu.Checked = false;
                cbToi.Checked = false;
                cbDem.Checked = false;
                cbFulltime.Checked = false;
                DateTime ngayLam = dtpNgayLam.Value;

                DataTable dt = data.ReadData("select NhanVien.MaNV,TenNV,BoPhan,STRING_AGG(TenCaLam,',') as caLam,NgayLamViec " +
                    "from NhanVien join LichLamViec on NhanVien.MaNV = LichLamViec.MaNV " +
                    "join CaLam on CaLam.MaCaLam = LichLamViec.MaCaLam " +
                    "group by NhanVien.MaNV,TenNV,BoPhan,NgayLamViec " +
                    "having NgayLamViec = '" + ngayLam.ToString("yyyy/MM/dd") + "' and NhanVien.MaNV='" + cbMaNV.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    string caLam = dt.Rows[0]["caLam"].ToString();
                    if (caLam.Contains("Sang")) cbSang.Checked = true;
                    if (caLam.Contains("Chieu")) cbChieu.Checked = true;
                    if (caLam.Contains("Toi")) cbToi.Checked = true;
                    if (caLam.Contains("Dem")) cbDem.Checked = true;
                    if (caLam.Contains("Full-time")) cbFulltime.Checked = true;
                }
                else
                {
                    //MessageBox.Show("Nhan vien chua duoc phan ca lam!"); return;//////////////////////////////2 lan tbao
                }
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            //cbTimKiem.SelectedIndex = -1;
            //cbMaNV.SelectedIndex = -1;
            //cbBoPhan.SelectedItem = null;
            ////chon them ca lam chi hien thi nhan vien chua dc phan ca lam trong ngay
            DateTime ngayLam = dtpNgayLam.Value;
            DataTable dt = data.ReadData("select MaNV from NhanVien where MaNV not in (select MaNV from LichLamViec where NgayLamViec='" + ngayLam.ToString("yyyy/MM/dd") + "')");
            cbMaNV.DataSource = dt;
            cbMaNV.DisplayMember = "MaNV";

            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            //Load_Data();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //chi dc sua ca lam va ngay lam 
            //cbMaNV.Enabled = false;
            txtTenNV.Enabled = false;
            cbBoPhan.Enabled = false;

            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;

            //sua nhan vien co ca lam
            DateTime ngayLam = dtpNgayLam.Value;
            DataTable dt = data.ReadData("select distinct(MaNV) from LichLamViec where NgayLamViec='" + ngayLam.ToString("yyyy/MM/dd") + "' ");
            cbMaNV.DataSource = dt;
            cbMaNV.DisplayMember = "MaNV";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ban co muon xoa tat ca ca lam cua nhan vien '" + txtTenNV.Text + "' khong?","Thong bao",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                DateTime ngayLam = dtpNgayLam.Value;
                //xoa het tat ca ca lam cua nhan vien
                string sql = "delete from LichLamViec where MaNV='" + cbMaNV.Text + "' and NgayLamViec='" + ngayLam.ToString("yyyy/MM/dd") + "'";
                data.ChangeData(sql);
                MessageBox.Show("Xoa Ca Lam Thanh Cong");
            }
            Load_DGV();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            DateTime ngayLam = dtpNgayLam.Value;
            //====================================================Them============================================
            if (btnThem.Enabled==true)
            {
                //ktra dieu kien 
                if(cbSang.Checked==false&&cbChieu.Checked==false&&cbToi.Checked==false&&
                    cbDem.Checked==false&&cbFulltime.Checked==false)
                {
                    MessageBox.Show("Ban can chon 1 ca lam cho nhan vien");
                    return;
                }

                List<string> caLam = new List<string>();
                if (cbSang.Checked) caLam.Add("CL01");
                if (cbChieu.Checked) caLam.Add("CL02");
                if (cbToi.Checked) caLam.Add("CL03");
                if (cbDem.Checked) caLam.Add("CL04");
                if (cbFulltime.Checked) caLam.Add("CL05");

                foreach (string themCaLam in caLam)
                {
                    sql = "insert into LichLamViec values('" + cbMaNV.Text + "','" + themCaLam + "','" + ngayLam.ToString("yyyy/MM/dd") + "',4)";
                    data.ChangeData(sql);
                }
                MessageBox.Show("Them Ca Thanh Cong!");
                Load_Data();

                DataTable dtNgay = data.ReadData("Select distinct (NgayLamViec) from LichLamViec");
                cbTimKiem.DataSource = dtNgay;
                cbTimKiem.DisplayMember = "NgayLamViec";

                //load dgv
                Load_DGV();

                //cap nhat combobox manhanvien cho nhan vien chua dc phan ca
                DataTable dt = data.ReadData("select manv from nhanvien where manv not in (select manv from lichlamviec where ngaylamviec='" + ngayLam.ToString("yyyy/MM/dd") + "')");
                cbMaNV.DataSource = dt;
                cbMaNV.DisplayMember = "MaNV";
            }

            

            //=================================================SUA=======================================================
            if (btnSua.Enabled== true)
            {
                //xoa het ca lam cua nhan vien xog moi them ca lam vao
                sql = "delete from LichLamViec where MaNV='" + cbMaNV.Text + "' and NgayLamViec='"+ngayLam.ToString("yyyy/MM/dd")+"'";
                data.ChangeData(sql);

                //them ca lam moi
                List<string> caLam = new List<string>();
                if (cbSang.Checked) caLam.Add("CL01");
                if (cbChieu.Checked) caLam.Add("CL02");
                if (cbToi.Checked) caLam.Add("CL03");
                if (cbDem.Checked) caLam.Add("CL04");
                if (cbFulltime.Checked) caLam.Add("CL05");

                
                foreach (string themCaLam in caLam)
                {
                    sql = "insert into LichLamViec values('" + cbMaNV.Text + "','" + themCaLam + "','" + ngayLam.ToString("yyyy/MM/dd") + "',4)";
                    data.ChangeData(sql);
                }
                MessageBox.Show("Sua Ca Thanh Cong");

                //load dgv
                Load_DGV();

                
                DataTable dt = data.ReadData("select distinct(MaNV) from LichLamViec where NgayLamViec='" + ngayLam.ToString("yyyy/MM/dd") + "' ");
                cbMaNV.DataSource = dt;
                cbMaNV.DisplayMember = "MaNV";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //huy
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;

            cbMaNV.Enabled = true;
            txtTenNV.Enabled = true;
            cbBoPhan.Enabled = true;

            

            DataTable dtID = data.ReadData("select MaNV from NhanVien");
            cbMaNV.DataSource = dtID;
            cbMaNV.DisplayMember = "MaNV";

            Load_Data();
        }

        private void btnTimTenNV_Click(object sender, EventArgs e)
        {
            if (txtTimTenNV.Text.Trim() == "")
            {
                MessageBox.Show("Can nhap ten nhan vien");
            }
            else {
                DataTable dt = data.ReadData("select NhanVien.MaNV,TenNV,BoPhan,string_agg(TenCaLam,',') as caLam,NgayLamViec " +
                    "from NhanVien join LichLamViec on NhanVien.MaNV=LichLamViec.MaNV " +
                    "join CaLam on CaLam.MaCaLam=LichLamViec.MaCaLam " +
                    "Where upper(TenNV) = upper('" + txtTimTenNV.Text + "')" +
                    "group by NhanVien.MaNV,TenNV,BoPhan,NgayLamViec ");

                if (dt.Rows.Count > 0)
                {
                    dgvCaLam.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Khong co nhan vien");
                }
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            saveFileDialog.Title = "Chọn nơi lưu file Excel";
            saveFileDialog.FileName = "";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = false;

                Excel.Workbook workbook = excelApp.Workbooks.Add();
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];

                worksheet.Cells[1, 1] = "Mã Nhân Viên";
                worksheet.Cells[1, 2] = "Tên Nhân Viên";
                worksheet.Cells[1, 3] = "Ca Làm";
                worksheet.Cells[1, 4] = "Bộ Phận";
                worksheet.Cells[1, 5] = "Ngày Làm";

                int startRow = 2;
                foreach (DataGridViewRow row in dgvCaLam.Rows)
                {
                    worksheet.Cells[startRow, 1] = row.Cells["MaNV"].Value;      
                    worksheet.Cells[startRow, 2] = row.Cells["TenNV"].Value;    
                    worksheet.Cells[startRow, 3] = row.Cells["TenCaLam"].Value;   
                    worksheet.Cells[startRow, 4] = row.Cells["BoPhan"].Value;    
                    DateTime ngayLam = DateTime.Parse(dgvCaLam.CurrentRow.Cells["NgayLamViec"].Value.ToString());
                    worksheet.Cells[startRow, 5] = ngayLam.ToString("yyyy-MM-dd");
                    startRow++;
                }
                workbook.SaveAs(filePath);
                workbook.Close();
                excelApp.Quit();

                MessageBox.Show("Xuất file thành công đến " + filePath);
            }
            else
            {
                MessageBox.Show("Đã hủy lưu tệp.");
            }

        }
    }
}
