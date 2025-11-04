namespace QuanLyBanHangTV
{
    partial class frmQuenMatKhau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuenMatKhau));
            this.pnlDangNhap = new System.Windows.Forms.Panel();
            this.ptbDangNhap = new System.Windows.Forms.PictureBox();
            this.pnrDangNhap = new System.Windows.Forms.Panel();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnLayMatKhau = new Guna.UI2.WinForms.Guna2Button();
            this.lbLayLaiMK = new System.Windows.Forms.Label();
            this.btnDong = new Guna.UI2.WinForms.Guna2Button();
            this.btnThuNho = new Guna.UI2.WinForms.Guna2Button();
            this.pnlDangNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbDangNhap)).BeginInit();
            this.pnrDangNhap.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDangNhap
            // 
            this.pnlDangNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlDangNhap.Controls.Add(this.ptbDangNhap);
            this.pnlDangNhap.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDangNhap.Location = new System.Drawing.Point(0, 0);
            this.pnlDangNhap.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDangNhap.Name = "pnlDangNhap";
            this.pnlDangNhap.Size = new System.Drawing.Size(102, 289);
            this.pnlDangNhap.TabIndex = 4;
            // 
            // ptbDangNhap
            // 
            this.ptbDangNhap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ptbDangNhap.Image = ((System.Drawing.Image)(resources.GetObject("ptbDangNhap.Image")));
            this.ptbDangNhap.Location = new System.Drawing.Point(-14, 0);
            this.ptbDangNhap.Margin = new System.Windows.Forms.Padding(2);
            this.ptbDangNhap.Name = "ptbDangNhap";
            this.ptbDangNhap.Size = new System.Drawing.Size(128, 141);
            this.ptbDangNhap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbDangNhap.TabIndex = 0;
            this.ptbDangNhap.TabStop = false;
            // 
            // pnrDangNhap
            // 
            this.pnrDangNhap.BackColor = System.Drawing.Color.White;
            this.pnrDangNhap.Controls.Add(this.txtEmail);
            this.pnrDangNhap.Controls.Add(this.btnLayMatKhau);
            this.pnrDangNhap.Controls.Add(this.lbLayLaiMK);
            this.pnrDangNhap.Controls.Add(this.btnDong);
            this.pnrDangNhap.Controls.Add(this.btnThuNho);
            this.pnrDangNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnrDangNhap.Location = new System.Drawing.Point(102, 0);
            this.pnrDangNhap.Margin = new System.Windows.Forms.Padding(2);
            this.pnrDangNhap.Name = "pnrDangNhap";
            this.pnrDangNhap.Size = new System.Drawing.Size(514, 289);
            this.pnrDangNhap.TabIndex = 5;
            // 
            // txtEmail
            // 
            this.txtEmail.BorderRadius = 20;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "Email";
            this.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtEmail.IconLeft")));
            this.txtEmail.Location = new System.Drawing.Point(122, 129);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.PlaceholderText = "";
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(249, 44);
            this.txtEmail.TabIndex = 7;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // btnLayMatKhau
            // 
            this.btnLayMatKhau.BorderRadius = 20;
            this.btnLayMatKhau.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLayMatKhau.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLayMatKhau.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLayMatKhau.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLayMatKhau.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLayMatKhau.FillColor = System.Drawing.Color.Black;
            this.btnLayMatKhau.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLayMatKhau.ForeColor = System.Drawing.Color.White;
            this.btnLayMatKhau.Location = new System.Drawing.Point(170, 191);
            this.btnLayMatKhau.Margin = new System.Windows.Forms.Padding(2);
            this.btnLayMatKhau.Name = "btnLayMatKhau";
            this.btnLayMatKhau.Size = new System.Drawing.Size(158, 37);
            this.btnLayMatKhau.TabIndex = 5;
            this.btnLayMatKhau.Text = "Lấy mật khẩu";
            this.btnLayMatKhau.Click += new System.EventHandler(this.btnLayMatKhau_Click_1);
            // 
            // lbLayLaiMK
            // 
            this.lbLayLaiMK.AutoSize = true;
            this.lbLayLaiMK.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLayLaiMK.Location = new System.Drawing.Point(139, 72);
            this.lbLayLaiMK.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbLayLaiMK.Name = "lbLayLaiMK";
            this.lbLayLaiMK.Size = new System.Drawing.Size(214, 31);
            this.lbLayLaiMK.TabIndex = 4;
            this.lbLayLaiMK.Text = "Lấy lại mật khẩu";
            // 
            // btnDong
            // 
            this.btnDong.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDong.BorderRadius = 5;
            this.btnDong.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDong.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDong.FillColor = System.Drawing.Color.DarkGray;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.Image")));
            this.btnDong.Location = new System.Drawing.Point(479, 2);
            this.btnDong.Margin = new System.Windows.Forms.Padding(2);
            this.btnDong.Name = "btnDong";
            this.btnDong.PressedColor = System.Drawing.Color.Azure;
            this.btnDong.Size = new System.Drawing.Size(33, 22);
            this.btnDong.TabIndex = 3;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnThuNho
            // 
            this.btnThuNho.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnThuNho.BorderRadius = 5;
            this.btnThuNho.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThuNho.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThuNho.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThuNho.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThuNho.FillColor = System.Drawing.Color.DarkGray;
            this.btnThuNho.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThuNho.ForeColor = System.Drawing.Color.White;
            this.btnThuNho.Image = ((System.Drawing.Image)(resources.GetObject("btnThuNho.Image")));
            this.btnThuNho.Location = new System.Drawing.Point(442, 2);
            this.btnThuNho.Margin = new System.Windows.Forms.Padding(2);
            this.btnThuNho.Name = "btnThuNho";
            this.btnThuNho.Size = new System.Drawing.Size(33, 22);
            this.btnThuNho.TabIndex = 1;
            this.btnThuNho.Click += new System.EventHandler(this.btnThuNho_Click);
            // 
            // QuenMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 289);
            this.Controls.Add(this.pnrDangNhap);
            this.Controls.Add(this.pnlDangNhap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(616, 289);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(616, 289);
            this.Name = "QuenMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QuenMatKhau";
            this.Load += new System.EventHandler(this.QuenMatKhau_Load);
            this.pnlDangNhap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbDangNhap)).EndInit();
            this.pnrDangNhap.ResumeLayout(false);
            this.pnrDangNhap.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDangNhap;
        private System.Windows.Forms.PictureBox ptbDangNhap;
        private System.Windows.Forms.Panel pnrDangNhap;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2Button btnLayMatKhau;
        private System.Windows.Forms.Label lbLayLaiMK;
        private Guna.UI2.WinForms.Guna2Button btnDong;
        private Guna.UI2.WinForms.Guna2Button btnThuNho;
    }
}