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
using System.Windows.Forms.DataVisualization.Charting;

namespace RestuarantManagement.Forms
{
    public partial class frmThongKe : Form
    {
        DataProcesser dtb = new DataProcesser();
        string sql = "";
        public frmThongKe()
        {
            InitializeComponent();



        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            

            //Đặt tên cho trục tung và trucj hoành 
             

            chart_DoanhThu.ChartAreas["ChartArea1"].AxisY.Maximum = 1000000;
            chart_DoanhThu.ChartAreas["ChartArea1"].AxisY.Minimum = 100;
            //chart_DoanhThu.ChartAreas["ChartArea1"].AxisY.Interval = 10;

            ////chart1.Series["Series1"].XValueMember = "MaLoai";
            ////chart1.Series["Series1"].YValueMembers = "SL";
            //Series s1 = new Series();
            //s1.Name = "Doanh_Thu";

            //chart_DoanhThu.Series.Add(s1);
            //chart_DoanhThu.Series["Doanh_Thu"].Points.AddXY(1, 0);
            //chart_DoanhThu.Series["Doanh_Thu"].Points.AddXY(2, 0);
            //chart_DoanhThu.Series["Doanh_Thu"].Points.AddXY(3, 0);




            anTuyChon();
            loadNam();
            loadThang();
        }

        private void anTuyChon()
        {
            //ngay
            lblNgay.Visible = false;
            dtp_Ngay.Visible = false;

            //thang
            lblThang.Visible = false;
            lblNam.Visible = false;
            cboThang.Visible = false;
            cboNam.Visible = false;


            //comboBox1.SelectedIndex = -1;
        }

        private void sortThang()
        {
            lblThang.Visible = true;
            lblNam.Visible = true;
            cboThang.Visible = true;
            cboNam.Visible = true;
        }

        private void sortNam()
        {
            lblNam.Visible = true;
            cboNam.Visible = true;
        }
        //load năm cho cboNam 
        private void loadNam()
        {
            sql = "select distinct year(NgayBan) as Name from HoaDonBan";
            DataTable dtNam = new DataTable();
            dtNam = dtb.ReadData(sql);

            foreach (DataRow dr in dtNam.Rows)
            {
                cboNam.Items.Add(dr["Name"]);

            }

        }

