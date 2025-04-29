using QLBanHang.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace RestuarantManagement.Forms
{
    public partial class fmQlMonAn : Form
    {
        DataProcesser dtbase = new DataProcesser();
        string sql = "";
        string imagePath = "";

        public fmQlMonAn()
        {
            InitializeComponent();
           
           
        }

        private void fmQlMonAn_Load(object sender, EventArgs e)
        {
            LoadData();

            LoadLoaiMon(cboLoaiTK);

            //add mon
            DataTable tbLoaMon = dtbase.ReadData("select * from LoaiMon");
            cboLoai.DataSource = tbLoaMon;
            cboLoai.DisplayMember = "TenLoai";
            cboLoai.ValueMember = "MaLoai";


            //btnAnh.Enabled = false;
            //adminMonAn_btnXoa.Visible = false;
            adminMonAn_btnXoa.Enabled = false;

            //adminMonAn_btnLuu.Enabled = false;
            //adminMonAn_btnLuu.Visible = false;
            adminMonAn_btnLuu.Enabled = false;

            // adminMonAn_btnCapNhat.Enabled = false;
            //adminMonAn_btnCapNhat.Visible = false;
            adminMonAn_btnCapNhat.Enabled = false;
           
        }

        private void LoadLoaiMon(ComboBox cbo)
        {
            DataTable tbLoaMon = dtbase.ReadData("select * from LoaiMon");
            DataRow row;
            row = tbLoaMon.NewRow();
            row["TenLoai"] = "All";
            row["MaLoai"] = "0";
            tbLoaMon.Rows.InsertAt(row, 0);

            cbo.DataSource = tbLoaMon;
            cbo.DisplayMember = "TenLoai";
            cbo.ValueMember = "MaLoai";

            

        }

        private void LoaddgvMonAn()
        {
            //DataTable tbmonan = dtbase.ReadData("select MaMon 'Mã món', TenMon 'Tên món', LoaiMon 'Loại món', GiaThanh 'Giá' " +
            //    "from MonAn");

            //DataTable tbmonan = dtbase.ReadData("select MaMon, TenMon, LoaiMon , GiaThanh " +
            //    "from MonAn");

            DataTable tbmonan = dtbase.ReadData("select MaMon, TenMon, TenLoai, GiaThanh " +
                     "from MonAn join LoaiMon on MonAn.LoaiMon = LoaiMon.MaLoai");

            


            dgvMonAn.DataSource = tbmonan;

            //ten 
            dgvMonAn.Columns["MaMon"].HeaderText = "Mã món";
            dgvMonAn.Columns["TenMon"].HeaderText = "Tên món";
            //dgvMonAn.Columns["LoaiMon"].HeaderText = "Loại món";
            dgvMonAn.Columns["TenLoai"].HeaderText = "Loại món";
            dgvMonAn.Columns["GiaThanh"].HeaderText = "Giá bán";

            //fomat hàng nghìn cho giá bán
            dgvMonAn.Columns["GiaThanh"].DefaultCellStyle.Format = "C0";

        }

        void LoadData()
        {
            hide_button_Anh();

        }

        public bool emptyFiled()
        {
            if(txtMaMon.Text == "" || txtTenMon.Text == "" || cboLoai.SelectedIndex == -1 || txtGia.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string autostringkey()
        {
            Random random = new Random();
            string id = "";
            bool check = false;
            string strartCode = "MA";

            do
            {
                id = strartCode + random.Next(0, 1000).ToString();
                DataTable dtMA = dtbase.ReadData("select * from MonAn where MaMon = '" + id + "'" );
                if (dtMA.Rows.Count == 0)
                {
                    check = true;
                }
            }
            while (check == false);
            return id;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {

            //frmEditMonAn add = new frmEditMonAn();
            //frmEditMonAn.QLaction = "Thêm";
            //add.Show();

            txtMaMon.Text = autostringkey();
            //adminMonAn_btnLuu.Enabled = true;
            //adminMonAn_btnLuu.Visible = true;
            //adminMonAn_btnCapNhat.Visible = false;

            adminMonAn_btnLuu.Enabled = true;
            adminMonAn_btnCapNhat.Enabled = false;
            adminMonAn_btnXoa.Enabled = false;

            //anh
            show_button_Anh();


            //reset
            txtTenMon.Text = "";
            txtGia.Text = "";
            cboLoai.Text = "";
            pictureMA.Image = null;
            imagePath = "";
        }
     
        private void dgvMonAn_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            show_button_Anh();

            txtMaMon.Text = dgvMonAn.CurrentRow.Cells[0].Value.ToString();
            txtTenMon.Text = dgvMonAn.CurrentRow.Cells[1].Value.ToString();
            //cboLoai.SelectedValue = dgvMonAn.CurrentRow.Cells[2].Value.ToString();
            cboLoai.Text = dgvMonAn.CurrentRow.Cells[2].Value.ToString();
            float gia = float.Parse(dgvMonAn.CurrentRow.Cells[3].Value.ToString());
            //txtGia.Text = dgvMonAn.CurrentRow.Cells[3].Value.ToString();
            txtGia.Text = gia.ToString("N0");

            //int gia = int.Parse(txtGia.Text);
           // MessageBox.Show(gia.ToString());
            pictureMA.Image = null;

            

            sql = "select * " +
                "from MonAn where MaMon = '" + txtMaMon.Text + "'";
            DataTable dtMon = dtbase.ReadData(sql);

        

            if (dtMon.Rows[0]["HinhAnh"].ToString() != "")
            {
                imagePath= dtMon.Rows[0]["HinhAnh"].ToString();
                try
                {
                    pictureMA.Image = Image.FromFile(imagePath);
                }
                catch
                {
                    MessageBox.Show("Lỗi file ảnh");
                }
                
            }
            else
            {
                
            }

          

            adminMonAn_btnCapNhat.Enabled = true;
            adminMonAn_btnLuu.Enabled = false;
            adminMonAn_btnXoa.Enabled = true;
            

        }

        private void cboLoaiTK_SelectedIndexChanged(object sender, EventArgs e)
        {
            sql = "select MaMon 'Mã món', TenMon 'Tên món', LoaiMon 'Loại món', GiaThanh 'Giá' " +
               "from MonAn where LoaiMon = '" + cboLoaiTK.SelectedValue + "'";
            DataTable tbMonAn = dtbase.ReadData(sql);
            if (tbMonAn.Rows.Count > 0)
            {
                
                dgvMonAn.DataSource = tbMonAn;
            }
            else
            {
                LoaddgvMonAn();
            }
        }

        //Xu ly Anh
        private void hide_button_Anh()
        {
            adminMonAn_btnhuyAnh.Visible = false;
            adminMonAn_btnAnh.Visible=false;
        }

        private void show_button_Anh()
        {
            adminMonAn_btnhuyAnh.Visible = true;
            adminMonAn_btnAnh.Visible = true;
        }

        private void adminMonAn_btnAnh_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                //Application.StartupPath + "\\Images\\Hang\\" + imageName;
                //openFile.InitialDirectory = "E:\\C#_BL\\asset";
                openFile.InitialDirectory = Application.StartupPath + "\\MonAn";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    pictureMA.Image = Image.FromFile(openFile.FileName);
                    //luu duong dan anh
                    imagePath = openFile.FileName.ToString();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        //xoa anh
        private void btnhuyAnh_Click(object sender, EventArgs e)
        {
            if(pictureMA.Image != null)
            {
                pictureMA.Image = null;
                imagePath = null;
            }
            

        }

        private void adminMonAn_btnLuu_Click(object sender, EventArgs e)
        {
            //kiem tra update hay insert
            DataTable dtMonAn = dtbase.ReadData("select * from MonAn where MaMon = '" + txtMaMon.Text + "'");

            if(dtMonAn.Rows.Count <= 0)
            {
                if (emptyFiled())
                {
                    MessageBox.Show("Nhập đầy đủ thông tin món ăn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    sql = "insert into MonAn values('" + txtMaMon.Text + "',N'" + txtTenMon.Text + "','"
                        + cboLoai.SelectedValue + "'," + txtGia.Text + ",'" + imagePath + "')";

                    try
                    {
                        dtbase.ChangeData(sql);
                        LoaddgvMonAn();
                        MessageBox.Show("Luu thanh cong");
                        //reset 
                        txtMaMon.Text = "";
                        txtTenMon.Text = "";
                        txtGia.Text = "";
                        cboLoai.Text = "";
                        pictureMA.Image = null;
                        hide_button_Anh();

                        adminMonAn_btnLuu.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
            }

            
        }

        private void adminMonAn_btnCapNhat_Click(object sender, EventArgs e)
        {
            float gia = float.Parse(txtGia.Text);
            //MessageBox.Show(gia.ToString());

            sql = "update MonAn set TenMon = N'" + txtTenMon.Text + "', LoaiMon = '" + cboLoai.SelectedValue + "',"
                    + " GiaThanh = " + gia + ", " + "HinhAnh = '" + imagePath + "'"
                    + " where MaMon = '" + txtMaMon.Text + "'";

            try
            {
                dtbase.ChangeData(sql);
                resetValue();
                hide_button_Anh();
                //adminMonAn_btnhuyAnh.Enabled = false;
                //adminMonAn_btnXoa.Enabled = false;
                LoaddgvMonAn();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTK_TextChanged(object sender, EventArgs e)
        {
            sql = "select MaMon 'Mã món', TenMon 'Tên món', LoaiMon 'Loại món', GiaThanh 'Giá' " +
                "from MonAn where TenMon = N'" + txtTK.Text + "'";
            DataTable tbMonAn = dtbase.ReadData(sql);
            if (tbMonAn.Rows.Count > 0)
            {

                dgvMonAn.DataSource = tbMonAn;
            }
            else
            {
                LoaddgvMonAn();
                //dgvMonAn.Rows.Clear();
               
            }

            if (txtTK.Text == "")
            {
                LoaddgvMonAn();
            }
        }

        private void resetValue()
        {
            txtMaMon.Text = "";
            cboLoai.SelectedIndex = 0;
            txtTenMon.Text = "";
            txtGia.Text = "";
            pictureMA.Image = null;
        }
        private void adminMonAn_btnXoa_Click(object sender, EventArgs e)
        {
            sql = "delete from MonAn where MaMon = '" + txtMaMon.Text +"'";

            try
            {
                dtbase.ChangeData(sql);
                resetValue();
                hide_button_Anh();
                LoaddgvMonAn();

                //btn
                adminMonAn_btnXoa.Enabled = false;
                adminMonAn_btnLuu.Enabled = false;
                adminMonAn_btnCapNhat.Enabled = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
                
        }

        //check so 
        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if( !char.IsDigit(e.KeyChar) &&  !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Nhap so");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            - application: chương tình excel
           - workbook: file Excel
           - worksheet: tran tính tròng file excel , có nhiêù woorksheet trog workbook
           - range: ô excel 
            */

            Excel.Application exApp = new Excel.Application();
            Excel.Workbook ebook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet esheet = (Excel.Worksheet)ebook.Worksheets[1];
            Excel.Range exRange = (Excel.Range)esheet.Cells[1, 1];

            //chu de
            Excel.Range tieude = exRange.Range["B2:F2"];
            tieude.MergeCells =true;
            tieude.Font.Size = 20;
            tieude.Font.Bold = true;
            tieude.Font.Color = Color.Red;
            tieude.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            tieude.Value = "Danh sách món ăn";

            //tieu
            exRange.Range["B4:F4"].Font.Size = 13;
            exRange.Range["B4:F4"].Font.Bold = true;
            exRange.Range["B4"].Value = "STT";
            exRange.Range["C4"].Value = "Mã món";
            exRange.Range["C4"].ColumnWidth = 25;
            exRange.Range["D4"].Value = "Tên món";
            exRange.Range["D4"].ColumnWidth = 25;
            exRange.Range["E4"].Value = "Loại món";
            exRange.Range["E8"].ColumnWidth = 20;
            exRange.Range["F4"].Value = "Giá bán";

            //danh sach ma
            int hang = 5;
            for (int i = 0; i < dgvMonAn.Rows.Count - 1; i++)
            {
                exRange.Range["B" + (hang + i).ToString()].Value = (i + 1).ToString();
                exRange.Range["C" + (hang + i).ToString()].Value = dgvMonAn.Rows[i].Cells[0].Value.ToString();
                exRange.Range["D" + (hang + i).ToString()].Value = dgvMonAn.Rows[i].Cells[0].Value.ToString();
                exRange.Range["E" + (hang + i).ToString()].Value = dgvMonAn.Rows[i].Cells[0].Value.ToString();
                exRange.Range["F" + (hang + i).ToString()].Value = dgvMonAn.Rows[i].Cells[0].Value.ToString();
            }

            //ten trang tinh
            esheet.Name = "dsmonan";
            ebook.Activate();

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "Excel Workbook|*.xlsx|All Files| *.*";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                ebook.SaveAs(savefile.FileName.ToLower());
                MessageBox.Show("Luu thanh cong");
            }
            exApp.Quit();
        }

        private void dgvMonAn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
