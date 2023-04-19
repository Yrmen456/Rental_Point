
namespace Rental_Point
{
    partial class Authorization
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.login_textbox = new System.Windows.Forms.TextBox();
            this.password_textbox = new System.Windows.Forms.TextBox();
            this.login_up = new System.Windows.Forms.Button();
            this.login_label = new System.Windows.Forms.Label();
            this.password_label = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.form_authorization = new System.Windows.Forms.Panel();
            this.time_num = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.login_out = new System.Windows.Forms.Button();
            this.visible_password = new System.Windows.Forms.Panel();
            this.pictureBox_logo = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.form_authorization.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // login_textbox
            // 
            this.login_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login_textbox.Location = new System.Drawing.Point(153, 171);
            this.login_textbox.Name = "login_textbox";
            this.login_textbox.Size = new System.Drawing.Size(308, 34);
            this.login_textbox.TabIndex = 0;
            // 
            // password_textbox
            // 
            this.password_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.password_textbox.Location = new System.Drawing.Point(155, 260);
            this.password_textbox.Name = "password_textbox";
            this.password_textbox.Size = new System.Drawing.Size(306, 34);
            this.password_textbox.TabIndex = 1;
            this.password_textbox.UseSystemPasswordChar = true;
            // 
            // login_up
            // 
            this.login_up.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login_up.Location = new System.Drawing.Point(153, 321);
            this.login_up.Name = "login_up";
            this.login_up.Size = new System.Drawing.Size(132, 44);
            this.login_up.TabIndex = 2;
            this.login_up.Text = "Войти";
            this.login_up.UseVisualStyleBackColor = true;
            this.login_up.Click += new System.EventHandler(this.login_up_Click);
            // 
            // login_label
            // 
            this.login_label.AutoSize = true;
            this.login_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login_label.Location = new System.Drawing.Point(152, 148);
            this.login_label.Name = "login_label";
            this.login_label.Size = new System.Drawing.Size(59, 20);
            this.login_label.TabIndex = 3;
            this.login_label.Text = "Логин";
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.password_label.Location = new System.Drawing.Point(152, 237);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(72, 20);
            this.password_label.TabIndex = 4;
            this.password_label.Text = "Пароль";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.title.Location = new System.Drawing.Point(15, 20);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(227, 38);
            this.title.TabIndex = 6;
            this.title.Text = "Авторизация";
            this.title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.title_MouseDown);
            // 
            // form_authorization
            // 
            this.form_authorization.BackColor = System.Drawing.Color.White;
            this.form_authorization.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.form_authorization.Controls.Add(this.time_num);
            this.form_authorization.Controls.Add(this.dataGridView1);
            this.form_authorization.Controls.Add(this.title);
            this.form_authorization.Controls.Add(this.login_out);
            this.form_authorization.Controls.Add(this.login_label);
            this.form_authorization.Controls.Add(this.password_label);
            this.form_authorization.Controls.Add(this.login_textbox);
            this.form_authorization.Controls.Add(this.visible_password);
            this.form_authorization.Controls.Add(this.login_up);
            this.form_authorization.Controls.Add(this.password_textbox);
            this.form_authorization.Controls.Add(this.pictureBox_logo);
            this.form_authorization.Dock = System.Windows.Forms.DockStyle.Fill;
            this.form_authorization.Location = new System.Drawing.Point(0, 0);
            this.form_authorization.Name = "form_authorization";
            this.form_authorization.Size = new System.Drawing.Size(708, 430);
            this.form_authorization.TabIndex = 7;
            this.form_authorization.Paint += new System.Windows.Forms.PaintEventHandler(this.form_authorization_Paint);
            this.form_authorization.MouseDown += new System.Windows.Forms.MouseEventHandler(this.form_authorization_MouseDown);
            // 
            // time_num
            // 
            this.time_num.AutoSize = true;
            this.time_num.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.time_num.Location = new System.Drawing.Point(18, 397);
            this.time_num.Name = "time_num";
            this.time_num.Size = new System.Drawing.Size(18, 20);
            this.time_num.TabIndex = 9;
            this.time_num.Text = "0";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(522, 162);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(203, 255);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // login_out
            // 
            this.login_out.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login_out.Location = new System.Drawing.Point(329, 321);
            this.login_out.Name = "login_out";
            this.login_out.Size = new System.Drawing.Size(132, 44);
            this.login_out.TabIndex = 3;
            this.login_out.Text = "Отмена";
            this.login_out.UseVisualStyleBackColor = true;
            this.login_out.Click += new System.EventHandler(this.login_out_Click);
            // 
            // visible_password
            // 
            this.visible_password.BackgroundImage = global::Rental_Point.Properties.Resources.close;
            this.visible_password.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.visible_password.Location = new System.Drawing.Point(467, 260);
            this.visible_password.Name = "visible_password";
            this.visible_password.Size = new System.Drawing.Size(40, 34);
            this.visible_password.TabIndex = 5;
            this.visible_password.Click += new System.EventHandler(this.visible_password_Click);
            // 
            // pictureBox_logo
            // 
            this.pictureBox_logo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_logo.Image = global::Rental_Point.Properties.Resources.logo;
            this.pictureBox_logo.Location = new System.Drawing.Point(522, -1);
            this.pictureBox_logo.Name = "pictureBox_logo";
            this.pictureBox_logo.Size = new System.Drawing.Size(185, 157);
            this.pictureBox_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_logo.TabIndex = 7;
            this.pictureBox_logo.TabStop = false;
            this.pictureBox_logo.Click += new System.EventHandler(this.pictureBox_logo_Click);
            this.pictureBox_logo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Authorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 430);
            this.Controls.Add(this.form_authorization);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Authorization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.Authorization_Load);
            this.form_authorization.ResumeLayout(false);
            this.form_authorization.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox login_textbox;
        private System.Windows.Forms.TextBox password_textbox;
        private System.Windows.Forms.Button login_up;
        private System.Windows.Forms.Label login_label;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.Panel visible_password;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel form_authorization;
        private System.Windows.Forms.Button login_out;
        private System.Windows.Forms.PictureBox pictureBox_logo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label time_num;
    }
}