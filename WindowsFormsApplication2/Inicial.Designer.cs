namespace Tienda2
{
    partial class Inicial
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicial));
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retirosDeCajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estatusDeCajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinEngine1
            // 
            this.skinEngine1.SerialNumber = "U4N2UjLguUZs33UR+Vy47JAZ81t2fjIFvut28vc5oHiVeivGb/NZMA==";
            this.skinEngine1.SkinFile = "C:\\Users\\Jessica\\Documents\\libros\\Visual Studio 2012\\Componentes Graficos Vb2\\SKI" +
    "N NET 2010 WIN 7\\SkinVS.NET\\MP10\\MP10.ssk";
            this.skinEngine1.SkinStreamMain = ((System.IO.Stream)(resources.GetObject("skinEngine1.SkinStreamMain")));
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(866, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.retirosDeCajaToolStripMenuItem,
            this.estatusDeCajaToolStripMenuItem});
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // retirosDeCajaToolStripMenuItem
            // 
            this.retirosDeCajaToolStripMenuItem.Name = "retirosDeCajaToolStripMenuItem";
            this.retirosDeCajaToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.retirosDeCajaToolStripMenuItem.Text = "Modificaciones de caja chica";
            this.retirosDeCajaToolStripMenuItem.Click += new System.EventHandler(this.retirosDeCajaToolStripMenuItem_Click);
            // 
            // estatusDeCajaToolStripMenuItem
            // 
            this.estatusDeCajaToolStripMenuItem.Name = "estatusDeCajaToolStripMenuItem";
            this.estatusDeCajaToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.estatusDeCajaToolStripMenuItem.Text = "Ver caja";
            this.estatusDeCajaToolStripMenuItem.Click += new System.EventHandler(this.estatusDeCajaToolStripMenuItem_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Image = global::Tienda2.Properties.Resources.imageres_dll_007_10;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button4.Location = new System.Drawing.Point(53, 85);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(377, 353);
            this.button4.TabIndex = 0;
            this.button4.Text = "Inventario";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(484, 244);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(328, 194);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ventas";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = global::Tienda2.Properties.Resources.search_good_icon;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.Location = new System.Drawing.Point(484, 85);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(328, 148);
            this.button3.TabIndex = 2;
            this.button3.Text = "Registro producto nuevo/Modificar precios y productos";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Inicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 488);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Inicial";
            this.Text = "La IV estación";
            this.Load += new System.EventHandler(this.Inicial_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retirosDeCajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estatusDeCajaToolStripMenuItem;
        private System.Windows.Forms.Button button3;
    }
}

