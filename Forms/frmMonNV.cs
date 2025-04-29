
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

namespace RestuarantManagement
{
    public partial class fmMonAn : Form
    {
        DataProcesser dtbase = new DataProcesser();
        string image = "";
        DataTable tborder = new DataTable();

        public fmMonAn()
        {
            InitializeComponent();

            //txtTenM.Text = "Tìm kiếm món ăn";
            //txtTenM.ForeColor = Color.Gray;
            ////do du lieu
            cboLoai.DataSource = dtbase.ReadData("select * from LoaiMon");
            cboLoai.DisplayMember = "TenLoai";
            cboLoai.ValueMember = "MaLoai";

            tborder.Columns.Add("Mon An", Type.GetType("System.String"));
            tborder.Columns.Add("Don Gia", Type.GetType("System.Double"));


        }

        private void Form1_Load(object sender, EventArgs e)
        {

            LoadData();
            lblTotal.Text = "0";

        }

        void AddBiding()
        {
            //txtPrice.DataBindings.Add(new Binding("Text", comboBox1.DataSource, "price"));

            //lấy price từ datasource để gắn với thuộc tính Text của txtPrice 
        }

        void LoadData()
        { 

            DataTable dtmonan = dtbase.ReadData("select * from [dbo].[MonAn]");
            dataGridView1.DataSource = tborder;

            //MessageBox.Show(dtHang.Rows.Count.ToString());
            foreach (DataRow dr in dtmonan.Rows)
            {
                //Button btn = new Button();
                //btn.Text = dr[1].ToString();
                //btn.Size = new Size(100, 100);

                //fpnItem.Controls.Add(btn);


                Monan item = new Monan();
                item.MonID = dr[0].ToString();
                item.Name = dr[1].ToString();
                item.Gia = int.Parse(dr[3].ToString());
                if(dr["HinhAnh"].ToString() != "")
                {
                    item.anh = dr["HinhAnh"].ToString();
                }
                
                item.Click += addOrder;

                //btn.DataBindings.Add(new Binding("Text", dr, dr[0].ToString()));

                fpnItem.Controls.Add(item);

            }
 

        }

        

        private void txtTenM_Click(object sender, EventArgs e)
        {
            txtTenM.Clear();
            txtTenM.ForeColor = Color.Black;
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable db = new DataTable();
        }


        public void addOrder(object sender, EventArgs e)
        {
            Monan item = (Monan)sender;
            //DataRow newitem = tborder.NewRow();

            tborder.Rows.Add(item.Name,item.Gia);

            //dataGridView1.Rows.Add(newitem);
            
        }
        private void fpnItem_Enter(object sender, EventArgs e)
        {
            //Khai báo và khởi tạo một DataTable
            //DataTable tables = new DataTable();
            //////Khai báo và khởi tạo một cột với tên là STT kiểu là số nguyên
            //DataColumn col1 = new DataColumn("STT", Type.GetType("System.Int32"));
            //col1.AllowDBNull = false; // Cột không được phép Null
            //col1.AutoIncrement = true; //Giá trị tăng tự động
            //col1.AutoIncrementSeed = 1; //Bắt đầu đánh số từ 1
            //col1.Unique = true;//Giá trị là duy nhất
            //tables.Columns.Add(col1); //Thêm cột STT vào bảng tables
            //                          //Chèn thêm cột HoTen
            //tables.Columns.Add("HoTen", Type.GetType("System.String"));

            //DataColumn col1 = new DataColumn("STT", Type.GetType("System.Int32"));
            //col1.AllowDBNull = false; // Cột không được phép Null
            //col1.AutoIncrement = true; //Giá trị tăng tự động
            //col1.AutoIncrementSeed = 1; //Bắt đầu đánh số từ 1
            //col1.Unique = true;//Giá trị là duy nhất
            //tborder.Columns.Add(col1);

            //tborder.Columns.Add("Mon An", Type.GetType("System.string"));
            //DataColumn col2 = new DataColumn("SL", Type.GetType("System.Int32"));
            //col2.AutoIncrementSeed = 1;
            //tborder.Columns.Add(col2);

            ////chen dl vao bang
            //DataRow newItem;


           // lblTotal.Text = total().ToString();

        }

        public double total()
        {
            if (dataGridView1.Rows.Count != 0)
            {
                double sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    double a = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
                    sum += a;

                }
                return sum;
            }
            else return 0;
        }
    }
}
