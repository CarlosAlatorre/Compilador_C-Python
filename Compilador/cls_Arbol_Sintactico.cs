using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Compilador
{
    class cls_Arbol_Sintactico
    {
        ArrayList listaoperadores = new ArrayList();
        ArrayList listacompleta = new ArrayList();
        string num = "";
        int indice = 0;
        string aux = "";
        string result = "";
        bool check = false;

        public string obtener(String cadena)
        {
            result = "";
            listacompleta.Clear();
            listaoperadores.Clear();
            for (int i = 0; i < cadena.Length; i++)
            {
                if (cadena[i].ToString() == "+" || cadena[i].ToString() == "-" || cadena[i].ToString() == "/" || cadena[i].ToString() == "*")
                {
                    check = true;
                    break;
                }
            }
            if (check == true && cadena[0] != '"')
            {
                for (int i = 0; i < cadena.Length; i++)
                {
                    if (cadena[i] == '(')
                    {
                        listaoperadores.Add("(");
                    }
                    if (char.IsNumber(cadena[i]) || char.IsLetter(cadena[i]))
                    {
                        while (char.IsNumber(cadena[i]) || cadena[i] == '.' || char.IsLetter(cadena[i]))
                        {
                            num += cadena[i];
                            if (i == cadena.Length - 1)
                            {
                                break;
                            }
                            else
                            {
                                i++;
                            }
                        }
                        listacompleta.Add(num);
                        num = "";
                    }

                    if (cadena[i] == ')')
                    {
                        indice = listaoperadores.Count - 1;
                        while (listaoperadores[indice].ToString() != "(")
                        {
                            aux = Convert.ToString(listaoperadores[indice]);
                            listacompleta.Add(aux);
                            listaoperadores.RemoveAt(indice);
                            indice--;
                        }
                        listaoperadores.RemoveAt(indice);
                    }
                    if (cadena[i] == '*' || cadena[i] == '/' || cadena[i] == '+' || cadena[i] == '-' || cadena[i] == '^')
                    {

                        if (cadena[i] == '^')
                        {
                            listaoperadores.Add("^");
                        }

                        if (cadena[i] == '*')
                        {
                            if (listaoperadores.Count == 0)
                            {
                                listaoperadores.Add("*");
                            }
                            else
                            {
                                if (Convert.ToChar(listaoperadores[listaoperadores.Count - 1]) == '(')
                                {
                                    listaoperadores.Add("*");
                                }
                                else
                                {

                                    char a = Convert.ToChar(listaoperadores[listaoperadores.Count - 1]);
                                    int b = listaoperadores.Count - 1;
                                    switch (a)
                                    {
                                        case '*':
                                            listacompleta.Add("*");
                                            break;
                                        case '/':
                                            listacompleta.Add("/");
                                            listaoperadores.RemoveAt(listaoperadores.Count - 1);
                                            listaoperadores.Add("*");
                                            break;
                                        case '+':
                                            listaoperadores.Add("*");
                                            break;
                                        case '-':
                                            listaoperadores.Add("*");
                                            break;
                                        case '^':
                                            while (listaoperadores.Count != 0)
                                            {
                                                string c = "";
                                                c = Convert.ToString(listaoperadores[b]);
                                                listacompleta.Add(c);
                                                listaoperadores.RemoveAt(b);
                                                b--;
                                            }
                                            listaoperadores.Add("*");
                                            break;
                                    }
                                }

                            }
                        }

                        if (cadena[i] == '/')
                        {
                            if (listaoperadores.Count == 0)
                            {
                                listaoperadores.Add("/");
                            }
                            else
                            {
                                if (Convert.ToChar(listaoperadores[listaoperadores.Count - 1]) == '(')
                                {
                                    listaoperadores.Add("/");
                                }
                                else
                                {
                                    char a = Convert.ToChar(listaoperadores[listaoperadores.Count - 1]);
                                    int b = listaoperadores.Count - 1;
                                    switch (a)
                                    {
                                        case '*':
                                            listacompleta.Add("*");
                                            listaoperadores.RemoveAt(listaoperadores.Count - 1);
                                            listaoperadores.Add("/");

                                            break;
                                        case '/':
                                            listacompleta.Add("/");
                                            break;
                                        case '+':
                                            listaoperadores.Add("/");
                                            break;
                                        case '-':
                                            listaoperadores.Add("/");
                                            break;
                                        case '^':
                                            while (listaoperadores.Count != 0)
                                            {
                                                string c = "";
                                                c = Convert.ToString(listaoperadores[b]);
                                                listacompleta.Add(c);
                                                listaoperadores.RemoveAt(b);
                                                b--;
                                            }
                                            listaoperadores.Add("/");
                                            break;
                                    }
                                }

                            }
                        }

                        if (cadena[i] == '+')
                        {
                            if (listaoperadores.Count == 0)
                            {
                                listaoperadores.Add("+");
                            }
                            else
                            {
                                if (Convert.ToChar(listaoperadores[listaoperadores.Count - 1]) == '(')
                                {
                                    listaoperadores.Add("+");
                                }
                                else
                                {
                                    char a = Convert.ToChar(listaoperadores[listaoperadores.Count - 1]);
                                    int b = listaoperadores.Count - 1;
                                    switch (a)
                                    {
                                        case '*':
                                            while (listaoperadores.Count != 0)
                                            {
                                                string c = "";
                                                c = Convert.ToString(listaoperadores[b]);
                                                listacompleta.Add(c);
                                                listaoperadores.RemoveAt(b);
                                                b--;
                                            }
                                            listaoperadores.Add("+");
                                            break;
                                        case '/':
                                            while (listaoperadores.Count != 0)
                                            {
                                                string c = "";
                                                c = Convert.ToString(listaoperadores[b]);
                                                listacompleta.Add(c);
                                                listaoperadores.RemoveAt(b);
                                                b--;
                                            }
                                            listaoperadores.Add("+");
                                            break;
                                        case '+':
                                            listacompleta.Add("+");
                                            break;
                                        case '-':
                                            listacompleta.Add("-");
                                            listaoperadores.RemoveAt(listaoperadores.Count - 1);
                                            listaoperadores.Add("+");
                                            break;
                                        case '^':
                                            while (listaoperadores.Count != 0)
                                            {
                                                string c = "";
                                                c = Convert.ToString(listaoperadores[b]);
                                                listacompleta.Add(c);
                                                listaoperadores.RemoveAt(b);
                                                b--;
                                            }
                                            listaoperadores.Add("+");
                                            break;
                                    }
                                }

                            }
                        }
                        if (cadena[i] == '-')
                        {
                            if (listaoperadores.Count == 0)
                            {
                                listaoperadores.Add("-");
                            }
                            else
                            {
                                if (Convert.ToChar(listaoperadores[listaoperadores.Count - 1]) == '(')
                                {
                                    listaoperadores.Add("-");
                                }
                                else
                                {
                                    char a = Convert.ToChar(listaoperadores[listaoperadores.Count - 1]);
                                    int b = listaoperadores.Count - 1;
                                    switch (a)
                                    {
                                        case '*':
                                            while (listaoperadores.Count != 0)
                                            {
                                                string c = "";
                                                c = Convert.ToString(listaoperadores[b]);
                                                listacompleta.Add(c);
                                                listaoperadores.RemoveAt(b);
                                                b--;
                                            }
                                            listaoperadores.Add("-");
                                            break;
                                        case '/':
                                            while (listaoperadores.Count != 0)
                                            {
                                                string c = "";
                                                c = Convert.ToString(listaoperadores[b]);
                                                listacompleta.Add(c);
                                                listaoperadores.RemoveAt(b);
                                                b--;
                                            }
                                            listaoperadores.Add("-");
                                            break;
                                        case '+':
                                            listacompleta.Add("+");
                                            listaoperadores.RemoveAt(listaoperadores.Count - 1);
                                            listaoperadores.Add("-");
                                            break;
                                        case '-':
                                            listacompleta.Add("-");
                                            break;
                                        case '^':
                                            while (listaoperadores.Count != 0)
                                            {
                                                string c = "";
                                                c = Convert.ToString(listaoperadores[b]);
                                                listacompleta.Add(c);
                                                listaoperadores.RemoveAt(b);
                                                b--;
                                            }
                                            listaoperadores.Add("-");
                                            break;
                                    }

                                }

                            }
                        }

                    }
                }
                string aux1 = "", aux2 = "";
                int con = 1;
                ArrayList pilaaux = new ArrayList();
                for (int i = 0; i < listacompleta.Count; i++)
                {
                    if (listacompleta[i].ToString() == "" || listacompleta[i].ToString() == " ")
                    {
                        listacompleta.RemoveAt(i);
                    }
                }
                if (listaoperadores.Count == 1)
                {
                    listacompleta.Add(listaoperadores[0].ToString());
                }
                for (int i = 0; i < listacompleta.Count; i++)
                {
                    if (listacompleta[i].ToString() == "+" || listacompleta[i].ToString() == "-" || listacompleta[i].ToString() == "/" || listacompleta[i].ToString() == "*")
                    {
                        switch (listacompleta[i].ToString())
                        {
                            case "+":
                                result += "SUMAR " + pilaaux[pilaaux.Count - 2].ToString() + ", " + pilaaux[pilaaux.Count - 1].ToString() + " ," + "$" + Convert.ToString(con) + "\n";
                                pilaaux.RemoveAt(pilaaux.Count - 1);
                                pilaaux.RemoveAt(pilaaux.Count - 1);
                                pilaaux.Add("$" + Convert.ToString(con));
                                if (con == 1)
                                {
                                    con++;
                                }
                                else
                                {
                                    if (con == 2)
                                    {
                                        con--;
                                    }
                                }
                                break;
                            case "-":
                                result += "RESTA " + pilaaux[pilaaux.Count - 2].ToString() + ", " + pilaaux[pilaaux.Count - 1].ToString() + " ," + "$" + Convert.ToString(con) + "\n";
                                pilaaux.RemoveAt(pilaaux.Count - 1);
                                pilaaux.RemoveAt(pilaaux.Count - 1);
                                pilaaux.Add("$" + Convert.ToString(con));
                                if (con == 1)
                                {
                                    con++;
                                }
                                else
                                {
                                    if (con == 2)
                                    {
                                        con--;
                                    }
                                }

                                break;
                            case "*":
                                result += "MULTI " + pilaaux[pilaaux.Count - 2].ToString() + ", " + pilaaux[pilaaux.Count - 1].ToString() + " ," + "$" + Convert.ToString(con) + "\n";
                                pilaaux.RemoveAt(pilaaux.Count - 1);
                                pilaaux.RemoveAt(pilaaux.Count - 1);
                                pilaaux.Add("$" + Convert.ToString(con));
                                if (con == 1)
                                {
                                    con++;
                                }
                                else
                                {
                                    if (con == 2)
                                    {
                                        con--;
                                    }
                                }

                                break;
                            case "/":
                                result += "DIVIDE " + pilaaux[pilaaux.Count - 2].ToString() + ", " + pilaaux[pilaaux.Count - 1].ToString() + " ," + "$" + Convert.ToString(con) + "\n";
                                pilaaux.RemoveAt(pilaaux.Count - 1);
                                pilaaux.RemoveAt(pilaaux.Count - 1);
                                pilaaux.Add("$" + Convert.ToString(con));
                                if (con == 1)
                                {
                                    con++;
                                }
                                else
                                {
                                    if (con == 2)
                                    {
                                        con--;
                                    }
                                }

                                break;
                        }
                    }
                    else
                    {
                        pilaaux.Add(listacompleta[i].ToString());
                    }

                }
                if (con == 1)
                {
                    con++;
                }
                else
                {
                    con--;
                }
                result += "MOV AX, " + "$" + Convert.ToString(con) + "\n" + "\n";
            }
            check = false;
            return result;
        }
    }
}
