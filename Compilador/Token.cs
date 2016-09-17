using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador
{
    class Token
    {
        public int token;
        public string lexema, tipo;
        public int linea;
        
        public Token(string xtipo, int xtoken, string xlexema, int xlinea)
        {
            tipo = xtipo;
            token = xtoken;
            lexema = xlexema;
            linea = xlinea;


        }
        public Token()
        {
            /*LLENAR_LISTVIEW();*/
        }

        /*public void LLENAR_LISTVIEW()
        {
            Texto enviar = new Texto();

            enviar.regresar_lexema(lexema);
            enviar.regresar_linea(linea);
            enviar.regresar_token(token);
        }*/
    }
}
