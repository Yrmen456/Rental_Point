
namespace Rental_Point
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.left_panel = new System.Windows.Forms.Panel();
            this.bottom_left_panel = new System.Windows.Forms.Panel();
            this.login_out = new System.Windows.Forms.Button();
            this.main_left_panel = new System.Windows.Forms.Panel();
            this.Charts = new System.Windows.Forms.Button();
            this.Customers = new System.Windows.Forms.Button();
            this.Order = new System.Windows.Forms.Button();
            this.Employees = new System.Windows.Forms.Button();
            this.Services = new System.Windows.Forms.Button();
            this.Logins_system = new System.Windows.Forms.Button();
            this.Order_add = new System.Windows.Forms.Button();
            this.main_button = new System.Windows.Forms.Button();
            this.title_left_panel = new System.Windows.Forms.Panel();
            this.title = new System.Windows.Forms.Label();
            this.Panel_Controler = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.user_label = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.title_time = new System.Windows.Forms.Label();
            this.time_num = new System.Windows.Forms.Label();
            this.left_panel.SuspendLayout();
            this.bottom_left_panel.SuspendLayout();
            this.main_left_panel.SuspendLayout();
            this.title_left_panel.SuspendLayout();
            this.Panel_Controler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // left_panel
            // 
            this.left_panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.left_panel.BackColor = System.Drawing.SystemColors.Control;
            this.left_panel.Controls.Add(this.bottom_left_panel);
            this.left_panel.Controls.Add(this.main_left_panel);
            this.left_panel.Controls.Add(this.title_left_panel);
            this.left_panel.Location = new System.Drawing.Point(2, 1);
            this.left_panel.Name = "left_panel";
            this.left_panel.Size = new System.Drawing.Size(233, 637);
            this.left_panel.TabIndex = 0;
            // 
            // bottom_left_panel
            // 
            this.bottom_left_panel.Controls.Add(this.login_out);
            this.bottom_left_panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottom_left_panel.Location = new System.Drawing.Point(0, 592);
            this.bottom_left_panel.Name = "bottom_left_panel";
            this.bottom_left_panel.Size = new System.Drawing.Size(233, 45);
            this.bottom_left_panel.TabIndex = 2;
            this.bottom_left_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // login_out
            // 
            this.login_out.Dock = System.Windows.Forms.DockStyle.Top;
            this.login_out.Location = new System.Drawing.Point(0, 0);
            this.login_out.Name = "login_out";
            this.login_out.Size = new System.Drawing.Size(233, 43);
            this.login_out.TabIndex = 35;
            this.login_out.Text = "Выход";
            this.login_out.UseVisualStyleBackColor = true;
            this.login_out.Click += new System.EventHandler(this.login_out_Click);
            // 
            // main_left_panel
            // 
            this.main_left_panel.Controls.Add(this.Charts);
            this.main_left_panel.Controls.Add(this.Customers);
            this.main_left_panel.Controls.Add(this.Order);
            this.main_left_panel.Controls.Add(this.Employees);
            this.main_left_panel.Controls.Add(this.Services);
            this.main_left_panel.Controls.Add(this.Logins_system);
            this.main_left_panel.Controls.Add(this.Order_add);
            this.main_left_panel.Controls.Add(this.main_button);
            this.main_left_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_left_panel.Location = new System.Drawing.Point(0, 40);
            this.main_left_panel.Name = "main_left_panel";
            this.main_left_panel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.main_left_panel.Size = new System.Drawing.Size(233, 597);
            this.main_left_panel.TabIndex = 1;
            // 
            // Charts
            // 
            this.Charts.Dock = System.Windows.Forms.DockStyle.Top;
            this.Charts.Location = new System.Drawing.Point(0, 311);
            this.Charts.Name = "Charts";
            this.Charts.Size = new System.Drawing.Size(233, 43);
            this.Charts.TabIndex = 39;
            this.Charts.Text = "Графики";
            this.Charts.UseVisualStyleBackColor = true;
            this.Charts.Visible = false;
            this.Charts.Click += new System.EventHandler(this.Charts_Click);
            // 
            // Customers
            // 
            this.Customers.Dock = System.Windows.Forms.DockStyle.Top;
            this.Customers.Location = new System.Drawing.Point(0, 268);
            this.Customers.Name = "Customers";
            this.Customers.Size = new System.Drawing.Size(233, 43);
            this.Customers.TabIndex = 38;
            this.Customers.Text = "Клиенты";
            this.Customers.UseVisualStyleBackColor = true;
            this.Customers.Visible = false;
            this.Customers.Click += new System.EventHandler(this.Customers_Click);
            // 
            // Order
            // 
            this.Order.Dock = System.Windows.Forms.DockStyle.Top;
            this.Order.Location = new System.Drawing.Point(0, 225);
            this.Order.Name = "Order";
            this.Order.Size = new System.Drawing.Size(233, 43);
            this.Order.TabIndex = 37;
            this.Order.Text = "Заказы";
            this.Order.UseVisualStyleBackColor = true;
            this.Order.Visible = false;
            this.Order.Click += new System.EventHandler(this.Order_Click_1);
            // 
            // Employees
            // 
            this.Employees.Dock = System.Windows.Forms.DockStyle.Top;
            this.Employees.Location = new System.Drawing.Point(0, 182);
            this.Employees.Name = "Employees";
            this.Employees.Size = new System.Drawing.Size(233, 43);
            this.Employees.TabIndex = 36;
            this.Employees.Text = "Сотрудники";
            this.Employees.UseVisualStyleBackColor = true;
            this.Employees.Visible = false;
            this.Employees.Click += new System.EventHandler(this.Employees_Click);
            // 
            // Services
            // 
            this.Services.Dock = System.Windows.Forms.DockStyle.Top;
            this.Services.Location = new System.Drawing.Point(0, 139);
            this.Services.Name = "Services";
            this.Services.Size = new System.Drawing.Size(233, 43);
            this.Services.TabIndex = 34;
            this.Services.Text = "Услуги";
            this.Services.UseVisualStyleBackColor = true;
            this.Services.Visible = false;
            this.Services.Click += new System.EventHandler(this.Services_Click);
            // 
            // Logins_system
            // 
            this.Logins_system.Dock = System.Windows.Forms.DockStyle.Top;
            this.Logins_system.Location = new System.Drawing.Point(0, 96);
            this.Logins_system.Name = "Logins_system";
            this.Logins_system.Size = new System.Drawing.Size(233, 43);
            this.Logins_system.TabIndex = 33;
            this.Logins_system.Text = "Системные логи";
            this.Logins_system.UseVisualStyleBackColor = true;
            this.Logins_system.Visible = false;
            this.Logins_system.Click += new System.EventHandler(this.Logins_system_Click);
            // 
            // Order_add
            // 
            this.Order_add.Dock = System.Windows.Forms.DockStyle.Top;
            this.Order_add.Location = new System.Drawing.Point(0, 53);
            this.Order_add.Name = "Order_add";
            this.Order_add.Size = new System.Drawing.Size(233, 43);
            this.Order_add.TabIndex = 32;
            this.Order_add.Text = "Добавить заказ";
            this.Order_add.UseVisualStyleBackColor = true;
            this.Order_add.Visible = false;
            this.Order_add.Click += new System.EventHandler(this.Order_Click);
            // 
            // main_button
            // 
            this.main_button.Dock = System.Windows.Forms.DockStyle.Top;
            this.main_button.Location = new System.Drawing.Point(0, 10);
            this.main_button.Name = "main_button";
            this.main_button.Size = new System.Drawing.Size(233, 43);
            this.main_button.TabIndex = 31;
            this.main_button.Text = "Главная";
            this.main_button.UseVisualStyleBackColor = true;
            this.main_button.Click += new System.EventHandler(this.main_button_Click);
            // 
            // title_left_panel
            // 
            this.title_left_panel.Controls.Add(this.title);
            this.title_left_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.title_left_panel.Location = new System.Drawing.Point(0, 0);
            this.title_left_panel.Name = "title_left_panel";
            this.title_left_panel.Size = new System.Drawing.Size(233, 40);
            this.title_left_panel.TabIndex = 0;
            this.title_left_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.title_left_panel_Paint);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.title.Location = new System.Drawing.Point(3, 8);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(117, 29);
            this.title.TabIndex = 0;
            this.title.Text = "Главная";
            // 
            // Panel_Controler
            // 
            this.Panel_Controler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_Controler.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Panel_Controler.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_Controler.Controls.Add(this.pictureBox1);
            this.Panel_Controler.Location = new System.Drawing.Point(242, 94);
            this.Panel_Controler.Name = "Panel_Controler";
            this.Panel_Controler.Size = new System.Drawing.Size(885, 542);
            this.Panel_Controler.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Rental_Point.Properties.Resources.load;
            this.pictureBox1.Location = new System.Drawing.Point(218, 139);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(459, 139);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.user_label);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Location = new System.Drawing.Point(747, 9);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(380, 79);
            this.panel3.TabIndex = 5;
            // 
            // user_label
            // 
            this.user_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.user_label.BackColor = System.Drawing.Color.Transparent;
            this.user_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.user_label.Location = new System.Drawing.Point(17, 11);
            this.user_label.Name = "user_label";
            this.user_label.Size = new System.Drawing.Size(278, 58);
            this.user_label.TabIndex = 6;
            this.user_label.Text = "Главная";
            this.user_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::Rental_Point.Properties.Resources.ы9;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox2.Location = new System.Drawing.Point(301, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(79, 79);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseClick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // title_time
            // 
            this.title_time.AutoSize = true;
            this.title_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.title_time.Location = new System.Drawing.Point(241, 20);
            this.title_time.Name = "title_time";
            this.title_time.Size = new System.Drawing.Size(242, 20);
            this.title_time.TabIndex = 6;
            this.title_time.Text = "До конца сеанса осталось: ";
            // 
            // time_num
            // 
            this.time_num.AutoSize = true;
            this.time_num.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.time_num.Location = new System.Drawing.Point(489, 21);
            this.time_num.Name = "time_num";
            this.time_num.Size = new System.Drawing.Size(73, 20);
            this.time_num.TabIndex = 7;
            this.time_num.Text = "00:00:00";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1135, 644);
            this.Controls.Add(this.time_num);
            this.Controls.Add(this.title_time);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.left_panel);
            this.Controls.Add(this.Panel_Controler);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главная";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Main_Paint);
            this.left_panel.ResumeLayout(false);
            this.bottom_left_panel.ResumeLayout(false);
            this.main_left_panel.ResumeLayout(false);
            this.title_left_panel.ResumeLayout(false);
            this.title_left_panel.PerformLayout();
            this.Panel_Controler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel left_panel;
        private System.Windows.Forms.Panel main_left_panel;
        private System.Windows.Forms.Panel title_left_panel;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button Logins_system;
        private System.Windows.Forms.Button Order_add;
        private System.Windows.Forms.Button main_button;
        private System.Windows.Forms.Button Services;
        private System.Windows.Forms.Panel bottom_left_panel;
        private System.Windows.Forms.Button login_out;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel Panel_Controler;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label user_label;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label title_time;
        private System.Windows.Forms.Label time_num;
        private System.Windows.Forms.Button Employees;
        private System.Windows.Forms.Button Order;
        private System.Windows.Forms.Button Customers;
        private System.Windows.Forms.Button Charts;
    }
}