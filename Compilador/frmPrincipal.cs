using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using ScintillaNET;
using System.IO;

namespace Compilador
{
    public partial class frmPrincipal : Form
    {
        ArrayList listapest = new ArrayList();
        List<Scintilla> listatxt = new List<Scintilla>();
        int numeropest = 1;
        int estado, columna, renglon = 0;
        private string lexema = string.Empty;

        public frmPrincipal()
        {
            InitializeComponent();
            Panel_nuevo_MouseClick(null, null);
        }

        public string contenido()
        {

            int a = 0;

            TabPage pestaña = TC_Pestañas.SelectedTab;
            for (int i = 0; i < listapest.Count; i++)
            {
                if (pestaña == listapest[i])
                {
                    a = i;
                    break;
                }
            }
            string texto = listatxt[a].Text;
            texto = texto.Trim();
            return texto;
        }

        public string ruta()
        {
            TabPage pestaña = TC_Pestañas.SelectedTab;
            return pestaña.Text;
        }

        public void creartxt(String opcion, StreamReader arc, TabPage nuevapestaña)
        {
            Scintilla scintilla = new Scintilla();

            /* Configuración inicial del cuadro de texto de Scintilla
            scintilla.StyleResetDefault();
            scintilla.Styles[Style.Default].Font = "Consolas";
            scintilla.Styles[Style.Default].Size = 10;
            scintilla.StyleClearAll();
            scintilla.VScrollBar = true;

            // Configuración de estilo de Pascal/Delphi
            scintilla.Styles[Style.Pascal.CommentLine].ForeColor = Color.DarkCyan;
            //scintilla.Styles[Style.Pascal.Comment].ForeColor = Color.FromArgb(0, 128, 0);
            scintilla.Styles[Style.Pascal.Comment2].ForeColor = Color.FromArgb(0, 128, 0);
            scintilla.Styles[Style.Pascal.Number].ForeColor = Color.Orange;
            scintilla.Styles[Style.Pascal.Word].ForeColor = Color.Blue;
            scintilla.Styles[Style.Pascal.String].ForeColor = Color.FromArgb(163, 21, 21);
            scintilla.Styles[Style.Pascal.Character].ForeColor = Color.FromArgb(163, 21, 21);
            scintilla.Styles[Style.Pascal.Operator].ForeColor = Color.FromArgb(21, 104, 162);
            scintilla.SetKeywords(0, "and array as asm begin case class const constructor destructor dispinterface div do downto else end except exports file finalization finally for function goto if implementation in inherited initialization inline interface is label library mod nil not object of or out packed procedure program property raise record repeat resourcestring set shl shr string then threadvar to try type unit until uses var while with xor");
            scintilla.SetKeywords(1, "private protected public published automated at on");

            //scintilla.keyw

            scintilla.Styles[Style.Pascal.Identifier].ForeColor = Color.Black;
            scintilla.Styles[Style.Pascal.Default].ForeColor = Color.Crimson;
            //scintilla.Styles[Style.Pascal.


            //scintilla.Styles[Style.Sql.*/

            // Configuring the default style with properties
            // we have common to every lexer style saves time.
            scintilla.StyleResetDefault();
            scintilla.Styles[Style.Default].Font = "Consolas";
            scintilla.Styles[Style.Default].Size = 10;
            scintilla.StyleClearAll();

            // Configure the lexer styles
            scintilla.Styles[Style.Cpp.Default].ForeColor = Color.Silver;
            //scintilla.Styles[Style.Cpp.Identifier].ForeColor = Color.Black;
            scintilla.Styles[Style.Cpp.Comment].ForeColor = Color.FromArgb(0, 128, 0); // Green
            scintilla.Styles[Style.Cpp.CommentLine].ForeColor = Color.FromArgb(0, 128, 0); // Green
            scintilla.Styles[Style.Cpp.CommentLineDoc].ForeColor = Color.FromArgb(128, 128, 128); // Gray
            scintilla.Styles[Style.Cpp.Number].ForeColor = Color.Olive;
            scintilla.Styles[Style.Cpp.Word].ForeColor = Color.Blue;
            scintilla.Styles[Style.Cpp.Word2].ForeColor = Color.Blue;
            scintilla.Styles[Style.Cpp.String].ForeColor = Color.FromArgb(163, 21, 21); // Red
            scintilla.Styles[Style.Cpp.Character].ForeColor = Color.FromArgb(163, 21, 21); // Red
            scintilla.Styles[Style.Cpp.Verbatim].ForeColor = Color.FromArgb(163, 21, 21); // Red
            scintilla.Styles[Style.Cpp.StringEol].BackColor = Color.Pink;
            scintilla.Styles[Style.Cpp.Operator].ForeColor = Color.Purple;
            scintilla.Styles[Style.Cpp.Preprocessor].ForeColor = Color.Blue;
            scintilla.Lexer = Lexer.Pascal;

            // Set the keywords
            scintilla.SetKeywords(0, "writeln write data integer double io import and  array as asm begin case class const constructor destructor dispinterface div do downto else end except exports file final finalization finally for function goto if implementation in inherited initialization inline interface is label library mod nil not object of or out packed procedure program property raise record repeat resourcestring sealed set shl shr static string then threadvar to try type unit unsafe until uses var while with xor private protected public published automated at on true false boolean");
            scintilla.SetKeywords(1, "if for else");

            // Configuración del Lexer de Scintilla para Pascal
            //scintilla.Lexer = Lexer.Pascal;

            // Configuración de números de línea
            scintilla.Margins[0].Width = 40;
            scintilla.Styles[Style.LineNumber].Font = "Consolas";
            scintilla.Margins[0].Type = MarginType.Number;

            scintilla.Name = "archivo" + numeropest;

            //Tab_Scintilla.SelectedTab = scintilla.Name;
            //item.Focus();

            scintilla.Size = new System.Drawing.Size(700, 443);
            listatxt.Add(scintilla);
            nuevapestaña.Controls.Add(scintilla);
            if (opcion == "1")
            {
                listatxt.Add(scintilla);
                nuevapestaña.Controls.Add(scintilla);
            }
            else
            {
                scintilla.Text = arc.ReadToEnd();
                listatxt.Add(scintilla);
                nuevapestaña.Controls.Add(scintilla);
            }

        }

