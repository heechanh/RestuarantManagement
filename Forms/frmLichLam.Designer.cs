namespace RestuarantManagement.Forms
{
    partial class frmLichLam
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbMaNV = new System.Windows.Forms.ComboBox();
            this.cbBoPhan = new System.Windows.Forms.ComboBox();
            this.dtpNgayLam = new System.Windows.Forms.DateTimePicker();
            this.cbFulltime = new System.Windows.Forms.CheckBox();
            this.cbDem = new System.Windows.Forms.CheckBox();
            this.cbToi = new System.Windows.Forms.CheckBox();
            this.cbChieu = new System.Windows.Forms.CheckBox();
            this.cbSang = new System.Windows.Forms.CheckBox();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.btnIn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvCaLam = new System.Windows.Forms.DataGridView();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cbTimKiem = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTimTenNV = new System.Windows.Forms.TextBox();
            this.btnTimTenNV = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaLam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tìm Kiếm";
            // 
            // ID
            // 
            this.ID.AutoSize = true;
            this.ID.Location = new System.Drawing.Point(22, 118);
            this.ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(26, 20);
            this.ID.TabIndex = 2;
            this.ID.Text = "ID";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbMaNV);
            this.groupBox1.Controls.Add(this.cbBoPhan);
            this.groupBox1.Controls.Add(this.dtpNgayLam);
            this.groupBox1.Controls.Add(this.cbFulltime);
            this.groupBox1.Controls.Add(this.cbDem);
            this.groupBox1.Controls.Add(this.cbToi);
            this.groupBox1.Controls.Add(this.cbChieu);
            this.groupBox1.Controls.Add(this.cbSang);
            this.groupBox1.Controls.Add(this.txtTenNV);
            this.groupBox1.Controls.Add(this.btnIn);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnLuu);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ID);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(824, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(480, 723);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // cbMaNV
            // 
            this.cbMaNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaNV.FormattingEnabled = true;
            this.cbMaNV.Items.AddRange(new object[] {
            "Dau bep",
            "Thu ngan",
            "Bao ve",
            "Phuc vu"});
            this.cbMaNV.Location = new System.Drawing.Point(111, 114);
            this.cbMaNV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbMaNV.Name = "cbMaNV";
            this.cbMaNV.Size = new System.Drawing.Size(260, 28);
            this.cbMaNV.TabIndex = 7;
            this.cbMaNV.SelectedIndexChanged += new System.EventHandler(this.cbMaNV_SelectedIndexChanged);
            // 
            // cbBoPhan
            // 
            this.cbBoPhan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoPhan.FormattingEnabled = true;
            this.cbBoPhan.Items.AddRange(new object[] {
            "Dau bep",
            "Thu ngan",
            "Bao ve",
            "Phuc vu"});
            this.cbBoPhan.Location = new System.Drawing.Point(111, 223);
            this.cbBoPhan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbBoPhan.Name = "cbBoPhan";
            this.cbBoPhan.Size = new System.Drawing.Size(260, 28);
            this.cbBoPhan.TabIndex = 7;
            this.cbBoPhan.SelectedIndexChanged += new System.EventHandler(this.cbMaNV_SelectedIndexChanged);
            // 
            // dtpNgayLam
            // 
            this.dtpNgayLam.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayLam.Location = new System.Drawing.Point(111, 56);
            this.dtpNgayLam.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpNgayLam.Name = "dtpNgayLam";
            this.dtpNgayLam.Size = new System.Drawing.Size(260, 26);
            this.dtpNgayLam.TabIndex = 6;
            // 
            // cbFulltime
            // 
            this.cbFulltime.AutoSize = true;
            this.cbFulltime.Location = new System.Drawing.Point(276, 311);
            this.cbFulltime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbFulltime.Name = "cbFulltime";
            this.cbFulltime.Size = new System.Drawing.Size(95, 24);
            this.cbFulltime.TabIndex = 5;
            this.cbFulltime.Text = "Full-time";
            this.cbFulltime.UseVisualStyleBackColor = true;
            this.cbFulltime.CheckedChanged += new System.EventHandler(this.cbFulltime_CheckedChanged);
            // 
            // cbDem
            // 
            this.cbDem.AutoSize = true;
            this.cbDem.Location = new System.Drawing.Point(190, 344);
            this.cbDem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbDem.Name = "cbDem";
            this.cbDem.Size = new System.Drawing.Size(69, 24);
            this.cbDem.TabIndex = 5;
            this.cbDem.Text = "Đêm";
            this.cbDem.UseVisualStyleBackColor = true;
            this.cbDem.CheckedChanged += new System.EventHandler(this.cbSang_CheckedChanged);
            // 
            // cbToi
            // 
            this.cbToi.AutoSize = true;
            this.cbToi.Location = new System.Drawing.Point(111, 344);
            this.cbToi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbToi.Name = "cbToi";
            this.cbToi.Size = new System.Drawing.Size(56, 24);
            this.cbToi.TabIndex = 5;
            this.cbToi.Text = "Tối";
            this.cbToi.UseVisualStyleBackColor = true;
            this.cbToi.CheckedChanged += new System.EventHandler(this.cbSang_CheckedChanged);
            // 
            // cbChieu
            // 
            this.cbChieu.AutoSize = true;
            this.cbChieu.Location = new System.Drawing.Point(190, 286);
            this.cbChieu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbChieu.Name = "cbChieu";
            this.cbChieu.Size = new System.Drawing.Size(76, 24);
            this.cbChieu.TabIndex = 5;
            this.cbChieu.Text = "Chiều";
            this.cbChieu.UseVisualStyleBackColor = true;
            this.cbChieu.CheckedChanged += new System.EventHandler(this.cbSang_CheckedChanged);
            // 
            // cbSang
            // 
            this.cbSang.AutoSize = true;
            this.cbSang.Location = new System.Drawing.Point(111, 286);
            this.cbSang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbSang.Name = "cbSang";
            this.cbSang.Size = new System.Drawing.Size(73, 24);
            this.cbSang.TabIndex = 5;
            this.cbSang.Text = "Sáng";
            this.cbSang.UseVisualStyleBackColor = true;
            this.cbSang.CheckedChanged += new System.EventHandler(this.cbSang_CheckedChanged);
            // 
            // txtTenNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(111, 167);
            this.txtTenNV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(260, 26);
            this.txtTenNV.TabIndex = 4;
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(26, 658);
            this.btnIn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(109, 54);
            this.btnIn.TabIndex = 3;
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(164, 658);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 54);
            this.button2.TabIndex = 3;
            this.button2.Text = "Thoát";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(164, 600);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 54);
            this.button1.TabIndex = 3;
            this.button1.Text = "Hủy";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(26, 600);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(109, 54);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(303, 474);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(109, 54);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa Ca Làm";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(164, 474);
            this.btnSua.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(109, 54);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sửa Ca Làm";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(26, 474);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(109, 54);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm Ca Làm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 56);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Ngày Làm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 286);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Ca Làm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 230);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Bộ Phận";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 172);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Họ tên";
            // 
            // dgvCaLam
            // 
            this.dgvCaLam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCaLam.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvCaLam.Location = new System.Drawing.Point(0, 182);
            this.dgvCaLam.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvCaLam.Name = "dgvCaLam";
            this.dgvCaLam.RowHeadersWidth = 82;
            this.dgvCaLam.RowTemplate.Height = 33;
            this.dgvCaLam.Size = new System.Drawing.Size(824, 541);
            this.dgvCaLam.TabIndex = 4;
            this.dgvCaLam.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCaLam_CellClick);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(348, 34);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(109, 34);
            this.btnTimKiem.TabIndex = 3;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // cbTimKiem
            // 
            this.cbTimKiem.FormattingEnabled = true;
            this.cbTimKiem.Location = new System.Drawing.Point(113, 34);
            this.cbTimKiem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbTimKiem.Name = "cbTimKiem";
            this.cbTimKiem.Size = new System.Drawing.Size(222, 28);
            this.cbTimKiem.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTimTenNV);
            this.groupBox2.Controls.Add(this.btnTimTenNV);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnTimKiem);
            this.groupBox2.Controls.Add(this.cbTimKiem);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(824, 140);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // txtTimTenNV
            // 
            this.txtTimTenNV.Location = new System.Drawing.Point(113, 89);
            this.txtTimTenNV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTimTenNV.Name = "txtTimTenNV";
            this.txtTimTenNV.Size = new System.Drawing.Size(222, 26);
            this.txtTimTenNV.TabIndex = 8;
            // 
            // btnTimTenNV
            // 
            this.btnTimTenNV.Location = new System.Drawing.Point(348, 89);
            this.btnTimTenNV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTimTenNV.Name = "btnTimTenNV";
            this.btnTimTenNV.Size = new System.Drawing.Size(109, 34);
            this.btnTimTenNV.TabIndex = 7;
            this.btnTimTenNV.Text = "Tìm Kiếm";
            this.btnTimTenNV.UseVisualStyleBackColor = true;
            this.btnTimTenNV.Click += new System.EventHandler(this.btnTimTenNV_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "TK NV";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 723);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvCaLam);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaLam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvCaLam;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.CheckBox cbSang;
        private System.Windows.Forms.CheckBox cbFulltime;
        private System.Windows.Forms.CheckBox cbDem;
        private System.Windows.Forms.CheckBox cbToi;
        private System.Windows.Forms.CheckBox cbChieu;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtpNgayLam;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ComboBox cbTimKiem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.ComboBox cbBoPhan;
        private System.Windows.Forms.ComboBox cbMaNV;
        private System.Windows.Forms.Button btnTimTenNV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTimTenNV;
        private System.Windows.Forms.Button btnIn;
    }
}

