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
using System.Collections;

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

        public struct MetodosDeclarados
        {
            public string nombreDelMetodo;
        }

        public struct ParametrosDeMetodos
        {
            public string tipoDeVariable;
            public string variable;
            public string metodoDeLaVariable;
            //public int numeroDeParametros;
        }
        public struct claseDeclarada
        {
            public string nombreDeClase;
        }

        public static List<VarDeclarada>  list_varDeclarada = new List<VarDeclarada>();
        public static List<MetodosDeclarados> list_metodosDeclarados = new List<MetodosDeclarados>();
        public static List<ParametrosDeMetodos> list_parametrosDeMetodos = new List<ParametrosDeMetodos>();
        public static List<ParametrosDeMetodos> list_parametrosGuardadosTemporalmente = new List<ParametrosDeMetodos>();
        public static List<claseDeclarada> list_clasesDeclaradas = new List<claseDeclarada>();

        public string errores;
        public int bandera = 0;
        public int exito = 1;
        public int x, numeroDeParametros = 0, numeroDeParametrosDelMetodo = 0, punteroGuardado;
        public DataGridView GRID_ERRORES;
        public DataGridView GRID_VARS;
        public DataGridView GRID_TABLE_SYMBOLS;
        public string Dtipo;
        public string Dlexema;
        public string Ddato;
        public bool band_ComprobarVar = true;
        public bool band_ComprobarExistencia = false;
        public bool band_datoPerdido = false, esAsignacion = false, metodoSobrecargado = false, asignacionEnDeclaracion = false, estaDeclarada = false;
        public string nombreMetodo, tipoDeVariableAntesDeAsignar;
        public ArrayList lista_erroresSemanticos = new ArrayList();
       

        public void Sintactic()
        {
            list_varDeclarada.Clear();
            list_metodosDeclarados.Clear();
            list_parametrosDeMetodos.Clear();
            list_clasesDeclaradas.Clear();

            libreria();

            Clases();

            if (exito == 1)
            {
                lista_erroresSemanticos.Add("Sintactico Completado Satisfactoriamente!");
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
                            errores = "Error: Se esperaba un identificador";
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
                        GRID_TABLE_SYMBOLS.Rows.Add("class", milista2[x].lexema);
                        buscarExistenciaDeClase(milista2[x].lexema, false);
                        x++;
                        if (milista2[x].token == -44) // herencia
                        {
                            x++;
                            if (milista2[x].token == -60)
                            {

                                //Verificar si la clase que está heredando existe
                                buscarExistenciaDeClase(milista2[x].lexema, true);

                                x++;
                                Clases2();
                            }
                            else
                            {
                                bandera = 1;
                                errores = "Error: Se esperaba una ID de clase";
                            }
                            
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
                
            }


            if (bandera == 1 && exito == 1)
            {
                exito = 0;
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
                        buscarExistenciaDelMetodo(milista2[x].lexema, false);
                        nombreMetodo = milista2[x].lexema;

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
                        Dtipo = milista2[x].lexema;
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
                GRID_ERRORES.Rows.Add("Error", errores);
            }
        }

        public void Metratrib2()
        {
            if (milista2[x].token == -60)
            {
                if(milista2[x+1].token != -45 && milista2[x+1].token != -37)
                {
                    buscarExistenciaDelMetodo(milista2[x].lexema, false);
                    nombreMetodo = milista2[x].lexema;
                }
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
                    Dlexema = milista2[x - 1].lexema;
                    asignacionEnDeclaracion = true;
                    Buscar_Var(Dlexema);
                    if (!estaDeclarada)
                    {
                        agregarList();
                    }
                    else
                    {
                        Dlexema = null;
                    }
                    //x++;
                    Asignacion();
                    //x++;
                    Varias_asig();
                    Metratrib();

                    asignacionEnDeclaracion = false;
                    Dtipo = null;
                }
            }
            else
            {
                bandera = 1;
                errores = "Error: Se esperaba un ID";
            }
            if (bandera == 1 && exito == 1)
            {
                exito = 0;
                GRID_ERRORES.Rows.Add("Error", errores);
            }
        }

        private void Varias_asig()
        {
            if(milista2[x].token == -43) // ,
            {
                x++;
                if(milista2[x].token == -60) // ID
                {
                    Dlexema = milista2[x].lexema;
                    agregarList();
                    x++;
                    Asignacion();
                    //x++;
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
                GRID_ERRORES.Rows.Add("Error", errores);
            }
        }

        public void Parametros() // LISTOOO
        {
            // TIPOS
            if (milista2[x].token == -132 || milista2[x].token == -133 || milista2[x].token == -134 || milista2[x].token == -135 || milista2[x].token == -136)
            {
                x++;
                if(milista2[x].token == -60)
                {
                    agregarParametrosDelMetodoParaLaLista(nombreMetodo, milista2[x - 1].lexema, milista2[x].lexema);
                    x++;
                    if(milista2[x].token == -43)
                    {
                        x++;
                        Parametros();
                    }
                    else
                    {
                        // no pasa nada
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
                        esAsignacion = false;
                        x++;
                        Sentencias();
                    }
                    else
                    {
                        bandera = 1;
                        errores = "Error: Se esperaba un ;";
                    }

                }
                else if (milista2[x + 1].token == -6) // pregunta si el que sigue es )
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
                GRID_ERRORES.Rows.Add("Error", errores);
            }
        }

        public void Expresiones() //LISTOOOO AL 100%
        {
            //pregunta si es ID NUMERO O DECIMAL
            if (milista2[x].token == -60 || milista2[x].token == -2 || milista2[x].token == -3 || milista2[x].token == -49)
            {
                //Comprobar si este token es del mismo tipo que el token antes de asignacion
                if (esAsignacion)
                {

                    if (tipoDeVariableAntesDeAsignar != obtenerTipoDeVariablePorToken(milista2[x].token))
                    {
                        lista_erroresSemanticos.Add("ERROR: Compatibilidad de tipos, tiene que ser de tipo '" + tipoDeVariableAntesDeAsignar + "'");
                    }
                    
                
                }
                /////////////////


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
                GRID_ERRORES.Rows.Add("Error", errores);
            }
        }

        public void Invocacion() //LISTOOO
        {
            if (milista2[x].token == -60) //ID
            {

                buscarExistenciaDelMetodo(milista2[x].lexema, true);
                nombreMetodo = milista2[x].lexema;
                x++;
                if (milista2[x].token == -6) // (
                {
                    x++;
                    Par2();

                    if (milista2[x].token == -7) // )
                    {
                        x++;
                        if (milista2[x].token == -45)
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
       
            if (bandera == 1 && exito == 1)
            {
                exito = 0;
                GRID_ERRORES.Rows.Add("Error", errores);
            }
        }

        public void Par2() //LISTOO
        {
            
            if(milista2[x].token == -60 || milista2[x].token == -2 || milista2[x].token == -3 || milista2[x].token == -49)
            {
                comprobarTipoDeParametro(nombreMetodo, obtenerTipoDeVariablePorToken(milista2[x].token), numeroDeParametros);
                Valor();
                //x++;
                if(milista2[x].token == -43)
                {
                    numeroDeParametros++;
                    x++;
                    Par2();
                }
                else
                {
                    numeroDeParametros = 0;
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
                    if (milista2[x].token == -43)// ,
                    {
                        x++;
                        IDASIGS();
                    }
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
                GRID_ERRORES.Rows.Add("Error", errores);
            }
        }

        public void Asignacion() // LISTO
        {
            if (milista2[x].token == -37) // =
            {
                band_ComprobarVar = false;
                Buscar_Var(milista2[x - 1].lexema);

                tipoDeVariableAntesDeAsignar = obtenerTipoDeVariableDeID(milista2[x - 1].lexema);
                esAsignacion = true;

                x++;
                Valor();
                esAsignacion = false;
            }
            else
            {
                //bandera = 1;
                //errores = "Error: Se esperaba un =";
            }

            if (bandera == 1 && exito == 1)
            {
                exito = 0;
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
                GRID_ERRORES.Rows.Add("Error", errores);
            }
        }

        public void Buscar_Var(string Plexema)
        {
            if(list_varDeclarada.Count == 0)
            {
                estaDeclarada = false;
            }
            for (int i = 0; i < list_varDeclarada.Count; i++)
            {
                if (band_ComprobarVar == true)
                {
                    if (list_varDeclarada[i].lexema == Plexema)
                    {
                        lista_erroresSemanticos.Add("ERROR: la variable '" + Plexema + "' ya esta DECLARADA!");
                        estaDeclarada = true;
                        break;
                    }else
                    {
                        estaDeclarada = false;

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
                if(!band_ComprobarExistencia && !asignacionEnDeclaracion)
                {
                    lista_erroresSemanticos.Add("ERROR: La variable " + Plexema + " NO esta declarada!");
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
            //GRID_VARS.Rows.Add(Dtipo, Dlexema, Ddato);
            GRID_TABLE_SYMBOLS.Rows.Add("declaracion(" + Dtipo + ")", Dlexema);
            
            //restar
            Ddato = null;
            if (!asignacionEnDeclaracion)
            {
                Dtipo = null;
            }
            Dlexema = null;
        }

        public void agregarNombreMetodoParaLista( string nombreMetodo )
        {
            //Agregar el nombre del metodo a la lista de metodos declarados
            var li = new MetodosDeclarados();
            li.nombreDelMetodo = milista2[x].lexema;
            GRID_TABLE_SYMBOLS.Rows.Add("metodo", milista2[x].lexema);
            list_metodosDeclarados.Add(li);
        }

        public void buscarExistenciaDelMetodo( string nombreMetodo, bool soloBuscarExistencia)
        {
            bool declarado = false;

            for (int i = 0; i < list_metodosDeclarados.Count; i++)
            {

                if (list_metodosDeclarados[i].nombreDelMetodo == nombreMetodo)
                {
                    if (!soloBuscarExistencia)
                    {
                        punteroGuardado = x;
                        x++;
                        x++;

                        parametrosTemporales();

                        x = punteroGuardado;

                        //Esto es para buscar el parametro ya creado
                        for (int j = 0; j < list_parametrosDeMetodos.Count; j++)
                        {

                            if (list_parametrosDeMetodos[j].metodoDeLaVariable == nombreMetodo)
                            {
                                
                                int jj = j;
                                int numeroDeParametrosDelMetodoYaDeclarado = 0;

                                //Encontramos el numero de parametros del metodo que ya está declarado
                                try
                                {
                                    while (list_parametrosDeMetodos[jj].metodoDeLaVariable == nombreMetodo)
                                    {
                                        numeroDeParametrosDelMetodoYaDeclarado++;
                                        jj++;
                                    }
                                }catch(ArgumentOutOfRangeException e)
                                {

                                }

                                //Antes de verificar el tipo de parametros checamos si tienen el mismo numero de parametros
                                //Si no tienen el mismo numero de parametros entonces ya es un metodo sobrecargado
                                if (numeroDeParametrosDelMetodoYaDeclarado == numeroDeParametrosDelMetodo + 1)
                                {

                                    for (int k = 0; k <= numeroDeParametrosDelMetodo; k++)
                                    {
                                        //Verificamos si tienen algun parametro diferente para que sea un metodo sobrecargado
                                        if (list_parametrosDeMetodos[j].tipoDeVariable != list_parametrosGuardadosTemporalmente[k].tipoDeVariable)
                                        {
                                            metodoSobrecargado = true;
                                            break;
                                        }
                                        j++;
                                    }
                                }
                                else
                                {
                                    metodoSobrecargado = true;
                                }

                                break;
                            }
                        
                        }
                        if (!metodoSobrecargado)
                        {
                            lista_erroresSemanticos.Add("ERROR: el Metodo '" + nombreMetodo + "' ya está declarado con los mismos parametros, intente poner parametros diferentes");

                        }
                        metodoSobrecargado = false;
                        numeroDeParametrosDelMetodo = 0;
                        list_parametrosGuardadosTemporalmente.Clear();

                    }
                    declarado = true;
                    break;
                }
               
            }

            if (!declarado)
            {
                if (soloBuscarExistencia)
                {
                    lista_erroresSemanticos.Add("ERROR: el Metodo '" + nombreMetodo + "'no está DECLARADO");
                }
                else
                {
                    agregarNombreMetodoParaLista(nombreMetodo);
                }

            }
        }

        public void agregarParametrosDelMetodoParaLaLista( string nombreMetodo, string tipoDeVariable, string nombreVariable )
        {
            // Agregar el nombre del metodo, tipo de variable y el nombre de variable a nuestra lista
            var li = new ParametrosDeMetodos();
            li.metodoDeLaVariable = nombreMetodo;
            li.tipoDeVariable = tipoDeVariable;
            li.variable = nombreVariable;
            //li.numeroDeParametros = numeroDeParametrosDelMetodo;
            list_parametrosDeMetodos.Add(li);
            GRID_TABLE_SYMBOLS.Rows.Add("parametro("+ tipoDeVariable + ")", nombreVariable);
        }

        public void comprobarTipoDeParametro( string nombreMetodo, string tipoDeParametro, int numeroDeParametro )
        {

            for (int i = 0; i < list_parametrosDeMetodos.Count; i++)
            {

                if (list_parametrosDeMetodos[i].metodoDeLaVariable == nombreMetodo)
                {
                    try
                    {
                        if (list_parametrosDeMetodos[i + numeroDeParametro].tipoDeVariable != tipoDeParametro)
                        {
                            lista_erroresSemanticos.Add("ERROR: El tipo de parametro '" + list_parametrosDeMetodos[i + numeroDeParametro].variable + "'  del metodo '" + nombreMetodo + "' no coincide, tiene que ser de tipo '" + list_parametrosDeMetodos[i + numeroDeParametro].tipoDeVariable + "'");
                        }
                        break;
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        lista_erroresSemanticos.Add("Error: Pusiste un parametro de más en la llamada del metodo");
                        //lista_erroresSemanticos.Add("ERROR: El tipo de parametro '" + list_parametrosDeMetodos[i + numeroDeParametro].variable + "'  del metodo '" + nombreMetodo + "' no coincide, tiene que ser de tipo '" + list_parametrosDeMetodos[i + numeroDeParametro].tipoDeVariable + "'");
                    }
                }

            }
        }

        public string obtenerTipoDeVariablePorToken( int tokenDeVariable )
        {
            string tipo = "";
            if (tokenDeVariable == -2 || tokenDeVariable == -3)
            {
                tipo = "INT";
            }
            else if (tokenDeVariable == -49)
            {
                tipo =  "STRING";
            }
            else if (tokenDeVariable == -60)
            {
                tipo = obtenerTipoDeVariableDeID(milista2[x].lexema);
            }

            return tipo;
        }

        public string obtenerTipoDeVariableDeID( string nombreVariable )
        {
            string tipo = "";

            for (int i = 0; i < list_varDeclarada.Count ; i++)
            {

                if (list_varDeclarada[i].lexema == nombreVariable)
                {
                    tipo = list_varDeclarada[i].tipo;
                    break;
                }

            }

            return tipo;
        }

        public void parametrosTemporales() // LISTOOO
        {
            // TIPOS
            if (milista2[x].token == -132 || milista2[x].token == -133 || milista2[x].token == -134 || milista2[x].token == -135 || milista2[x].token == -136)
            {
                //Agregar el tipo de parametros a la lista temporal
                var li = new ParametrosDeMetodos();
                li.tipoDeVariable = milista2[x].lexema;
                list_parametrosGuardadosTemporalmente.Add(li);

                x++;
                if (milista2[x].token == -60)
                {
                    x++;
                    if (milista2[x].token == -43)
                    {
                        numeroDeParametrosDelMetodo++;
                        x++;
                        parametrosTemporales();
                    }
                    else
                    {
                        // no pasa nada
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
                GRID_ERRORES.Rows.Add("Error", errores);
            }
        }

        public void buscarExistenciaDeClase(string nombreClase, bool esClaseHeredara)
        {
            bool claseDeclarada = false;
            for (int i = 0; i < list_clasesDeclaradas.Count; i++)
            {
               
                if(list_clasesDeclaradas[i].nombreDeClase == nombreClase)
                {
                    claseDeclarada = true;
                    break;
                }

            }

            if (!claseDeclarada)
            {
                //Agregamos la clase a la lista de clases declaradas
                var clase = new claseDeclarada();
                clase.nombreDeClase = nombreClase;
                list_clasesDeclaradas.Add(clase);
            }else
            {
                if (!esClaseHeredara)
                {
                    lista_erroresSemanticos.Add("ERROR: La clase '" + nombreClase + "' ya está declarada!");
                }
            }

            if (esClaseHeredara && !claseDeclarada)
            {
                lista_erroresSemanticos.Add("ERROR: La clase '" + nombreClase + "' que quieres heredar no existe!");
            }

        }
    }
}
