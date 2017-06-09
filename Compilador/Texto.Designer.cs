namespace Compilador
{
    partial class Texto
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Sintactico = new System.Windows.Forms.Button();
            this.LISTA_TOKNS = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LINEA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GRID_ERR = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editor = new System.Windows.Forms.TextBox();
            this.GRID_VAR = new System.Windows.Forms.DataGridView();
            this.TIPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LEXEMA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.LISTA_TOKNS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRID_ERR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRID_VAR)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(498, 283);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(498, 312);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Examinar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(498, 341);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Lexico";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // Sintactico
            // 
            this.Sintactico.Location = new System.Drawing.Point(498, 370);
            this.Sintactico.Name = "Sintactico";
            this.Sintactico.Size = new System.Drawing.Size(75, 23);
            this.Sintactico.TabIndex = 5;
            this.Sintactico.Text = "Sintactico";
            this.Sintactico.UseVisualStyleBackColor = true;
            this.Sintactico.Click += new System.EventHandler(this.button4_Click);
            // 
            // LISTA_TOKNS
            // 
            this.LISTA_TOKNS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LISTA_TOKNS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column2,
            this.Column1,
            this.LINEA});
            this.LISTA_TOKNS.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LISTA_TOKNS.Location = new System.Drawing.Point(0, 448);
            this.LISTA_TOKNS.Name = "LISTA_TOKNS";
            this.LISTA_TOKNS.Size = new System.Drawing.Size(1155, 167);
            this.LISTA_TOKNS.TabIndex = 6;
            this.LISTA_TOKNS.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LISTA_TOKNS_CellContentClick);
            // 
            // Column5
            // 
            this.Column5.HeaderText = "TIPO";
            this.Column5.Name = "Column5";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "LEXEMA";
            this.Column2.Name = "Column2";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "TOKEN";
            this.Column1.Name = "Column1";
            // 
            // LINEA
            // 
            this.LINEA.DataPropertyName = "LINEA";
            this.LINEA.HeaderText = "LINEA";
            this.LINEA.Name = "LINEA";
            // 
            // GRID_ERR
            // 
            this.GRID_ERR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GRID_ERR.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4});
            this.GRID_ERR.Dock = System.Windows.Forms.DockStyle.Right;
            this.GRID_ERR.Location = new System.Drawing.Point(893, 0);
            this.GRID_ERR.Name = "GRID_ERR";
            this.GRID_ERR.Size = new System.Drawing.Size(262, 448);
            this.GRID_ERR.TabIndex = 7;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "TOKEN";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "ERROR";
            this.Column4.Name = "Column4";
            this.Column4.Width = 200;
            // 
            // editor
            // 
            this.editor.Dock = System.Windows.Forms.DockStyle.Top;
            this.editor.Location = new System.Drawing.Point(0, 0);
            this.editor.Multiline = true;
            this.editor.Name = "editor";
            this.editor.Size = new System.Drawing.Size(893, 251);
            this.editor.TabIndex = 8;
            // 
            // GRID_VAR
            // 
            this.GRID_VAR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GRID_VAR.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TIPO,
            this.LEXEMA,
            this.DATO});
            this.GRID_VAR.Dock = System.Windows.Forms.DockStyle.Right;
            this.GRID_VAR.Location = new System.Drawing.Point(468, 251);
            this.GRID_VAR.Name = "GRID_VAR";
            this.GRID_VAR.Size = new System.Drawing.Size(425, 197);
            this.GRID_VAR.TabIndex = 9;
            this.GRID_VAR.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGrid_VarDeclaradas_CellContentClick);
            // 
            // TIPO
            // 
            this.TIPO.HeaderText = "TIPO";
            this.TIPO.Name = "TIPO";
            // 
            // LEXEMA
            // 
            this.LEXEMA.HeaderText = "LEXEMA";
            this.LEXEMA.Name = "LEXEMA";
            // 
            // DATO
            // 
            this.DATO.HeaderText = "DATO";
            this.DATO.Name = "DATO";
            // 
            // Texto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 615);
            this.Controls.Add(this.GRID_VAR);
            this.Controls.Add(this.editor);
            this.Controls.Add(this.GRID_ERR);
            this.Controls.Add(this.LISTA_TOKNS);
            this.Controls.Add(this.Sintactico);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Texto";
            this.Text = "Texto";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.Texto_Activated);
            this.Load += new System.EventHandler(this.Texto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LISTA_TOKNS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRID_ERR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRID_VAR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button Sintactico;
        private System.Windows.Forms.DataGridView LISTA_TOKNS;
        private System.Windows.Forms.DataGridView GRID_ERR;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn LINEA;
        private System.Windows.Forms.TextBox editor;
        private System.Windows.Forms.DataGridView GRID_VAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn LEXEMA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATO;
    }
}