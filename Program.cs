﻿
using RestuarantManagement.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestuarantManagement
{
    internal static class Program
    {
        public static string maNV = "";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new fmMonAn());
            //Application.Run(new fmQlMonAn());
            //Application.Run(new frmThongKe());
            //Application.Run(new Main());

            //Application.Run(new frmBan());

            Application.Run(new frmHoaDon());
            //Application.Run(new frmMain());
            //Application.Run(new frmNhanVienMain());


            //Application.Run(new LoginWithManager());


        }
    }
}
