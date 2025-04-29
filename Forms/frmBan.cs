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
using System.Windows.Forms.VisualStyles;
using Excel = Microsoft.Office.Interop.Excel;
namespace RestuarantManagement.Forms
{
    public partial class frmBan : Form
    {
        DataProcesser process = new DataProcesser();
        string name = "";
        string manv = "NV0005";
        DataTable pr ;

        public frmBan()
        {
            InitializeComponent();
            LoadTrangThaiBan();
            LoadMonAnComBoBox();
            DataTable dt = process.ReadData("Select TenNV from NHANVIEN where MaNV ='NV0005'");
            name = "Xin chào ! "+dt.Rows[0]["TenNV"].ToString();
            
            txtTenDangNhap.Text = name;

        }

        // thêm các món ăn vào combobox
        private void LoadMonAnComBoBox()
        {
            DataTable dt = process.ReadData("select * from MonAn");
            cbMon.DataSource = dt;
            cbMon.DisplayMember = "TenMon";
            cbMon.ValueMember = "MaMon";
            cbMon.SelectedIndex = -1;

        }

        // thêm các bàn từ csdl lên giao diện 
        private void LoadTrangThaiBan()
        {
            DataTable dt = process.ReadData("select * from Ban");
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Lỗi!");
            }
            foreach (DataRow row in dt.Rows)
            {
                Button btnTable = new Button
                {
                    Text = row["TenBan"].ToString() + " \n" + row["TrangThai"].ToString(),
                    Width = 100,
                    Height = 100,
                    BackColor = row["TrangThai"].ToString() == "Còn trống" ? Color.LightGreen : Color.LightCoral,
                    Tag = row["MaBan"].ToString()
                };

                btnTable.Click += BtnTable_Click;
                flowLayoutPanel1.Controls.Add(btnTable);
            }
        }

        // sự kiện khi click vào bàn 
        private void BtnTable_Click(object sender, EventArgs e)
        {
            // xác định button nào được nhấp và cho phép truy cập vào tag , text
            Button clickedButton = sender as Button;
            //lấy id của bàn vừa click
            string tableId = clickedButton.Tag.ToString();

            //Lấy danh sách món ăn cho bàn
            string sql = "SELECT MonAn.TenMon, ChiTietHDB.SoLuong, ChiTietHDB.KhuyenMai,MonAn.GiaThanh, ChiTietHDB.ThanhTien " +
              "FROM HoaDonBan " +
              "JOIN ChiTietHDB ON ChiTietHDB.MaHDB = HoaDonBan.MaHDB " +
              "JOIN MonAn ON MonAn.MaMon = ChiTietHDB.MaMon " +
              "WHERE HoaDonBan.MaBan = '" + tableId + "'";

            DataTable dtOrder = process.ReadData(sql);


            dgvDanhSach.DataSource = dtOrder;
            //txtMaHoaDon.Text = dtOrder.Rows["OrderID"].ToString();

            decimal tongTien = 0;
            for (int i = 0; i < dtOrder.Rows.Count; i++)
            {
                tongTien = tongTien + decimal.Parse(dtOrder.Rows[i]["GiaThanh"].ToString());
            }
            txtTong.Text = tongTien.ToString();

            DataTable customer = process.ReadData("select * from HoaDonBan where MaBan = '" + tableId + "'");
            if (dtOrder.Rows.Count == 0)
            {
                // cập nhật lại trạng thái sau khi click 
                string updateban = "update Ban set TrangThai =N'Đang sử dụng' where MaBan ='" + tableId + "'";
                process.ChangeData(updateban);

                // set lại tên bàn từ trống thành đang sử dụng
                DataTable DT = process.ReadData("SELECT * FROM Ban where MaBan ='" + tableId + "'");
                clickedButton.BackColor = Color.LightCoral;
                clickedButton.Text = DT.Rows[0]["TenBan"].ToString() + " \n" + DT.Rows[0]["TrangThai"].ToString();

                /*  tạo mã hóa đơn tự động */
                TuDongTaoMaHD(tableId);



            }
            else
            {
                txtTenKhachHang.Text = customer.Rows[0]["TenKH"].ToString();
                txtSDT.Text = customer.Rows[0]["SDT"].ToString();
                txtMaHoaDon.Text = customer.Rows[0]["MaHDB"].ToString();
                txtMaHoaDon.Text = customer.Rows[0]["MaHDB"].ToString();
                txtBan.Text = clickedButton.Text;

            }
            btnIn.Enabled = true;
            btnThem.Enabled = true;
            btnLuu.Enabled = true;




        }