        private void Panel_cerrar_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void Panel_cerrar_MouseLeave(object sender, EventArgs e)
        {
            Panel_cerrar.BackgroundImage = Compilador.Properties.Resources.cerrar0;
        }

        private void Panel_cerrar_MouseHover(object sender, EventArgs e)
        {
            Panel_cerrar.BackgroundImage = Compilador.Properties.Resources.cerrar1;
        }

        private void Panel_compilar_MouseHover(object sender, EventArgs e)
        {
            Panel_compilar.BackgroundImage = Compilador.Properties.Resources.compilar11;
        }

        private void Panel_compilar_MouseLeave(object sender, EventArgs e)
        {
            Panel_compilar.BackgroundImage = Compilador.Properties.Resources.compilar0;
        }

        private void Panel_Limpiar_MouseHover(object sender, EventArgs e)
        {
            Panel_Limpiar.BackgroundImage = Compilador.Properties.Resources.limpiar1;
        }

        private void Panel_Limpiar_MouseLeave(object sender, EventArgs e)
        {
            Panel_Limpiar.BackgroundImage = Compilador.Properties.Resources.limpiar0;
        }

        private void Panel_guardarcomo_MouseLeave(object sender, EventArgs e)
        {
            Panel_guardarcomo.BackgroundImage = Compilador.Properties.Resources.guardar_como0;
        }

        private void Panel_guardarcomo_MouseHover(object sender, EventArgs e)
        {
            Panel_guardarcomo.BackgroundImage = Compilador.Properties.Resources.guardar_como1;
        }

        private void Panel_guardar_MouseLeave(object sender, EventArgs e)
        {
            Panel_guardar.BackgroundImage = Compilador.Properties.Resources.guardar0;
        }

        private void Panel_abrir_MouseHover(object sender, EventArgs e)
        {
            Panel_abrir.BackgroundImage = Compilador.Properties.Resources.boton_abrir1;
        }

        private void Panel_abrir_MouseLeave(object sender, EventArgs e)
        {
            Panel_abrir.BackgroundImage = Compilador.Properties.Resources.boton_abrir0;
        }
      
        private void Panel_nuevo_MouseLeave(object sender, EventArgs e)
        {
            Panel_nuevo.BackgroundImage = Compilador.Properties.Resources.insertarr0;
        }

        private void Panel_nuevo_MouseClick(object sender, MouseEventArgs e)
        {
            TabPage nuevapestaña = new TabPage("Pestaña" + numeropest);
            listapest.Add(nuevapestaña);
            TC_Pestañas.TabPages.Add(nuevapestaña);
            TC_Pestañas.SelectedTab = nuevapestaña;

            StreamReader arc = null;
            creartxt("1", arc, nuevapestaña);
            numeropest++;
        }

