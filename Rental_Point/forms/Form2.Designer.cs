﻿
namespace Rental_Point
{
    partial class Form2
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
            this.control_charts1 = new Rental_Point.Control_charts();
            this.SuspendLayout();
            // 
            // control_charts1
            // 
            this.control_charts1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.control_charts1.Location = new System.Drawing.Point(0, 0);
            this.control_charts1.Name = "control_charts1";
            this.control_charts1.Size = new System.Drawing.Size(972, 631);
            this.control_charts1.TabIndex = 0;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 631);
            this.Controls.Add(this.control_charts1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private Control_charts control_charts1;
    }
}