        // hàm tự động tạo mã hóa đơn
        private void TuDongTaoMaHD(string MabanCLick)
        {
            // Truy vấn mã hóa đơn lớn nhất hiện có
            string maxOrderIdQuery = "SELECT MAX(CAST(SUBSTRING(MaHDB, 4, LEN(MaHDB)) AS INT)) FROM HoaDonBan";
            DataTable dtMaxOrderId = process.ReadData(maxOrderIdQuery);

            // Tạo mã hóa đơn mới
            int newOrderId = 1; // Mã hóa đơn mặc định nếu chưa có hóa đơn nào

            if (dtMaxOrderId.Rows.Count > 0 && dtMaxOrderId.Rows[0][0] != DBNull.Value)
            {
                newOrderId = Convert.ToInt32(dtMaxOrderId.Rows[0][0]) + 1;
            }

            string newMaHDB = "HDB" + newOrderId.ToString("D3");

            // Chèn mã hóa đơn mới vào cơ sở dữ liệu
            string insertOrder = "INSERT INTO HoaDonBan (MaHDB, NgayBan, MaNV, TenKH, MaBan, TongTien, SDT) " +
                                 "VALUES ('" + newMaHDB + "', GETDATE(),'"+ manv +"' , '', '" + MabanCLick + "', 0, '')";
            process.ChangeData(insertOrder);

            // Hiển thị mã hóa đơn mới lên giao diện
            txtMaHoaDon.Text = newMaHDB;

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(Char.IsDigit(e.KeyChar) == false && Char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
                //MessageBox.Show("Hãy nhập số lượng là số !");
                //txtSoLuong.Focus();
            }
        }
        private void Reset()
        {
            txtBan.Text = "";
            //txtSoLuong.Text = "";
        }

       

        

        private void btnThem_Click(object sender, EventArgs e)
        {
           

            // lấy thông tin 

            if(cbMon.Text.ToString() == "" || txtTenKhachHang.Text.ToString() =="" || txtSDT.Text.ToString() == "")
            {
                MessageBox.Show("Nhap day du thong tin!");
                return;
            }

            string maHoaDon = txtMaHoaDon.Text;
            string maMon = cbMon.SelectedValue.ToString();
            int soLuong = int.Parse(numSoLuong.Value.ToString());
            string tenKhachHang = txtTenKhachHang.Text;
            string sdt = txtSDT.Text;
            decimal giamGia=0;

            if (txtGiamGia.Text.ToString() != "")
            {
                giamGia = decimal.Parse(txtGiamGia.Text);
            }


            // tính thành tiền 
            //MessageBox.Show(txtTong.Text.ToString());

            decimal tongTien = decimal.Parse(txtTong.Text.ToString());
            DataTable dtMonAn = process.ReadData("select GiaThanh from MonAn where MaMon = '" + maMon + "'");
            decimal giaThanh = dtMonAn.Rows.Count > 0 ? decimal.Parse(dtMonAn.Rows[0]["GiaThanh"].ToString()) : 0;
            decimal thanhTien=0;

            if (giamGia > 0)
            {
                thanhTien = soLuong * giaThanh * (1 - giamGia / 100);
                tongTien = tongTien + soLuong * giaThanh * (1 - giamGia / 100);
            }
            else
            {
                thanhTien = soLuong * giaThanh;
                tongTien = tongTien + soLuong * giaThanh;
            }


            //tong tien
            //decimal tongTien = decimal.Parse(txtTong.ToString());
            //tongTien = tongTien + soLuong * giaThanh * (1 - giamGia / 100);
            //txtTong.Text = tongTien.ToString();

            // thêm món ăn vào bảng chitiethdb

           

            string sqlInsertChiTietHDB = $"INSERT INTO ChiTietHDB (MaHDB, MaMon, SoLuong, KhuyenMai, ThanhTien) " + $"VALUES ('{maHoaDon}', '{maMon}', {soLuong}, {giamGia}, {thanhTien})";
            process.ChangeData(sqlInsertChiTietHDB);

            MessageBox.Show("Ok");

            // Cập nhật thông tin khách hàng trong bảng HoaDonBan
            string sqlUpdateHoaDonBan = $"UPDATE HoaDonBan SET TenKH = '{tenKhachHang}', SDT = '{sdt}',TongTien = {tongTien} WHERE MaHDB = '{maHoaDon}'"; 
            process.ChangeData(sqlUpdateHoaDonBan);

            // Cập nhật lại danh sách món ăn trong DataGridView
            string sqlOrder = $"SELECT MonAn.TenMon, ChiTietHDB.SoLuong, ChiTietHDB.KhuyenMai, ThucDon.GiaThanh,ChiTietHDB.ThanhTien " + $"FROM ChiTietHDB " + $"JOIN ThucDon ON MonAn.MaMon = ChiTietHDB.MaMon " + $"WHERE ChiTietHDB.MaHDB = '{maHoaDon}'"; 
            DataTable dtOrder = process.ReadData(sqlOrder); dgvDanhSach.DataSource = dtOrder;

           

            txtTong.Text = tongTien.ToString("N2"); // cập nhật tổng tiền ở txtTong



        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            
        }

