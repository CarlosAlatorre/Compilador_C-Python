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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
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

        private void Panel_nuevo_MouseHover(object sender, EventArgs e)
        {
            Panel_nuevo.BackgroundImage = Compilador.Properties.Resources.insertarr1;
        }

        private void Panel_guardar_MouseHover(object sender, EventArgs e)
        {
            Panel_guardar.BackgroundImage = Compilador.Properties.Resources.guardar1;
        }

        

        





        
    }
}
