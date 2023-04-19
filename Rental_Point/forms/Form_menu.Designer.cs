
namespace Rental_Point
{
    partial class Form_menu
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
            this.menu_form = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menu_form.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu_form
            // 
            this.menu_form.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.menu_form.Controls.Add(this.panel1);
            this.menu_form.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menu_form.Location = new System.Drawing.Point(0, 0);
            this.menu_form.Name = "menu_form";
            this.menu_form.Size = new System.Drawing.Size(276, 203);
            this.menu_form.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 194);
            this.panel1.TabIndex = 15;
            // 
            // Form_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(276, 203);
            this.Controls.Add(this.menu_form);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_menu";
            this.Text = "Form_menu";
            this.Deactivate += new System.EventHandler(this.Form_menu_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_menu_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_menu_FormClosed);
            this.Load += new System.EventHandler(this.Form_menu_Load);
            this.menu_form.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel menu_form;
        private System.Windows.Forms.Panel panel1;
    }
}