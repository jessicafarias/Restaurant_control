namespace Tienda2
{
    partial class Ventas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ventas));
            this.txtCodigoBarras = new System.Windows.Forms.TextBox();
            this.CodigoDeBarras = new System.Windows.Forms.Label();
            this.listViewListaVenta = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnPagar = new System.Windows.Forms.Button();
            this.txtPagoCantidad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnQuitarProducto = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lableCambio = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // txtCodigoBarras
            // 
            this.txtCodigoBarras.Location = new System.Drawing.Point(370, 43);
            this.txtCodigoBarras.Name = "txtCodigoBarras";
            this.txtCodigoBarras.Size = new System.Drawing.Size(162, 20);
            this.txtCodigoBarras.TabIndex = 0;
            this.txtCodigoBarras.Click += new System.EventHandler(this.txtCodigoBarras_Click);
            this.txtCodigoBarras.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoBarras_KeyPress);
            // 
            // CodigoDeBarras
            // 
            this.CodigoDeBarras.AutoSize = true;
            this.CodigoDeBarras.Location = new System.Drawing.Point(66, 43);
            this.CodigoDeBarras.Name = "CodigoDeBarras";
            this.CodigoDeBarras.Size = new System.Drawing.Size(87, 13);
            this.CodigoDeBarras.TabIndex = 1;
            this.CodigoDeBarras.Text = "Codigo de barras";
            // 
            // listViewListaVenta
            // 
            this.listViewListaVenta.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewListaVenta.FullRowSelect = true;
            this.listViewListaVenta.GridLines = true;
            this.listViewListaVenta.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewListaVenta.LabelWrap = false;
            this.listViewListaVenta.Location = new System.Drawing.Point(69, 102);
            this.listViewListaVenta.Name = "listViewListaVenta";
            this.listViewListaVenta.Size = new System.Drawing.Size(422, 196);
            this.listViewListaVenta.TabIndex = 3;
            this.listViewListaVenta.UseCompatibleStateImageBehavior = false;
            this.listViewListaVenta.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Clave";
            this.columnHeader1.Width = 65;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Producto";
            this.columnHeader2.Width = 230;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Precio";
            this.columnHeader3.Width = 200;
            // 
            // btnPagar
            // 
            this.btnPagar.Location = new System.Drawing.Point(359, 332);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(183, 89);
            this.btnPagar.TabIndex = 3;
            this.btnPagar.Text = "PAGAR Y CALCULAR CAMBIO";
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // txtPagoCantidad
            // 
            this.txtPagoCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPagoCantidad.Location = new System.Drawing.Point(154, 377);
            this.txtPagoCantidad.Name = "txtPagoCantidad";
            this.txtPagoCantidad.Size = new System.Drawing.Size(177, 44);
            this.txtPagoCantidad.TabIndex = 2;
            this.txtPagoCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPagoCantidad_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 327);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 37);
            this.label2.TabIndex = 6;
            this.label2.Text = "TOTAL";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.Location = new System.Drawing.Point(251, 327);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(80, 37);
            this.labelTotal.TabIndex = 7;
            this.labelTotal.Text = "0.00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(47, 380);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 37);
            this.label4.TabIndex = 7;
            this.label4.Text = "Pago";
            // 
            // btnQuitarProducto
            // 
            this.btnQuitarProducto.Location = new System.Drawing.Point(497, 102);
            this.btnQuitarProducto.Name = "btnQuitarProducto";
            this.btnQuitarProducto.Size = new System.Drawing.Size(84, 196);
            this.btnQuitarProducto.TabIndex = 8;
            this.btnQuitarProducto.Text = "Borrar productos seleccionados";
            this.btnQuitarProducto.UseVisualStyleBackColor = true;
            this.btnQuitarProducto.Click += new System.EventHandler(this.btnQuitarProducto_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(190, 66);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(342, 20);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.Click += new System.EventHandler(this.txtNombre_Click);
            this.txtNombre.DoubleClick += new System.EventHandler(this.txtNombre_DoubleClick);
            this.txtNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNombre_KeyDown);
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Nombre del producto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(159, 327);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 37);
            this.label1.TabIndex = 6;
            this.label1.Text = "$";
            // 
            // lableCambio
            // 
            this.lableCambio.AutoSize = true;
            this.lableCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCambio.Location = new System.Drawing.Point(455, 468);
            this.lableCambio.Name = "lableCambio";
            this.lableCambio.Size = new System.Drawing.Size(80, 37);
            this.lableCambio.TabIndex = 7;
            this.lableCambio.Text = "0.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(414, 468);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 37);
            this.label6.TabIndex = 6;
            this.label6.Text = "$";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(251, 587);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 37);
            this.label7.TabIndex = 7;
            this.label7.Text = "0.00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(280, 468);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 37);
            this.label8.TabIndex = 7;
            this.label8.Text = "Cambio";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // Ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 562);
            this.Controls.Add(this.btnQuitarProducto);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lableCambio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPagoCantidad);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.listViewListaVenta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.CodigoDeBarras);
            this.Controls.Add(this.txtCodigoBarras);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Ventas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dialogo de ventas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCodigoBarras;
        private System.Windows.Forms.Label CodigoDeBarras;
        private System.Windows.Forms.ListView listViewListaVenta;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.TextBox txtPagoCantidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnQuitarProducto;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lableCambio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}