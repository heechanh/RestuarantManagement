using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestuarantManagement.Forms;

namespace RestuarantManagement
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }


        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void monAnToolStripMenuItem_Click(object sender, EventArgs e)
        {

                fmMonAn ma = new fmMonAn();
                ma.TopLevel = false;
                ma.Dock = DockStyle.Fill;
                ma.FormBorderStyle = FormBorderStyle.None;

                panel1.Controls.Clear();
                panel1.Controls.Add(ma);
                ma.Show();
                
            
        }

        private void quanToolStripMenuItem_Click(object sender, EventArgs e)
        {

            fmQlMonAn qlma = new fmQlMonAn();
            qlma.TopLevel = false;
            qlma.Dock = DockStyle.Fill;
            qlma.FormBorderStyle = FormBorderStyle.None;

            panel1.Controls.Clear();
            panel1.Controls.Add(qlma);
            qlma.Show();


            //this.Hide();
        }

        private void thongKeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongKe thongKe = new frmThongKe();
            thongKe.TopLevel = false;
            thongKe.Dock = DockStyle.Fill;
            thongKe.FormBorderStyle = FormBorderStyle.None;

            panel1.Controls.Clear();
            panel1.Controls.Add(thongKe);
            thongKe.Show();
            //this.Hide();
        }
    }
}
