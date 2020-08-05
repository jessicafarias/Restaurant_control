namespace Tienda2
{
    partial class FormVer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVer));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDineroTotal = new System.Windows.Forms.Label();
            this.linkVerMovimientos = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(178, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dinero en caja";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(201, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 37);
            this.label2.TabIndex = 0;
            this.label2.Text = "$";
            // 
            // lblDineroTotal
            // 
            this.lblDineroTotal.AutoSize = true;
            this.lblDineroTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDineroTotal.Location = new System.Drawing.Point(275, 74);
            this.lblDineroTotal.Name = "lblDineroTotal";
            this.lblDineroTotal.Size = new System.Drawing.Size(80, 37);
            this.lblDineroTotal.TabIndex = 0;
            this.lblDineroTotal.Text = "0.00";
            // 
            // linkVerMovimientos
            // 
            this.linkVerMovimientos.AutoSize = true;
            this.linkVerMovimientos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkVerMovimientos.Location = new System.Drawing.Point(410, 129);
            this.linkVerMovimientos.Name = "linkVerMovimientos";
            this.linkVerMovimientos.Size = new System.Drawing.Size(171, 25);
            this.linkVerMovimientos.TabIndex = 1;
            this.linkVerMovimientos.TabStop = true;
            this.linkVerMovimientos.Text = "Ver movimientos";
            this.linkVerMovimientos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkVerMovimientos_LinkClicked);
            // 
            // FormVer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 166);
            this.Controls.Add(this.linkVerMovimientos);
            this.Controls.Add(this.lblDineroTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormVer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormVer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDineroTotal;
        private System.Windows.Forms.LinkLabel linkVerMovimientos;
    }
}