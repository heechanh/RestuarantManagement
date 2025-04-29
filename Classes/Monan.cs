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
using System.Xml.Linq;

namespace RestuarantManagement
{
    public partial class Monan : UserControl
    {
        DataProcesser dtbase = new DataProcesser();

        //public event EventHandler selectedt; 
        private string monid;
        private string name;
        private int gia;
        private string loai;
        public string anh {  get; set; }

        public string MonID
        {
            get { return monid; }
            set { monid = value; }

        }
        public string Name
        {
            get { return name; }
            set { name = value; }

        }
        public int Gia
        {
            get { return gia; }
            set { gia = value; }

        }
        public Monan()
        {
            InitializeComponent();
        }

        private void Monan_Load(object sender, EventArgs e)
        {
            lblName.Text = name;
            lblGia.Text = gia.ToString("C2");
           

            //OpenFileDialog openFile = new OpenFileDialog();
            if(anh != null)
            {
                this.BackgroundImage = Image.FromFile(anh);
            }
        }
    }
}
