using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compilador
{
    class Sintactico: Lexico
    {
        
        public struct VarDeclarada
        {
            public string tipo;
            public string lexema;
            public string dato;
        }
        public static List<VarDeclarada>  list_varDeclarada = new List<VarDeclarada>();

        public string errores;
        public int bandera = 0;
        public int exito = 1;
        public int x;
        public DataGridView GRID_ERRORES;
        public DataGridView GRID_VARS;
        public string Dtipo;
        public string Dlexema;
        public string Ddato;
        public bool band_ComprobarVar = true;
        public bool band_ComprobarExistencia = false;
        public bool band_datoPerdido = false;

        public void Sintactic()
        {
            list_varDeclarada.Clear();

            libreria();

            Clases();

            if (exito == 1)
            {
                MessageBox.Show("Sintactico Completado Satisfactoriamente!");
            }
        }

        public void libreria()
        {
            if (milista2[x].token == -117) //import
            {
                x++;
                if (milista2[x].token == -60) // ID
                {
                    x++;

                    if (milista2[x].token == -5) // PUNTO
                    {
                        x++;
                        if (milista2[x].token == -60) //ID
                        {
                            x++;
                            if (milista2[x].token == -5)// PUNTO
                            {
                                x++;
                                if (milista2[x].token == -60) //ID
                                {
                                    x++;
                                    if (milista2[x].token == -45) // si  recibe ;
                                    {
                                        x++;
                                        libreria();
                                    }
                                    else // si  no recibe ;
                                    {
                                        errores = "Error: Se esperaba un ;";
                                        bandera = 1;
                                    }
                                }
                                else // no recibe el id
                                {
                                    errores = "Error: Se esperaba un identificador";
                                    bandera = 1;
                                }
                            }

                            else if (milista2[x].token == -45) //recibe el ;
                            {
                                x++;
                                libreria();
                            }
                            else //no recibe el ; 
                            {
                                errores = "Error: Se esperaba un ;";
                                bandera = 1;
                            }
                        }
                        else // no recibe el id
                        {
                            errores = "Error: Se esperaba un identificado";
                            bandera = 1;
                        }
                    }// si no recibe el punto entonces:

                    else if (milista2[x].token == -45)// recibe ;
                    {
                        x++;
                        libreria();
                    }

                    else// error de no poner .
                    {
                        errores = " Error: Se esperaba un ;";
                        bandera = 1;
                    }
                }

                else // error de no poner id
                {
                    errores = "Error: Se esperaba un identificador";
                    bandera = 1;
                }
            }
            if (bandera == 1 && exito == 1)
            {
                exito = 0;
                MessageBox.Show(errores);
                GRID_ERRORES.Rows.Add("Error", errores);
            }
        }

        public void Clases()
        {
            if(milista2[x].token == -115 || milista2[x].token == -131) // public private
            {
                x++;
                if(milista2[x].token == -104) // class
                {
                    x++;
                    if(milista2[x].token == -60) // id
                    {
                        x++;
                        if(milista2[x].token == -60) // herencia
                        {
                            x++;
                            Clases2();
                        }
                        else
                        {
                            Clases2();
                        }
                    }
                    else
                    {
                        bandera = 1;
                        errores = "Error: Se esperaba un ID";
                    }
                }
                else
                {
                    bandera = 1;
                    errores = "Error: Se esperaba un CLASS";
                }
            }
            else
            {
                //no pasa nada
            }


            if (bandera == 1 && exito == 1)
            {
                exito = 0;
                MessageBox.Show(" " + errores);
                GRID_ERRORES.Rows.Add("Error", errores);
            }

        }

        private void Clases2()
        {
            if(milista2[x].token == -10) // {
            {
                x++;
                Metratrib();
                //x++;
                
                if(milista2[x].token == -11) // }
                {
                    x++;
                    Clases();
                }
                else
                {
                    bandera = 1;
                    errores = "Error: Se esperaba }";
                }                
            }
            else
            {
                bandera = 1;
                errores = "Error: Se esperaba {";
            }
            if (bandera == 1 && exito == 1)
            {
                exito = 0;
                MessageBox.Show(" " + errores);
                GRID_ERRORES.Rows.Add("Error", errores);
            }
        }

        public void Metratrib()
        {
            if (milista2[x].token == -115 || milista2[x].token == -131) // private public
            {
                x++;
                if (milista2[x].token == -138) // void
                {
                    x++;
                    if (milista2[x].token == -60) // ID
                    {
                        x++;
                        if (milista2[x].token == -6) // (
                        {
                            x++;
                            Parametros();
                            //x++;
                            if (milista2[x].token == -7) // )
                            {
                                x++;
                                if (milista2[x].token == -10) // {
                                {
                                    x++;
                                    Sentencias();
                                    //x++;
                                    if (milista2[x].token == -11) // }
                                    {
                                        x++;
                                        Metratrib();
                                    }
                                    else
                                    {
                                        bandera = 1;
                                        errores = "Error: Se esperaba un }";
                                    }
                                }
                                else
                                {
                                    bandera = 1;
                                    errores = "Error: Se esperaba un {";
                                }
                            }
                            else
                            {
                                bandera = 1;
                                errores = "Error: Se esperaba un )";
                            }
                        }
                        else
                        {
                            bandera = 1;
                            errores = "Error: Se esperaba un (";
                        }
                    }
                    else
                    {
                        bandera = 1;
                        errores = "Error: Se esperaba un ID";
                    }
                }
                else
                {
                    if (milista2[x].token == -132 || milista2[x].token == -133 || milista2[x].token == -134 || milista2[x].token == -135 || milista2[x].token == -136) // TIPO
                    {
                        x++;
                        Metratrib2();
                    }
                    else
                    {if (milista2[x].token == -104) // class
                        {
                            bandera = 1;
                            errores = "Error: Se esperaba un }";
                        }
                        else {
                            bandera = 1;
                            errores = "Error: Se esperaba un VOID o un TIPO";
                        }
                    }
                }
            }
            if (bandera == 1 && exito == 1)
            {
                exito = 0;
                MessageBox.Show(" " + errores);
                GRID_ERRORES.Rows.Add("Error", errores);
            }
        }

        public void Metratrib2()
        {
            if(milista2[x].token == -6) // (
            {
                x++;
                Parametros();
                x++;
                if (milista2[x].token == -7) // )
                {
                    x++;
                    if (milista2[x].token == -10) // {
                    {
                        x++;
                        Sentencias();
                        x++;
                        if (milista2[x].token == -11) // }
                        {
                            Metratrib();
                        }
                        else
                        {
                            bandera = 1;
                            errores = "Error: Se esperaba un }";
                        }
                    }
                    else
                    {
                        bandera = 1;
                        errores = "Error: Se esperaba un {";
                    }
                }
                else
                {
                    bandera = 1;
                    errores = "Error: Se esperaba un )";
                }
            }
            else
            {
                x++;
                Asignacion();
                //x++;
                Varias_asig();
                Metratrib();
            }
            if (bandera == 1 && exito == 1)
            {
                exito = 0;
                MessageBox.Show(" " + errores);
                base.GRID_ERRORESS.Rows.Add("Error", errores);
            }
        }

        private void Varias_asig()
        {
            if(milista2[x].token == -43) // ,
            {
                x++;
                if(milista2[x].token == -60) // ID
                {
                    x++;
                    Asignacion();
                    x++;
                    Varias_asig();
                }
                else
                {
                    bandera = 1;
                    errores = "Error: Se esperaba un ID";
                }
            }
            else
            {
                if(milista2[x].token == -45) // ;
                {
                    x++;
                }
                else
                {
                    bandera = 1;
                    errores = "Error: Se esperaba un ;";
                }
            }
            if (bandera == 1 && exito == 1)
            {
                exito = 0;
                MessageBox.Show(" " + errores);
                GRID_ERRORES.Rows.Add("Error", errores);
            }
        }

        public void Parametros() // LISTOOO
        {
            // TIPOS
            if(milista2[x].token == -132 || milista2[x].token == -133 || milista2[x].token == -134 || milista2[x].token == -135 || milista2[x].token == -136)
            {
                x++;
                if(milista2[x].token == -60)
                {
                    x++;
                    if(milista2[x].token == -43)
                    {
                        x++;
                        Parametros();
                    }
                    else
                    {
                        //x--;
                    }
                }
                else
                {
                    bandera = 1;
                    errores = "Error: Se esperaba un ID";
                }
            }
            else
            {
                // no pasa nada
            }
            if (bandera == 1 && exito == 1)
            {
                exito = 0;
                MessageBox.Show(" " + errores);
                GRID_ERRORES.Rows.Add("Error", errores);
            }
        }

        public void Sentencias() //LISTO
        {

            if (milista2[x].token == -116) // pregunta si el que sigue es IF
            {
                IF();
                Sentencias();
            }
            else if (milista2[x].token == -113) // pregunta si el que sigue es FOR
            {
                FOR();
                Sentencias();
            }
            else if (milista2[x].token == -132 || milista2[x].token == -133 || milista2[x].token == -134 || milista2[x].token == -135 || milista2[x].token == -136) // pregunta si el que sigue es PRIVATE O PUBLIC
            {
                Declaraciones2();
                Sentencias();
            }
            else if (milista2[x].token == -60) // pregunta si el que sigue es ID
            {
                if (milista2[x + 1].token == -37) // // pregunta si el que sigue es =
                {
                    x++;
                    Asignacion();
                    if (milista2[x].token == -45)
                    {
                        x++;
                        Sentencias();
                    }
                    else
                    {
                        bandera = 1;
                        errores = "Error: Se esperaba un ;";
                    }

                }
                else if (milista2[x + 1].token == -5) // pregunta si el que sigue es .
                {
                    Invocacion();
                    Sentencias();
                }
                else
                {if(milista2[x + 1].token == -60 || milista2[x + 1].token == -2 || milista2[x + 1].token == -3)
                    {
                        bandera = 1;
                        errores = "Error: Se esperaba un =";
                    }
                    else
                    {
                        // no hay pedo
                    }

                }
            }
            if(milista2[x].token == -101)
            {
                x++;
                if(milista2[x].token == -6)
                {
                    x++;
                    Valor();
                    if(milista2[x].token == -7)
                    {
                        x++;
                        if (milista2[x].token == -45)
                        {
                            x++;
                            Sentencias();
                        }
                        else
                        {
                            bandera = 1;
                            errores = "Error: Se esperaba un ;";
                        }
                    }
                    else
                    {
                        bandera = 1;
                        errores = "Error: Se esperaba un )";
                    }
                }
                else
                {
                    bandera = 1;
                    errores = "Error: Se esperaba un (";
                }
            }
            else if(milista2[x].token == -102)
            {
                x++;
                if(milista2[x].token == -6)
                {
                    x++;
                    if(milista2[x].token == -60)
                    {
                        x++;
                        if(milista2[x].token == -7)
                        {
                            x++;
                            if(milista2[x].token == -45)
                            {
                                x++;
                                Sentencias();
                            }
                            else
                            {
                                bandera = 1;
                                errores = "Error: Se esperaba un ;";
                            }
                        }
                        else
                        {
                            bandera = 1;
                            errores = "Error: Se esperaba un )";
                        }
                    }
                    else
                    {
                        bandera = 1;
                        errores = "Error: Se esperaba un ID";
                    }
                }
                else
                {
                    bandera = 1;
                    errores = "Error: Se esperaba un (";
                }
            }
            if (bandera == 1 && exito == 1)
            {
                exito = 0;
                MessageBox.Show("" + errores);
                GRID_ERRORES.Rows.Add("Error", errores);
            }
        }

        public void Expresiones() //LISTOOOO AL 100%
        {
            //pregunta si es ID NUMERO O DECIMAL
            if (milista2[x].token == -60 || milista2[x].token == -2 || milista2[x].token == -3 || milista2[x].token == -49)
            {
                x++;
                //pregunta si es un operador + - * / y si no, resta 1 a x porque no entra
                if(milista2[x].token == -13 || milista2[x].token == -15 || milista2[x].token == -19 || milista2[x].token == -21)
                {
                    x++;
                    Expresiones();
                }
                else
                {
                    // bien
                }
            }
            else
            {
                bandera = 1;
                errores = "Error: Se esperaba un ID NUMERO O DECIMAL";
            }
            if (bandera == 1 && exito == 1)
            {
                exito = 0;
                MessageBox.Show("" + errores);
                GRID_ERRORES.Rows.Add("Error", errores);
            }
        }

        public void Invocacion() //LISTOOO
        {
            if(milista2[x].token == -60) //ID
            {
                x++;
                if(milista2[x].token == -5) // .
                {
                    x++;
                    if(milista2[x].token == -60) // ID
                    {
                        x++;
                        if(milista2[x].token == -6) // (
                        {
                            x++;
                            Par2();
                            
                            if(milista2[x].token == -7) // )
                            {
                                x++;
                                if(milista2[x].token == -45)
                                {
                                    x++;
                                }
                            }
                            else
                            {
                                bandera = 1;
                                errores = "Error: Falta )";
                            }
                        }
                        else
                        {
                            bandera = 1;
                            errores = "Error: Falta (";
                        }
                    }
                    else
                    {
                        bandera = 1;
                        errores = "Error: Falta ID";
                    }
                }
                else
                {
                    // no hay pedo
                }
            }
            else
            {
                bandera = 1;
                errores = "Error: Falta ID";
            }
            if (bandera == 1 && exito == 1)
            {
                exito = 0;
                MessageBox.Show(" " + errores);
                GRID_ERRORES.Rows.Add("Error", errores);
            }
        }

        public void Par2() //LISTOO
        {
            
            if(milista2[x].token == -60 || milista2[x].token == -2 || milista2[x].token == -3)
            {
                Valor();
                x++;
                if(milista2[x].token == -43)
                {
                    Par2();
                }
                else
                {
                    // No hay pedo..
                }
            }else
            {
                // No hay pedo
            }
        }

        public void Valor() // LISTO
        {
            // pregunta si es NUMERO O DECIMAL
            if (milista2[x].token == -2 || milista2[x].token == -3 || milista2[x].token == -60 || milista2[x].token == -49)
            {
                if (band_datoPerdido == true)
                {
                    Ddato = null;
                    band_datoPerdido = false;
                }
                else {
                    //Tomando el dato 
                    Ddato = milista2[x].lexema;
                }
                //Metiendo todo a la lista
                if (Dtipo != null && Dlexema != null)
                {
                    agregarList();
                }
                //////////////////////////

                Expresiones();
            }
            else if (milista2[x].token == -60) //ID
            {
                if (milista2[x + 1].token == -5)// .
                {
                    x++;
                    Invocacion();
                }
                else
                {
                    if (milista2[x + 1].token == -6) // (
                    {
                        x++;
                        Metodos();
                    }
                }
            }
            else {
                if (milista2[x].token == -49) // "algo"
                {
                    //bien
                }
                else
                {
                    bandera = 1;
                    errores = "Error: Faltó una expresion o una invocacion";
                }
            }
            if(bandera == 1 && exito == 1)
            {
                exito = 0;
                MessageBox.Show(" " + errores);
                GRID_ERRORES.Rows.Add("Error", errores);
            }
        }
        
        private void Metodos()
        {
            x++;
            x++;
            if(milista2[x].token == -6) // (
            {
                Parametros();
                x++;
                if(milista2[x].token == -7) // )
                {
                    //bien
                }
                else
                {
                    bandera = 1;
                    errores = "Error: Se esperaba )";
                }
            }
            else
            {
                bandera = 1;
                errores = "Error: Se esperaba (";
            }
            if (bandera == 1 && exito == 1)
            {
                exito = 0;
                MessageBox.Show(" " + errores);
                GRID_ERRORES.Rows.Add("Error", errores);
            }
        }

        public void Declaraciones() // LISTOO
        {
            //INT STRING DOUBLE CHAR BOOL
            if (milista2[x].token == -132 || milista2[x].token == -133 || milista2[x].token == -134 || milista2[x].token == -135 || milista2[x].token == -136)
            {
                //Asignar a Dtipo el tipo de variable que es
                Dtipo = milista2[x].lexema;
                //////////////////////////////////////
                x++;
                IDASIGS();
                //x++;
                if (milista2[x].token == -45)
                {
                    if(Ddato == null && Dtipo != null)
                    {
                        if(Dtipo == "INT" || Dtipo == "DOUBLE")
                        {
                            Ddato = "0";
                        }else if(Dtipo == "BOOL")
                        {
                            Ddato = "TRUE";
                        }
                        else
                        {
                            Ddato = " ";
                        }
                        if (Dtipo != null && Dlexema != null && Ddato != null)
                        {
                            agregarList();
                        }
                    }
                }
                else
                {
                    bandera = 1;
                    errores = "Error: Falto un ;";
                }
            }
            else
            {
                bandera = 1;
                errores = "Error: Falto un TIPO";
            }
            
            if(bandera == 1 && exito == 1)
            {
                exito = 0;
                MessageBox.Show(" " + errores);
                GRID_ERRORES.Rows.Add("Error", errores);
            }
        }

        public void Declaraciones2()
        {
            if (milista2[x].token == -132 || milista2[x].token == -133 || milista2[x].token == -134 || milista2[x].token == -135 || milista2[x].token == -136)
            {
                //Asignar a Dtipo el tipo de variable que es
                Dtipo = milista2[x].lexema;
                //////////////////////////////////////
                x++;
                IDASIGS();
                //x++;
                if (milista2[x].token == -45)
                {
                    if (Ddato == null && Dtipo == null && Dlexema == null)
                    {

                    }
                    else if (Ddato == null)
                    {
                        if (Dtipo == "INT" || Dtipo == "DOUBLE")
                        {
                            Ddato = "0";
                        }
                        else if (Dtipo == "BOOL")
                        {
                            Ddato = "TRUE";
                        }
                        else
                        {
                            Ddato = " ";
                        }
                        agregarList();
                    }
                    x++;
                }
                else
                {
                    bandera = 1;
                    errores = "Error: Falto un ;";
                }
            }
            else
            {
                bandera = 1;
                errores = "Error: Falto un TIPO";
            }

            if (bandera == 1 && exito == 1)
            {
                exito = 0;
                MessageBox.Show(" " + errores);
                GRID_ERRORES.Rows.Add("Error", errores);
            }
        }

        public void IDASIGS() // LISTOO
        {
            if(milista2[x].token == -60) /// id
            {
                //Tomando el lexema de la declaracion
                Dlexema = milista2[x].lexema;
                Buscar_Var(Dlexema);
                /////////////////////////////////////
                x++;
                if(milista2[x].token == -37) // =
                {
                    x++;
                    Valor();
                    //x++;
                    if(milista2[x].token == -43)
                    {
                        x++;
                        IDASIGS();
                    }
                    else
                    {
                        //no hay pedo
                    }
                }
                else
                {
                    //no hay pedo
                }
            }
            else
            {
                bandera = 1;
                errores = "Error: Falto ID";
            }
            if(bandera == 1 && exito == 1)
            {
                exito = 0;
                MessageBox.Show(" " + errores);
                GRID_ERRORES.Rows.Add("Error", errores);
            }
        }

        public void Asignacion() // LISTO
        {
            if (milista2[x].token == -37) // =
            {
                band_ComprobarVar = false;
                Buscar_Var(milista2[x - 1].lexema);

                x++;
                Valor();
            }
            else
            {
                bandera = 1;
                errores = "Error: Se esperaba un =";
            }

            if (bandera == 1 && exito == 1)
            {
                exito = 0;
                MessageBox.Show(errores);
                GRID_ERRORES.Rows.Add("Error", errores);
            }
        }

        public void IF() //BIEN
        {
            if (milista2[x].token == -116) // IF
            {
                x++;
                if (milista2[x].token == -6) // (
                {
                    x++;
                    COND();
                   // x++;
                    if (milista2[x].token == -7) // )
                    {
                        x++;
                        if (milista2[x].token == -10) // {
                        {
                            x++;
                            Sentencias();
                           // x++;
                            if (milista2[x].token == -11) // }
                            {
                                x++;
                                ELSE();
                            }
                            else
                            {
                                bandera = 1;
                                errores = "Error: Se esperaba }";
                            }
                        }
                        else
                        {
                            bandera = 1;
                            errores = "Error: Se esperaba {";
                        }
                    }
                    else
                    {
                        bandera = 1;
                        errores = "Error: Se esperaba )";
                    }
                }
                else
                {
                    bandera = 1;
                    errores = "Error: Se esperaba (";
                }
            }
            if (bandera == 1 && exito == 1)
            {
                exito = 0;
                MessageBox.Show(" " + errores);
                GRID_ERRORES.Rows.Add("Error", errores);
            }
        }

        public void FOR()
        {
            if (milista2[x].token == -113) // FOR
            {
                x++;
                if (milista2[x].token == -6) // (
                {
                    x++;
                    DECASIG();
                    //x++;
                    if (milista2[x].token == -45) // ;
                    {
                        x++;
                        COND();
                        //x++;
                        if (milista2[x].token == -45) // ;
                        {
                            x++;
                            DECASIG();
                            //x++;
                            if (milista2[x].token == -7) // )
                            {
                                x++;
                                if (milista2[x].token == -10) // {
                                {
                                    x++;
                                    Sentencias();
                                    //x++;
                                    if (milista2[x].token == -11) // }
                                    {
                                        x++;
                                    }
                                    else
                                    {
                                        bandera = 1;
                                        errores = "Error: Se esperaba }";
                                    }
                                }
                                else
                                {
                                    bandera = 1;
                                    errores = "Error: Se esperaba {";
                                }
                            }
                            else
                            {
                                bandera = 1;
                                errores = "Error: Se esperaba )";
                            }
                        }
                        else
                        {
                            bandera = 1;
                            errores = "Error: Se esperaba ;";
                        }
                    }
                    else
                    {
                        bandera = 1;
                        errores = "Error: Se esperaba ;";
                    }
                }
                else
                {
                    bandera = 1;
                    errores = "Error: Se esperaba (";
                }
            }
            if(bandera == 1 && exito == 1)
            {
                exito = 0;
                MessageBox.Show("" + errores);
                GRID_ERRORES.Rows.Add("Error", errores);
            }
        }

        public void ELSE()
        {
            if(milista2[x].token == -109) // ELSE
            {
                x++;
                if(milista2[x].token == -10) // {
                {
                    x++;
                    Sentencias();
                    //x++;
                    if(milista2[x].token == -11) // }
                    {
                        x++;
                    }
                    else
                    {
                        bandera = 1;
                        errores = "Error: Se esperaba un cierre }";
                    }
                }
                else
                {
                    IF();
                }
            }
            if(bandera == 1 && exito == 1)
            {
                exito = 0;
                MessageBox.Show(" " + errores);
                GRID_ERRORES.Rows.Add("Error", errores);
            }
        } 

        public void COND() // LISTO
        {
            Expresiones();
            //x++;
            //pregunta si hay una operacion logica == <= >= != 
            if(milista2[x].token == -26 || milista2[x].token == -34 || milista2[x].token == -32 || milista2[x].token == -39 || milista2[x].token == -35 || milista2[x].token == -38 || milista2[x].token == -42)
            {
                x++;
                Expresiones();
                //x++;
                // pregunta si es operador booleano AND OR y si no, resta 1 a x
                if (milista2[x].token == -100 || milista2[x].token == -122) 
                {
                    COND();
                }
                else
                {
                    //bien
                }
            }
            else
            {
                bandera = 1;
                errores = "Error: Falta una operacion logica";
            }
            if (bandera == 1 && exito == 1)
            {
                exito = 0;
                MessageBox.Show(" " + errores);
                GRID_ERRORES.Rows.Add("Error", errores);
            }
        }

        public void DECASIG() // LISTO
        {
            
            if(milista2[x].token == -132 || milista2[x].token == -133 || milista2[x].token == -134 || milista2[x].token == -135 || milista2[x].token == -136) // p
            {
                Declaraciones();
            }
            else
            {
                if (milista2[x].token == -60)
                {
                    Asignacion2();
                }
                else
                {
                    bandera = 1;
                    errores = "Error: Se esperaba un ID";
                }
            }
            if (bandera == 1 && exito == 1)
            {
                exito = 0;
                MessageBox.Show(" " + errores);
                GRID_ERRORES.Rows.Add("Error", errores);
            }
        }

        public void Asignacion2()
        {
            if (milista2[x].token == -60) // ID
            {
                x++;
                if (milista2[x].token == -37) // =
                {
                    x++;
                    Valor();
                }
                else
                {
                }
            }
            else
            {
                bandera = 1;
                errores = "Error: Falto un ID";
            }
            if (bandera == 1 && exito == 1)
            {
                exito = 0;
                MessageBox.Show(" " + errores);
                GRID_ERRORES.Rows.Add("Error", errores);
            }
        }

        public void Buscar_Var(string Plexema)
        {
            for (int i = 0; i < list_varDeclarada.Count; i++)
            {
                if (band_ComprobarVar == true)
                {
                    if (list_varDeclarada[i].lexema == Plexema)
                    {
                        MessageBox.Show("ERROR: la variable '" + Plexema + "' ya esta DECLARADA!");
                    }
                }
                else
                {
                    if(list_varDeclarada[i].lexema == Plexema)
                    {
                        band_ComprobarExistencia = true;
                    }
                }
            }

            if(band_ComprobarVar == false)
            {
                if(band_ComprobarExistencia == false)
                {
                    MessageBox.Show("ERROR: La variable " + Plexema + " NO esta declarada!");
                    band_datoPerdido = true;
                }
            }

            band_ComprobarVar = true;
            band_ComprobarExistencia = false;
        }

        public void agregarList()
        {
            var li = new VarDeclarada();
            li.tipo = Dtipo;
            li.lexema = Dlexema;
            li.dato = Ddato;

            list_varDeclarada.Add(li);
            GRID_VARS.Rows.Add(Dtipo, Dlexema, Ddato);
            
            //restar
            Ddato = null;
            Dtipo = null;
            Dlexema = null;
        }
    }
}
