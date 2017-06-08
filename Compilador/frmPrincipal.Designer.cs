namespace Compilador
{
    partial class frmPrincipal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.txterrores = new System.Windows.Forms.TextBox();
            this.Dgv_Listatoken = new System.Windows.Forms.DataGridView();
            this.Rtb_errores = new System.Windows.Forms.DataGridView();
            this.TC_Pestañas = new System.Windows.Forms.TabControl();
            this.Panel_cabecera = new System.Windows.Forms.Panel();
            this.Panel_cerrar = new System.Windows.Forms.Panel();
            this.Panel_Limpiar = new System.Windows.Forms.Panel();
            this.Panel_compilar = new System.Windows.Forms.Panel();
            this.Panel_nuevo = new System.Windows.Forms.Panel();
            this.Panel_abrir = new System.Windows.Forms.Panel();
            this.Panel_guardarcomo = new System.Windows.Forms.Panel();
            this.Panel_guardar = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Listatoken)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rtb_errores)).BeginInit();
            this.Panel_cabecera.SuspendLayout();
            this.SuspendLayout();
            // 
            // txterrores
            // 
            this.txterrores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txterrores.Location = new System.Drawing.Point(64, 565);
            this.txterrores.Multiline = true;
            this.txterrores.Name = "txterrores";
            this.txterrores.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txterrores.Size = new System.Drawing.Size(705, 164);
            this.txterrores.TabIndex = 15;
            // 
            // Dgv_Listatoken
            // 
            this.Dgv_Listatoken.AllowUserToAddRows = false;
            this.Dgv_Listatoken.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PaleGreen;
            this.Dgv_Listatoken.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv_Listatoken.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Listatoken.Location = new System.Drawing.Point(835, 115);
            this.Dgv_Listatoken.MultiSelect = false;
            this.Dgv_Listatoken.Name = "Dgv_Listatoken";
            this.Dgv_Listatoken.ReadOnly = true;
            this.Dgv_Listatoken.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_Listatoken.Size = new System.Drawing.Size(461, 444);
            this.Dgv_Listatoken.TabIndex = 14;
            // 
            // Rtb_errores
            // 
            this.Rtb_errores.AllowUserToAddRows = false;
            this.Rtb_errores.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.PaleGreen;
            this.Rtb_errores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.Rtb_errores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Rtb_errores.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Rtb_errores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Rtb_errores.Location = new System.Drawing.Point(835, 565);
            this.Rtb_errores.MultiSelect = false;
            this.Rtb_errores.Name = "Rtb_errores";
            this.Rtb_errores.ReadOnly = true;
            this.Rtb_errores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Rtb_errores.Size = new System.Drawing.Size(461, 164);
            this.Rtb_errores.TabIndex = 13;
            // 
            // TC_Pestañas
            // 
            this.TC_Pestañas.Location = new System.Drawing.Point(64, 93);
            this.TC_Pestañas.Name = "TC_Pestañas";
            this.TC_Pestañas.SelectedIndex = 0;
            this.TC_Pestañas.Size = new System.Drawing.Size(705, 466);
            this.TC_Pestañas.TabIndex = 12;
            // 
            // Panel_cabecera
            // 
            this.Panel_cabecera.BackColor = System.Drawing.Color.Transparent;
            this.Panel_cabecera.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel_cabecera.Controls.Add(this.Panel_cerrar);
            this.Panel_cabecera.Controls.Add(this.Panel_Limpiar);
            this.Panel_cabecera.Controls.Add(this.Panel_compilar);
            this.Panel_cabecera.Controls.Add(this.Panel_nuevo);
            this.Panel_cabecera.Controls.Add(this.Panel_abrir);
            this.Panel_cabecera.Controls.Add(this.Panel_guardarcomo);
            this.Panel_cabecera.Controls.Add(this.Panel_guardar);
            this.Panel_cabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_cabecera.Location = new System.Drawing.Point(0, 0);
            this.Panel_cabecera.Name = "Panel_cabecera";
            this.Panel_cabecera.Size = new System.Drawing.Size(1370, 61);
            this.Panel_cabecera.TabIndex = 16;
            // 
            // Panel_cerrar
            // 
            this.Panel_cerrar.BackColor = System.Drawing.Color.Transparent;
            this.Panel_cerrar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel_cerrar.BackgroundImage")));
            this.Panel_cerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel_cerrar.Location = new System.Drawing.Point(1306, 3);
            this.Panel_cerrar.Name = "Panel_cerrar";
            this.Panel_cerrar.Size = new System.Drawing.Size(50, 50);
            this.Panel_cerrar.TabIndex = 3;
            this.Panel_cerrar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Panel_cerrar_MouseClick);
            this.Panel_cerrar.MouseLeave += new System.EventHandler(this.Panel_cerrar_MouseLeave);
            this.Panel_cerrar.MouseHover += new System.EventHandler(this.Panel_cerrar_MouseHover);
            // 
            // Panel_Limpiar
            // 
            this.Panel_Limpiar.BackColor = System.Drawing.Color.Transparent;
            this.Panel_Limpiar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel_Limpiar.BackgroundImage")));
            this.Panel_Limpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel_Limpiar.Location = new System.Drawing.Point(271, 3);
            this.Panel_Limpiar.Name = "Panel_Limpiar";
            this.Panel_Limpiar.Size = new System.Drawing.Size(50, 50);
            this.Panel_Limpiar.TabIndex = 1;
            this.Panel_Limpiar.MouseLeave += new System.EventHandler(this.Panel_Limpiar_MouseLeave);
            this.Panel_Limpiar.MouseHover += new System.EventHandler(this.Panel_Limpiar_MouseHover);
            // 
            // Panel_compilar
            // 
            this.Panel_compilar.BackColor = System.Drawing.Color.Transparent;
            this.Panel_compilar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel_compilar.BackgroundImage")));
            this.Panel_compilar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel_compilar.Location = new System.Drawing.Point(337, 3);
            this.Panel_compilar.Name = "Panel_compilar";
            this.Panel_compilar.Size = new System.Drawing.Size(50, 50);
            this.Panel_compilar.TabIndex = 1;
            this.Panel_compilar.MouseLeave += new System.EventHandler(this.Panel_compilar_MouseLeave);
            this.Panel_compilar.MouseHover += new System.EventHandler(this.Panel_compilar_MouseHover);
            // 
            // Panel_nuevo
            // 
            this.Panel_nuevo.BackColor = System.Drawing.Color.Transparent;
            this.Panel_nuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel_nuevo.BackgroundImage")));
            this.Panel_nuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel_nuevo.Location = new System.Drawing.Point(6, 3);
            this.Panel_nuevo.Name = "Panel_nuevo";
            this.Panel_nuevo.Size = new System.Drawing.Size(50, 50);
            this.Panel_nuevo.TabIndex = 0;
            this.Panel_nuevo.MouseLeave += new System.EventHandler(this.Panel_nuevo_MouseLeave);
            this.Panel_nuevo.MouseHover += new System.EventHandler(this.Panel_nuevo_MouseHover);
            // 
            // Panel_abrir
            // 
            this.Panel_abrir.BackColor = System.Drawing.Color.Transparent;
            this.Panel_abrir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel_abrir.BackgroundImage")));
            this.Panel_abrir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel_abrir.Location = new System.Drawing.Point(71, 3);
            this.Panel_abrir.Name = "Panel_abrir";
            this.Panel_abrir.Size = new System.Drawing.Size(50, 50);
            this.Panel_abrir.TabIndex = 1;
            this.Panel_abrir.MouseLeave += new System.EventHandler(this.Panel_abrir_MouseLeave);
            this.Panel_abrir.MouseHover += new System.EventHandler(this.Panel_abrir_MouseHover);
            // 
            // Panel_guardarcomo
            // 
            this.Panel_guardarcomo.BackColor = System.Drawing.Color.Transparent;
            this.Panel_guardarcomo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel_guardarcomo.BackgroundImage")));
            this.Panel_guardarcomo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel_guardarcomo.Location = new System.Drawing.Point(204, 3);
            this.Panel_guardarcomo.Name = "Panel_guardarcomo";
            this.Panel_guardarcomo.Size = new System.Drawing.Size(50, 50);
            this.Panel_guardarcomo.TabIndex = 2;
            this.Panel_guardarcomo.MouseLeave += new System.EventHandler(this.Panel_guardarcomo_MouseLeave);
            this.Panel_guardarcomo.MouseHover += new System.EventHandler(this.Panel_guardarcomo_MouseHover);
            // 
            // Panel_guardar
            // 
            this.Panel_guardar.BackColor = System.Drawing.Color.Transparent;
            this.Panel_guardar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel_guardar.BackgroundImage")));
            this.Panel_guardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel_guardar.Location = new System.Drawing.Point(138, 3);
            this.Panel_guardar.Name = "Panel_guardar";
            this.Panel_guardar.Size = new System.Drawing.Size(50, 50);
            this.Panel_guardar.TabIndex = 1;
            this.Panel_guardar.MouseLeave += new System.EventHandler(this.Panel_guardar_MouseLeave);
            this.Panel_guardar.MouseHover += new System.EventHandler(this.Panel_guardar_MouseHover);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1370, 772);
            this.Controls.Add(this.Panel_cabecera);
            this.Controls.Add(this.txterrores);
            this.Controls.Add(this.Dgv_Listatoken);
            this.Controls.Add(this.Rtb_errores);
            this.Controls.Add(this.TC_Pestañas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPrincipal";
            this.Text = "Compilador";
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Listatoken)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rtb_errores)).EndInit();
            this.Panel_cabecera.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txterrores;
        private System.Windows.Forms.DataGridView Dgv_Listatoken;
        private System.Windows.Forms.DataGridView Rtb_errores;
        private System.Windows.Forms.TabControl TC_Pestañas;
        private System.Windows.Forms.Panel Panel_cabecera;
        private System.Windows.Forms.Panel Panel_Limpiar;
        private System.Windows.Forms.Panel Panel_compilar;
        private System.Windows.Forms.Panel Panel_nuevo;
        private System.Windows.Forms.Panel Panel_abrir;
        private System.Windows.Forms.Panel Panel_guardarcomo;
        private System.Windows.Forms.Panel Panel_guardar;
        private System.Windows.Forms.Panel Panel_cerrar;
    }
}