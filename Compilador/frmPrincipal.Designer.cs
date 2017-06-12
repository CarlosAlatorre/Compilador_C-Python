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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Dgv_Listatoken = new System.Windows.Forms.DataGridView();
            this.Rtb_errores = new System.Windows.Forms.DataGridView();
            this.token = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.error = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TC_Pestañas = new System.Windows.Forms.TabControl();
            this.Panel_cabecera = new System.Windows.Forms.Panel();
            this.Panel_cerrar = new System.Windows.Forms.Panel();
            this.Panel_Limpiar = new System.Windows.Forms.Panel();
            this.Panel_compilar = new System.Windows.Forms.Panel();
            this.Panel_nuevo = new System.Windows.Forms.Panel();
            this.Panel_abrir = new System.Windows.Forms.Panel();
            this.Panel_guardarcomo = new System.Windows.Forms.Panel();
            this.Panel_guardar = new System.Windows.Forms.Panel();
            this.GRID_TABLE_SYMBOLS = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lexe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.list_erroresSemanticos = new System.Windows.Forms.ListBox();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idtoken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ren = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Listatoken)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rtb_errores)).BeginInit();
            this.Panel_cabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GRID_TABLE_SYMBOLS)).BeginInit();
            this.SuspendLayout();
            // 
            // Dgv_Listatoken
            // 
            this.Dgv_Listatoken.AllowUserToAddRows = false;
            this.Dgv_Listatoken.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PaleGreen;
            this.Dgv_Listatoken.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv_Listatoken.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Listatoken.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipo,
            this.idtoken,
            this.lex,
            this.ren});
            this.Dgv_Listatoken.Location = new System.Drawing.Point(565, 113);
            this.Dgv_Listatoken.MultiSelect = false;
            this.Dgv_Listatoken.Name = "Dgv_Listatoken";
            this.Dgv_Listatoken.ReadOnly = true;
            this.Dgv_Listatoken.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_Listatoken.Size = new System.Drawing.Size(443, 446);
            this.Dgv_Listatoken.TabIndex = 14;
            this.Dgv_Listatoken.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Listatoken_CellContentClick);
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
            this.Rtb_errores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.token,
            this.error});
            this.Rtb_errores.Location = new System.Drawing.Point(745, 579);
            this.Rtb_errores.MultiSelect = false;
            this.Rtb_errores.Name = "Rtb_errores";
            this.Rtb_errores.ReadOnly = true;
            this.Rtb_errores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Rtb_errores.Size = new System.Drawing.Size(613, 166);
            this.Rtb_errores.TabIndex = 13;
            // 
            // token
            // 
            this.token.HeaderText = "Token";
            this.token.Name = "token";
            this.token.ReadOnly = true;
            // 
            // error
            // 
            this.error.HeaderText = "Error";
            this.error.Name = "error";
            this.error.ReadOnly = true;
            // 
            // TC_Pestañas
            // 
            this.TC_Pestañas.Location = new System.Drawing.Point(12, 93);
            this.TC_Pestañas.Name = "TC_Pestañas";
            this.TC_Pestañas.SelectedIndex = 0;
            this.TC_Pestañas.Size = new System.Drawing.Size(547, 466);
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
            this.Panel_Limpiar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Panel_Limpiar_MouseClick);
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
            this.Panel_compilar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Panel_compilar_MouseClick);
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
            this.Panel_nuevo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Panel_nuevo_MouseClick);
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
            this.Panel_abrir.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Panel_abrir_MouseClick);
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
            this.Panel_guardarcomo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Panel_guardarcomo_MouseClick);
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
            this.Panel_guardar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Panel_guardar_MouseClick);
            this.Panel_guardar.MouseLeave += new System.EventHandler(this.Panel_guardar_MouseLeave);
            this.Panel_guardar.MouseHover += new System.EventHandler(this.Panel_guardar_MouseHover);
            // 
            // GRID_TABLE_SYMBOLS
            // 
            this.GRID_TABLE_SYMBOLS.AllowUserToAddRows = false;
            this.GRID_TABLE_SYMBOLS.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.PaleGreen;
            this.GRID_TABLE_SYMBOLS.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.GRID_TABLE_SYMBOLS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GRID_TABLE_SYMBOLS.BackgroundColor = System.Drawing.Color.DarkGray;
            this.GRID_TABLE_SYMBOLS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GRID_TABLE_SYMBOLS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.lexe});
            this.GRID_TABLE_SYMBOLS.Location = new System.Drawing.Point(1014, 113);
            this.GRID_TABLE_SYMBOLS.MultiSelect = false;
            this.GRID_TABLE_SYMBOLS.Name = "GRID_TABLE_SYMBOLS";
            this.GRID_TABLE_SYMBOLS.ReadOnly = true;
            this.GRID_TABLE_SYMBOLS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GRID_TABLE_SYMBOLS.Size = new System.Drawing.Size(344, 446);
            this.GRID_TABLE_SYMBOLS.TabIndex = 17;
            // 
            // id
            // 
            this.id.HeaderText = "Tipo";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // lexe
            // 
            this.lexe.HeaderText = "Lexema";
            this.lexe.Name = "lexe";
            this.lexe.ReadOnly = true;
            // 
            // list_erroresSemanticos
            // 
            this.list_erroresSemanticos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list_erroresSemanticos.FormattingEnabled = true;
            this.list_erroresSemanticos.HorizontalScrollbar = true;
            this.list_erroresSemanticos.ItemHeight = 18;
            this.list_erroresSemanticos.Location = new System.Drawing.Point(12, 579);
            this.list_erroresSemanticos.Name = "list_erroresSemanticos";
            this.list_erroresSemanticos.ScrollAlwaysVisible = true;
            this.list_erroresSemanticos.Size = new System.Drawing.Size(727, 166);
            this.list_erroresSemanticos.TabIndex = 18;
            // 
            // tipo
            // 
            this.tipo.HeaderText = "Tipo";
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            // 
            // idtoken
            // 
            this.idtoken.HeaderText = "Token ID";
            this.idtoken.Name = "idtoken";
            this.idtoken.ReadOnly = true;
            // 
            // lex
            // 
            this.lex.HeaderText = "Lexema";
            this.lex.Name = "lex";
            this.lex.ReadOnly = true;
            // 
            // ren
            // 
            this.ren.HeaderText = "Renglon";
            this.ren.Name = "ren";
            this.ren.ReadOnly = true;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1370, 772);
            this.Controls.Add(this.list_erroresSemanticos);
            this.Controls.Add(this.GRID_TABLE_SYMBOLS);
            this.Controls.Add(this.Panel_cabecera);
            this.Controls.Add(this.Dgv_Listatoken);
            this.Controls.Add(this.Rtb_errores);
            this.Controls.Add(this.TC_Pestañas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPrincipal";
            this.Text = "Compilador";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Listatoken)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rtb_errores)).EndInit();
            this.Panel_cabecera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GRID_TABLE_SYMBOLS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

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
        private System.Windows.Forms.DataGridViewTextBoxColumn token;
        private System.Windows.Forms.DataGridViewTextBoxColumn error;
        private System.Windows.Forms.DataGridView GRID_TABLE_SYMBOLS;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn lexe;
        private System.Windows.Forms.ListBox list_erroresSemanticos;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtoken;
        private System.Windows.Forms.DataGridViewTextBoxColumn lex;
        private System.Windows.Forms.DataGridViewTextBoxColumn ren;
    }
}