        //load thang
        private void loadThang()
        {
            cboThang.Items.Clear();

            if (cboNam.Text != "")
            {
                int nam = int.Parse(cboNam.Text);
                int nam_now = int.Parse(DateTime.Now.ToString("yyyy"));
                int month_now = int.Parse(DateTime.Now.ToString("MM"));

                if (nam == nam_now)
                {
                    for (int i = 1; i <= month_now; i++)
                    {
                        cboThang.Items.Add(i.ToString());
                    }
                    return;
                }
            }

            for (int i = 1; i <= 12; i++)
            {
                cboThang.Items.Add(i.ToString());
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //chon ngay
            if (comboBox1.SelectedIndex == 0)
            {
                anTuyChon();
                lblNgay.Visible = true;
                dtp_Ngay.Visible = true;


            }

            //chon thang
            if (comboBox1.SelectedIndex == 1)
            {
                anTuyChon();
                sortThang();

            }

            //chon nam

            if (comboBox1.SelectedIndex == 2)
            {
                anTuyChon();
                sortNam();

            }

        }
        private void cboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
                loadThang();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                if (dtp_Ngay.Visible == true)
                {

                    //txtTongThu.Text = dtb.DoanhThuNgay(dtp_Ngay.Value).ToString();
                    //MessageBox.Show(dtb.DoanhThuNgay(dtp_Ngay.Value).ToString());

                    float dt = float.Parse(dtb.DoanhThuNgay_Func(dtp_Ngay.Value).ToString());
                    //DataTable dt = dtb.DoanhThuNgay_Func(dtp_Ngay.Value);

                    //txtTongThu.Text = dt.Rows[0]["TT"].ToString();
                    lblTongThu.Text = dt.ToString("C0");


                //bieu do
                //them du lieu 
                //chart_DoanhThu.Series["serDT"].Points.AddXY("Hôn nay",float.Parse(txtTongThu.Text));

                if (lblTongThu.Text == "")
                    {
                        lblTongThu.Text = "0";
                    }

                BieuDo_Ngay(dtp_Ngay.Value, Convert.ToInt32(dt));
                    
            }

            //thang
            if (comboBox1.SelectedIndex == 1)
            {
                if (cboNam.Text == "" && cboThang.Text == "")
                {
                    MessageBox.Show("Choose Month and year");


                }
                else
                {
                    int thang = int.Parse(cboThang.Text.ToString());
                    int nam = int.Parse(cboNam.Text.ToString());

                    //sql = "select * from DT_Thang(" + cboThang.Text.ToString() + "," + cboNam.Text.ToString() + ")";
                    //DataTable dtthang = dtb.ReadData(sql);

                   
                    try
                    {
                        float tongthu = float.Parse(dtb.DTThang(thang, nam).ToString());
                        lblTongThu.Text = tongthu.ToString("C0");


                        BieuDo_Thang(thang, nam,tongthu);
                        //MessageBox.Show("Ok");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    

                }

            }

            //nam
            if (comboBox1.SelectedIndex == 2)
            {
                
                //sql = "select * from DT_Thang(" + cboThang.Text.ToString() + "," + cboNam.Text.ToString() + ")";
                //DataTable dtthang = dtb.ReadData(sql);

                if (cboNam.Text == "" )
                {
                    MessageBox.Show("Choose Year");


                }
                else
                {
                    int nam = int.Parse(cboNam.Text.ToString());

                    try
                    {
                        float tongthu = float.Parse(dtb.DTNam(nam).ToString());
                        lblTongThu.Text = tongthu.ToString("C0");
                        //MessageBox.Show("Ok");

                        BieuDo_Nam(nam);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                    
            }

        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (dtp_Ngay.Visible == true)
            {

                //txtTongThu.Text = dtb.DoanhThuNgay(dtp_Ngay.Value).ToString();
                //MessageBox.Show(dtb.DoanhThuNgay(dtp_Ngay.Value).ToString());

                float dt = float.Parse(dtb.DoanhThuNgay_Func(dtp_Ngay.Value).ToString());
                //DataTable dt = dtb.DoanhThuNgay_Func(dtp_Ngay.Value);

                //txtTongThu.Text = dt.Rows[0]["TT"].ToString();
                lblTongThu.Text = dt.ToString("C0");


                //bieu do
                //them du lieu 
                //chart_DoanhThu.Series["serDT"].Points.AddXY("Hôn nay",float.Parse(txtTongThu.Text));

                if (lblTongThu.Text == "")
                {
                    lblTongThu.Text = "0";
                }

                BieuDo_Ngay(dtp_Ngay.Value, Convert.ToInt32(dt));

            }

            //thang
            if (comboBox1.SelectedIndex == 1)
            {
                if (cboNam.Text == "" && cboThang.Text == "")
                {
                    MessageBox.Show("Choose Month and year");


                }
                else
                {
                    int thang = int.Parse(cboThang.Text.ToString());
                    int nam = int.Parse(cboNam.Text.ToString());

                    //sql = "select * from DT_Thang(" + cboThang.Text.ToString() + "," + cboNam.Text.ToString() + ")";
                    //DataTable dtthang = dtb.ReadData(sql);


                    try
                    {
                        float tongthu = float.Parse(dtb.DTThang(thang, nam).ToString());
                        lblTongThu.Text = tongthu.ToString("C0");


                        BieuDo_Thang(thang, nam, tongthu);
                        //MessageBox.Show("Ok");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }

            }

            //nam
            if (comboBox1.SelectedIndex == 2)
            {

                //sql = "select * from DT_Thang(" + cboThang.Text.ToString() + "," + cboNam.Text.ToString() + ")";
                //DataTable dtthang = dtb.ReadData(sql);

                if (cboNam.Text == "")
                {
                    MessageBox.Show("Choose Year");


                }
                else
                {
                    int nam = int.Parse(cboNam.Text.ToString());

                    try
                    {
                        float tongthu = float.Parse(dtb.DTNam(nam).ToString());
                        lblTongThu.Text = tongthu.ToString("C0");
                        //MessageBox.Show("Ok");

                        BieuDo_Nam(nam);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }


            }

        }

        private void BieuDo_Ngay(DateTime dt, int tt)
        {
            chart_DoanhThu.ChartAreas["ChartArea1"].AxisY.Maximum = 1000000;
            chart_DoanhThu.ChartAreas["ChartArea1"].AxisY.Minimum = 100000;
            chart_DoanhThu.ChartAreas["ChartArea1"].AxisY.Interval = 100000;

            //bieu do 
            chart_DoanhThu.Series.Clear();
            Series DT_Ngay = new Series();
            DT_Ngay.Name = "DT_Ngay";

            chart_DoanhThu.ChartAreas["ChartArea1"].AxisY.LabelStyle.Format = "C0"; // Định dạng nhãn, ví dụ: 0 (số nguyên)
            //truc X
            chart_DoanhThu.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = -45;

            chart_DoanhThu.Series.Add(DT_Ngay);
            chart_DoanhThu.Series["DT_Ngay"].Points.AddXY(dt.ToString("yyyy/M/d"),tt);
            
        }

        private void BieuDo_Thang(int thang, int nam, float tt)
        {
            //DataTable bieudo = dtb.BieuDo_DTThang(thang, nam);

            //chart_DoanhThu.DataSource = bieudo;

            //set gia tri
            chart_DoanhThu.ChartAreas["ChartArea1"].AxisY.Maximum = 1000000;
            chart_DoanhThu.ChartAreas["ChartArea1"].AxisY.Minimum = 100000;
            chart_DoanhThu.ChartAreas["ChartArea1"].AxisY.Interval = 100000;

            chart_DoanhThu.Series.Clear();
            Series dt_thang = new Series();
            dt_thang.Name = "BieuDo_Thang";
            chart_DoanhThu.Series.Add(dt_thang);

            //chart_DoanhThu.ChartAreas["ChartArea1"].AxisX.Title = "Thang";
            //chart_DoanhThu.ChartAreas["ChartArea1"].AxisY.Title = "Tiền";

            //truc X
            chart_DoanhThu.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = -45;

            //khoang cach giua cac cot
            chart_DoanhThu.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            chart_DoanhThu.Series["BieuDo_Thang"].Points.AddXY(thang,tt);

        }

        private void BieuDo_Nam(int nam)
        {
            DataTable bieudo = dtb.BieuDo_DTNam(nam);

            chart_DoanhThu.DataSource = bieudo;
            chart_DoanhThu.Series.Clear();
            Series dt_nam = new Series();
            dt_nam.Name = "BieuDo_Nam";

            chart_DoanhThu.Series.Add(dt_nam);

            //truc Y
            chart_DoanhThu.ChartAreas["ChartArea1"].AxisX.Title = "Thang";
            chart_DoanhThu.ChartAreas["ChartArea1"].AxisY.Minimum = 100000;  // Giới hạn dưới của trục Y
            chart_DoanhThu.ChartAreas["ChartArea1"].AxisY.Maximum = 1000000; // Giới hạn trên của trục Y
            chart_DoanhThu.ChartAreas["ChartArea1"].AxisY.Interval = 100000; // Khoảng cách giữa các dấu chia
            chart_DoanhThu.ChartAreas["ChartArea1"].AxisY.LabelStyle.Format = "C0"; // Định dạng nhãn, ví dụ: 0 (số nguyên)

            //truc X
            chart_DoanhThu.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = -45;
            //chỉnh độ nghiêng 
            chart_DoanhThu.ChartAreas["ChartArea1"].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.None;  // Tắt tự động điều chỉnh nhãn

            chart_DoanhThu.ChartAreas["ChartArea1"].AxisY.Title = "Tiền";
            //khoang cach giua cac cot
            chart_DoanhThu.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            //chart_DoanhThu.Series["BieuDo_Nam"].XValueMember = "Thang";
            //chart_DoanhThu.Series["BieuDo_Nam"].YValueMembers = "TT";

            foreach(DataRow dr in bieudo.Rows)
            {
                chart_DoanhThu.Series["BieuDo_Nam"].Points.AddXY(dr[0].ToString(), dr[1]);
            }
        }
    }
 }
