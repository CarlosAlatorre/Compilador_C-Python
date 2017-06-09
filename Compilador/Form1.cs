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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        
        private void examinarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Creating MDI child form and initialize its fields
            var childForm = new Texto();
            childForm.Text = "Nueva Pestaña ";
            childForm.MdiParent = this;
            
            //child Form will now hold a reference value to the tab control
            childForm.TabCtrl = tabControl1;

            //Add a Tabpage and enables it
            var tp = new TabPage();
            tp.Parent = tabControl1;
            tp.Text = childForm.Text;
            tp.Show();

            //child Form will now hold a reference value to a tabpage
            childForm.TabPag = tp;

            //Activate the MDI child form
            childForm.Show();

            //MessageBox.Show(childForm.Location.ToString());
            //Activate the newly created Tabpage
            tabControl1.SelectedTab = tp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Creating MDI child form and initialize its fields
            var childForm = new Texto();
            childForm.Text = "Nueva Pestaña";
            childForm.MdiParent = this;


            //Add a Tabpage and enables it
            var tp = new TabPage();
            tp.Parent = tabControl1;
            tp.Text = childForm.Text;
            tp.Show();

            

            //Activate the MDI child form
            childForm.Show();
            

            //MessageBox.Show(childForm.Location.ToString());
            //Activate the newly created Tabpage
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void cerrarPestañaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lexicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void GRID_ER_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