        /* không được nhập chữ */
        private void txtGiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false && Char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
                MessageBox.Show("Hãy nhập giảm giá là số !");
                //txtSoLuong.Focus();
            }
        }

        /* xóa 1 món ăn khi nhấn vào 1 ô */
        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn xóa ?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dgvDanhSach.SelectedRows.Count > 0)
                {
                    //lấy thông tin từ dòng được chọn
                    DataGridViewRow selectedRow = dgvDanhSach.SelectedRows[0];
                    string maHoaDon = txtMaHoaDon.Text;
                    string tenMon = selectedRow.Cells["TenMon"].Value.ToString();

                    // lấy MaMon từ bảng thực đơn dựa vào tên món
                    DataTable dtMon = process.ReadData("select MaMon from MonAn where TenMon= N'" + tenMon + "'");
                    if (dtMon.Rows.Count > 0)
                    {
                        string maMon = dtMon.Rows[0]["MaMon"].ToString();

                        // xóa trong bảng chitietHdb
                        string sqlDelete = "delete from ChiTietHDB where MaHDB = '" + maHoaDon + "' and MaMon ='" + maMon + "'";
                        process.ReadData(sqlDelete);

                        // cập nhật lại dữ liệu trong datagriview
                        string sqlOrder = $"SELECT MonAn.TenMon, ChiTietHDB.SoLuong, ChiTietHDB.KhuyenMai, ChiTietHDB.ThanhTien "
                            + $"FROM HoaDonBan " + $"JOIN ChiTietHDB ON ChiTietHDB.MaHDB = HoaDonBan.MaHDB "
                            + $"JOIN MonAn ON MonAn.MaMon = ChiTietHDB.MaMon " + $"WHERE HoaDonBan.MaHDB = '{maHoaDon}'";
                        DataTable dtOrder = process.ReadData(sqlOrder);
                        dgvDanhSach.DataSource = dtOrder;

                        // tính lại tổng tiền hóa đơn
                        string sqlSum = $"SELECT SUM(ThanhTien) AS TongTien FROM ChiTietHDB WHERE MaHDB = '{maHoaDon}'";
                        DataTable dtSum = process.ReadData(sqlSum);
                        decimal tongTien = dtSum.Rows.Count > 0 && dtSum.Rows[0]["TongTien"] != DBNull.Value ? decimal.Parse(dtSum.Rows[0]["TongTien"].ToString()) : 0;

                        txtTong.Text = tongTien.ToString("N2"); // cập nhật tổng tiền ở txtTong

                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy món ăn ");
                    }


                }
                else
                {
                    MessageBox.Show("Hãy chọn 1 dòng để xóa");
                }
            }
            
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            string maHoaDon = txtMaHoaDon.Text;
            // Truy vấn danh sách món ăn từ cơ sở dữ liệu
            //string sqlQuery = $"SELECT MonAn.TenMon, ChiTietHDB.SoLuong, ChiTietHDB.KhuyenMai,MonAn.GiaThanh, ChiTietHDB.ThanhTien,HoaDonBan.TongTien " 
            //    + $"FROM ChiTietHDB " + $"JOIN MonAn ON MonAn.MaMon = ChiTietHDB.MaMon " + $"WHERE ChiTietHDB.MaHDB = '{maHoaDon}'";
            string sqlQuery = $"SELECT MonAn.TenMon, ChiTietHDB.SoLuong, ChiTietHDB.KhuyenMai,MonAn.GiaThanh, ChiTietHDB.ThanhTien "
                + $"FROM ChiTietHDB " + $"JOIN MonAn ON MonAn.MaMon = ChiTietHDB.MaMon " + $"WHERE ChiTietHDB.MaHDB = '{maHoaDon}'";
            DataTable pr = process.ReadData(sqlQuery);


            // có dữ liệu để ghi
            if (pr.Rows.Count > 0)
            {
                //Khai báo và khởi tạo các đối tượng
                Excel.Application exApp = new Excel.Application();
                Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];


                //Định dạng chung
                Excel.Range tenCuaHang = (Excel.Range)exSheet.Cells[1, 1];
                tenCuaHang.Font.Size = 12;
                tenCuaHang.Font.Bold = true;
                tenCuaHang.Font.Color = Color.Blue;
                tenCuaHang.Value = "Nhà Hàng Lớn  ";

                Excel.Range dcCuaHang = (Excel.Range)exSheet.Cells[2, 1];
                dcCuaHang.Font.Size = 12;
                dcCuaHang.Font.Bold = true;
                dcCuaHang.Font.Color = Color.Blue;
                dcCuaHang.Value = "Địa chỉ: Cầu Giấy - Hà Nội";

                Excel.Range dtCuaHang = (Excel.Range)exSheet.Cells[3, 1];
                dtCuaHang.Font.Size = 12;
                dtCuaHang.Font.Bold = true;
                dtCuaHang.Font.Color = Color.Blue;
                dtCuaHang.Value = "Điện thoại: 0999999999";

                Excel.Range header = (Excel.Range)exSheet.Cells[5, 2];
                exSheet.get_Range("B5:G5").Merge(true);
                header.Font.Size = 13;
                header.Font.Bold = true;
                header.Font.Color = Color.Red;
                header.Value = "DANH SÁCH CÁC MÓN ĂN";

                exSheet.get_Range("A7:G7").Font.Bold = true;
                exSheet.get_Range("A7:G7").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                exSheet.get_Range("A7").Value = "STT";
                exSheet.get_Range("B7").Value = "Tên Món";
                exSheet.get_Range("C7").Value = "Số Lượng";
                exSheet.get_Range("C7").ColumnWidth = 20;
                exSheet.get_Range("D7").Value = "Khuyến Mãi";
                exSheet.get_Range("E7").Value = "Giá Thành";
                exSheet.get_Range("F7").Value = "Thành Tiền";
                

                //In dữ liệu
                for (int i = 0; i < pr.Rows.Count; i++)
                {
                    exSheet.get_Range("A" + (i + 8).ToString() + ":G" + (i + 8).ToString()).Font.Bold = false;
                    exSheet.get_Range("A" + (i + 8).ToString()).Value = (i + 1).ToString();
                    exSheet.get_Range("B" + (i + 8).ToString()).Value = pr.Rows[i]["TenMon"].ToString();
                    exSheet.get_Range("C" + (i + 8).ToString()).Value = pr.Rows[i]["SoLuong"].ToString();
                    exSheet.get_Range("D" + (i + 8).ToString()).Value = pr.Rows[i]["KhuyenMai"].ToString();
                    exSheet.get_Range("E" + (i + 8).ToString()).Value = pr.Rows[i]["GiaThanh"].ToString();
                    exSheet.get_Range("F" + (i + 8).ToString()).Value = pr.Rows[i]["ThanhTien"].ToString();

                }
                exSheet.Name = "Hang";
                exBook.Activate(); //Kích hoạt file Excel 
                                   //Thiết lập các thuộc tính của SaveFileDialog 
                saveFileDialog.Filter = "Excel Document(*.xls)|*.xls  |Word Document(*.doc) | *.doc | All files(*.*) | *.* ";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.AddExtension = true;
                saveFileDialog.DefaultExt = ".xls";
                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    exBook.SaveAs(saveFileDialog.FileName.ToString());//Lưu file Excel 
                exApp.Quit();//Thoát khỏi ứng dụng 

            }
            else
            {
                MessageBox.Show("Không có danh sách để in");
            }
        }

        private void frmBan_Load(object sender, EventArgs e)
        {

        }
    }
}