        private void Panel_Limpiar_MouseClick(object sender, MouseEventArgs e)
        {
            if (TC_Pestañas.TabPages.Count != 0)
            {
                TabPage borrarpestana = TC_Pestañas.SelectedTab;
                int indice = listapest.IndexOf(borrarpestana);
                listapest.Remove(borrarpestana);
                listatxt.RemoveAt(indice);
                TC_Pestañas.TabPages.Remove(borrarpestana);
            }
        }

        private void Panel_guardar_MouseClick(object sender, MouseEventArgs e)
        {
            if (TC_Pestañas.TabPages.Count != 0)
            {
                if (ruta().IndexOf("*.jlb") < 0)
                {
                    SaveFileDialog Guardar = new SaveFileDialog();
                    Guardar.AddExtension = true;
                    Guardar.DefaultExt = "*.jlb";
                    Guardar.FileName = "*.jlb";

                    if (Guardar.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            File.WriteAllText(Guardar.FileName, contenido());
                            TabPage pestaña = TC_Pestañas.SelectedTab;
                            pestaña.Text = Guardar.FileName;
                            MessageBox.Show("Se ha guardado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("No se puedo guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    try
                    {
                        StreamWriter archivo = new StreamWriter(ruta());
                        archivo.WriteLine(contenido());
                        archivo.Close();
                        MessageBox.Show("Se ha guardado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("No se puedo guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void Panel_guardarcomo_MouseClick(object sender, MouseEventArgs e)
        {
            if (TC_Pestañas.TabPages.Count != 0)
            {
                SaveFileDialog Guardar = new SaveFileDialog();
                Guardar.AddExtension = true;
                Guardar.DefaultExt = "*.jlb";
                Guardar.FileName = "*.jlb";
                if (Guardar.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllText(Guardar.FileName, contenido());
                        TabPage pestaña = TC_Pestañas.SelectedTab;
                        pestaña.Text = Guardar.FileName;
                        MessageBox.Show("Se ha guardado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("No se puedo guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Panel_compilar_MouseClick(object sender, MouseEventArgs e)
        {
            string fuente = contenido();
            Lexico llenar = new Lexico();

            llenar.GRID_TOKENS = Dgv_Listatoken;
            llenar.GRID_ERRORESS = Rtb_errores;
            llenar.analizarLexico(fuente);

            //string fuente = editor.Text;
            //Lexico llenar = new Lexico();

            llenar.GRID_TOKENS = Dgv_Listatoken;
            llenar.GRID_ERRORESS = Rtb_errores;
            llenar.analizarLexico(fuente);
            GRID_TABLE_SYMBOLS.Rows.Clear();
            Sintactico llamar = new Sintactico();
            //GRID_VAR.Rows.Clear();
            Rtb_errores.Rows.Clear();
            llamar.GRID_ERRORES = Rtb_errores;
            llamar.GRID_TABLE_SYMBOLS = GRID_TABLE_SYMBOLS;
            //llamar.GRID_VARS = GRID_VAR;
            llamar.Sintactic();
        }

        private void Panel_abrir_MouseClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog Abrir = new OpenFileDialog();
            if (Abrir.ShowDialog() == DialogResult.OK)
            {
                StreamReader Contenido = new StreamReader(Abrir.FileName);
                TabPage nuevapestaña = new TabPage(Abrir.FileName);
                listapest.Add(nuevapestaña);
                TC_Pestañas.TabPages.Add(nuevapestaña);
                TC_Pestañas.SelectedTab = nuevapestaña;
                creartxt("2", Contenido, nuevapestaña);
                Contenido.Close();
            }
        }

        private void Dgv_Listatoken_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Panel_nuevo_MouseHover(object sender, EventArgs e)
        {
            Panel_nuevo.BackgroundImage = Compilador.Properties.Resources.insertarr1;
        }

        private void Panel_guardar_MouseHover(object sender, EventArgs e)
        {
            Panel_guardar.BackgroundImage = Compilador.Properties.Resources.guardar1;   
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            /*Panel_cerrar.Location = new Point(this.Width - Panel_cerrar.Width, 6);
            Lbl_nombre.Location = new Point(this.Width - Lbl_nombre.Width, 30);
            Lbl_fechahora.Text = DateTime.Now.ToLongDateString().ToString();
            Lbl_hora.Text = DateTime.Now.ToLongTimeString().ToString();
            Time_hora.Start();*/
        }


        
    }
}
