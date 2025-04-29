using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLBanHang.Classes
{
    internal class DataProcesser
    {
        //Open a Connection to DataBase
       
        string strConnect = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=qlNhaHang;Integrated Security=True";
        SqlConnection sqlconnect = null;
        void OpenConnection()
        {
            sqlconnect = new SqlConnection(strConnect);
            if(sqlconnect.State != ConnectionState.Open)
                sqlconnect.Open();
        }
        //Close Connection
        void CloseConnection()
        {
            if(sqlconnect.State != ConnectionState.Closed)
            {
                sqlconnect.Close();
                sqlconnect.Dispose();
            }    
        }
        //Read Data from a select statement and return a DataTable.
        public DataTable ReadData(string sqlSelect)
        {
            DataTable data = new DataTable();
            OpenConnection();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlSelect, sqlconnect);
            dataAdapter.Fill(data);
            CloseConnection();
            dataAdapter.Dispose();
            return data;
        }
        //Change Data 
        public void ChangeData(string sql)
        {
            OpenConnection();
            SqlCommand commad = new SqlCommand();
            commad.CommandText = sql;
            commad.Connection = sqlconnect;
            commad.ExecuteNonQuery();
            CloseConnection();
            commad.Dispose();
        }

        //doanh thu theo ngay
        public DataTable DoanhThuNgay(DateTime  ngay)
        {
            decimal doanhthu = 0;
            decimal sohd = 0;
            OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "doanh_thu_ngay_1";
            cmd.Connection = sqlconnect;

            

            //định nghĩa tham số cho thủ tục
            //SqlParameter pa_ngay = new SqlParameter("@ngay", SqlDbType.Date);

            //MessageBox.Show(ngay.ToString("yyyy/M/d"));
            cmd.Parameters.AddWithValue("@ngay", ngay.ToString("yyyy/M/d"));
            

            //dùng dataadapter 
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            
            DataTable data = new DataTable();
            dataAdapter.Fill(data);
            CloseConnection();
            dataAdapter.Dispose();

            return data;
        }

        public float DoanhThuNgay_Func(DateTime ngay)
        {
            
            OpenConnection();
            string sql = "select * from doanh_thu_ngay('" + ngay.ToString("yyyy/M/d") + "')";

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlconnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sql;

            var dt = sqlCommand.ExecuteScalar();
            if(dt.ToString() == "")
            {
                dt = 0;
            }
           
            CloseConnection();

           

            return float.Parse(dt.ToString());
        }

        public float DTThang(int thang, int nam)
        {
            OpenConnection();
            string sql = "select * from DT_Thang(" + thang.ToString() +"," + nam.ToString() + ")";

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlconnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sql;

            var dt = sqlCommand.ExecuteScalar();

            if (dt.ToString() == "")
            {
                dt = 0;
            }
            CloseConnection();

            return float.Parse(dt.ToString());


        }

        public float DTNam(int nam)
        {
            OpenConnection();
            string sql = "select * from DT_Nam(" + nam.ToString() + ")";
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlconnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sql;

            var dt = sqlCommand.ExecuteScalar();
            CloseConnection();

            return float.Parse(dt.ToString());


        }

        public DataTable BieuDo_DTThang(int thang, int nam)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlconnect;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "BieuDo_Thang";

            //them tham so
            cmd.Parameters.AddWithValue("@thang", thang);
            cmd.Parameters.AddWithValue("@nam", nam);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            CloseConnection();
            dataAdapter.Dispose();

            return dataTable;

        }

        public DataTable BieuDo_DTNam(int nam)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlconnect;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "BieuDo_Nam";

            //them tham so
            cmd.Parameters.AddWithValue("@nam", nam);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            CloseConnection();
            dataAdapter.Dispose();

            return dataTable;

        }
    }
}
