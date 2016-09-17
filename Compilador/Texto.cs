using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compilador
{
    public partial class Texto : Form
    {
        public Texto()
        {
            InitializeComponent();
            LISTA_TOKNS.AutoGenerateColumns = true;       
        }
        public int linea = 1;
        public void texto_editor(string archivo_texto)
        {
            editor.Text = archivo_texto;
        }
        private TabControl _tabCtrl;
        private TabPage _tabPag;

        public void Guardar()
        {

        }
        private void Texto_Load(object sender, EventArgs e)
        {
            
        }
        public TabControl TabCtrl
        {
            set { _tabCtrl = value; }
        }

        public TabPage TabPag
        {
            get
            {
                return _tabPag;
            }
            set
            {
                _tabPag = value;
            }
        }

        private void Texto_Activated(object sender, EventArgs e)
        {
            //Activate the corresponding Tabpage
            _tabCtrl.SelectedTab = _tabPag;

            if (!_tabCtrl.Visible)
            {
                _tabCtrl.Visible = true;
            }
        }

        private void editor_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //se crea un objeto de tipo savefiledialog que nos servira para guardar el archivo
            SaveFileDialog Save = new SaveFileDialog();
            System.IO.StreamWriter myStreamWriter = null;
            //al igual que para abrir el tipo de documentos aqui se especifica en que extenciones se puede guardar el archivo
            Save.Filter = "Python (*.py)|";
            Save.CheckPathExists = true;
            Save.Title = "Guardar como";
            Save.ShowDialog(this);
            try
            {
                //este codigo se utiliza para guardar el archivo de nuestro editor
                myStreamWriter = System.IO.File.AppendText(Save.FileName);
                myStreamWriter.Write(editor.Text);
                myStreamWriter.Flush();

            }
            catch (Exception) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //se crea un objeto de openfiledialogo que nos servira para abrir archivos
            OpenFileDialog Open = new OpenFileDialog();
            System.IO.StreamReader myStreamReader = null;
            //se especifica que tipos de archivos se podran abrir y se verifica si existe
            Open.Filter = "Python [*.py]|";
            Open.CheckFileExists = true;
            Open.Title = "Abrir Archivo de Python";
            Open.ShowDialog(this);
            try
            {
                //este codigo se utiliza para que se pueda pueda mostrar la informacion del archivo que queremos abrir en el rich textbox
                Open.OpenFile();
                myStreamReader = System.IO.File.OpenText(Open.FileName);
                editor.Text = myStreamReader.ReadToEnd();

            }
            catch (Exception) { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void button3_Click_1(object sender, EventArgs e)
        {

            string fuente = editor.Text;
            Lexico llenar = new Lexico();

            llenar.GRID_TOKENS = LISTA_TOKNS;
            llenar.GRID_ERRORESS = GRID_ERR;
            llenar.analizarLexico(fuente);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string fuente = editor.Text;
            Lexico llenar = new Lexico();

            llenar.GRID_TOKENS = LISTA_TOKNS;
            llenar.GRID_ERRORESS = GRID_ERR;
            llenar.analizarLexico(fuente);
            Sintactico llamar = new Sintactico();
            GRID_VAR.Rows.Clear();
            GRID_ERR.Rows.Clear();
            llamar.GRID_ERRORES = GRID_ERR;
            llamar.GRID_VARS = GRID_VAR;
            llamar.Sintactic();
        }

        private void LISTA_TOKNS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGrid_VarDeclaradas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
