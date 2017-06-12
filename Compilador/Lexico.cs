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
    class Lexico
    {

        public static List<Token> milista;
        public static List<Token> milista2 = new List<Token>();
        
        public int toke;

        /* public List<Token> LISTA()
         {
             List<Token> milista_nueva = new List<Token>();
             milista_nueva = milista;

             return milista_nueva;
         }*/
        public int[,] MT;
        public DataGridView GRID_TOKENS, GRID_ERRORESS;
        public Lexico()
        {

            milista = new List<Token>();
            MT = new int[,]  {
                       //A-Z	0-9	_	.	(	)	[	]	{	}	+	-	*	/	%	!	&	|	~	<	=	>	,	:	;	#	\	.'	"	^	`	eb	nl	eof
                        { 1       ,   3   ,   2   ,   4   ,   -6  ,   -7  ,   -8  ,   -9  ,   -10 ,   -11 ,   5   ,   6   ,   7   ,   9   ,   11  ,   12  ,   13  ,   14  ,   -31 ,   15  ,   17  ,   18  ,   -43 ,   -44 ,   -45 ,   20  ,   -47 ,   21  ,   23  ,   -50 ,   -51 ,   0   ,   0   ,   0  , 0, 0},
                        { 1       ,   1   ,   1   ,   -1  ,   -1  ,   -1  ,   -1  ,   -1  ,   -1  ,   -1  ,   -1  ,   -1  ,   -1  ,   -1  ,   -1  ,   -1  ,   -1  ,   -1  ,   -1  ,   -1  ,   -1  ,   -1  ,   -1  ,   -1  ,   -1  ,   -1  ,   -1  ,   -1  ,   -1  ,   -1  ,   -1  ,   -1  ,   0   ,   -1,   -1,   -1},
                        { 1       ,   1   ,   -500    ,   -500    ,   -500    ,   -500    ,   -500    ,   -500    ,   -500    ,   -500    ,   -500    ,   -500    ,   -500    ,   -500    ,   -500    ,   -500    ,   -500    ,   -500    ,   -500    ,   -500    ,   -500    ,   -500    ,   -500    ,   -500    ,   -500    ,   -500    ,   -500    ,   -500    ,   -500    ,   -500    ,   -500    ,   -1  ,   0   ,   -500,   -500,   -500},
                        { -504    ,   3   ,   -2  ,   -2  ,   -2  ,   -2  ,   -2  ,   -2  ,   -2  ,   -2  ,   -2  ,   -2  ,   -2  ,   -2  ,   -2  ,   -2  ,   -2  ,   -2  ,   -2  ,   -2  ,   -2  ,   -2  ,   -2  ,   -2  ,   -2  ,   -2  ,   -2  ,   -2  ,   -2  ,   -2  ,   -2  ,   -2  ,   0   ,   -2,   -2,   -2},
                        { -5      ,   25  ,   -5  ,   -5  ,   -5  ,   -5  ,   -5  ,   -5  ,   -5  ,   -5  ,   -5  ,   -5  ,   -5  ,   -5  ,   -5  ,   -5  ,   -5  ,   -5  ,   -5  ,   -5  ,   -5  ,   -5  ,   -5  ,   -5  ,   -5  ,   -5  ,   -5  ,   -5  ,   -5  ,   -5  ,   -5  ,   -5  ,   0   ,   -5,   -5,   -5},
                        { -13     ,   -13 ,   -13 ,   -13 ,   -13 ,   -13 ,   -13 ,   -13 ,   -13 ,   -13 ,   -13 ,   -13 ,   -13 ,   -13 ,   -13 ,   -13 ,   -13 ,   -13 ,   -13 ,   -13 ,   -12 ,   -13 ,   -13 ,   -13 ,   -13 ,   -13 ,   -13 ,   -13 ,   -13 ,   -13 ,   -13 ,   -13 ,   0   ,   -13,   -13,   -13},
                        { -15     ,   -15 ,   -15 ,   -15 ,   -15 ,   -15 ,   -15 ,   -15 ,   -15 ,   -15 ,   -15 ,   -15 ,   -15 ,   -15 ,   -15 ,   -15 ,   -15 ,   -15 ,   -15 ,   -15 ,   -14 ,   -15 ,   -15 ,   -15 ,   -15 ,   -15 ,   -15 ,   -15 ,   -15 ,   -15 ,   -15 ,   -15 ,   0   ,   -15,   -15,   -15},
                        { -19     ,   -19 ,   -19 ,   -19 ,   -19 ,   -19 ,   -19 ,   -19 ,   -19 ,   -19 ,   -19 ,   -19 ,   8   ,   -19 ,   -19 ,   -19 ,   -19 ,   -19 ,   -19 ,   -19 ,   -18 ,   -19 ,   -19 ,   -19 ,   -19 ,   -19 ,   -19 ,   -19 ,   -19 ,   -19 ,   -19 ,   -19 ,   0   ,   -19,   -19,   -19},
                        { -16     ,   -16 ,   -16 ,   -16 ,   -16 ,   -16 ,   -16 ,   -16 ,   -16 ,   -16 ,   -16 ,   -16 ,   -16 ,   -16 ,   -16 ,   -16 ,   -16 ,   -16 ,   -16 ,   -16 ,   -17 ,   -16 ,   -16 ,   -16 ,   -16 ,   -16 ,   -16 ,   -16 ,   -16 ,   -16 ,   -16 ,   -16 ,   0   ,   -16,   -16,   -16},
                        { -21     ,   -21 ,   -21 ,   -21 ,   -21 ,   -21 ,   -21 ,   -21 ,   -21 ,   -21 ,   -21 ,   -21 ,   26  ,   10  ,   -21 ,   -21 ,   -21 ,   -21 ,   -21 ,   -21 ,   -22 ,   -21 ,   -21 ,   -21 ,   -21 ,   -21 ,   -21 ,   -21 ,   -21 ,   -21 ,   -21 ,   -21 ,   0   ,   -21,   -21,   -21},
                        { -20     ,   -20 ,   -20 ,   -20 ,   -20 ,   -20 ,   -20 ,   -20 ,   -20 ,   -20 ,   -20 ,   -20 ,   -20 ,   -20 ,   -20 ,   -20 ,   -20 ,   -20 ,   -20 ,   -20 ,   -23 ,   -20 ,   -20 ,   -20 ,   -20 ,   -20 ,   -20 ,   -20 ,   -20 ,   -20 ,   -20 ,   -20 ,   0   ,   -20,   -20,   -20},
                        { -24     ,   -24 ,   -24 ,   -24 ,   -24 ,   -24 ,   -24 ,   -24 ,   -24 ,   -24 ,   -24 ,   -24 ,   -24 ,   -24 ,   -24 ,   -24 ,   -24 ,   -24 ,   -24 ,   -24 ,   -25 ,   -24 ,   -24 ,   -24 ,   -24 ,   -24 ,   -24 ,   -24 ,   -24 ,   -24 ,   -24 ,   -24 ,   0   ,   -24,   -24,   -24},
                        { -501    ,   -501    ,   -501    ,   -501    ,   -501    ,   -501    ,   -501    ,   -501    ,   -501    ,   -501    ,   -501    ,   -501    ,   -501    ,   -501    ,   -501    ,   -501    ,   -501    ,   -501    ,   -501    ,   -501    ,   -26 ,   -501    ,   -501    ,   -501    ,   -501    ,   -501    ,   -501    ,   -501    ,   -501    ,   -501    ,   -501    ,   -501    ,   0   ,   -501,   -501,   -501},
                        { -27     ,   -27 ,   -27 ,   -27 ,   -27 ,   -27 ,   -27 ,   -27 ,   -27 ,   -27 ,   -27 ,   -27 ,   -27 ,   -27 ,   -27 ,   -27 ,   -27 ,   -27 ,   -27 ,   -27 ,   -28 ,   -27 ,   -27 ,   -27 ,   -27 ,   -27 ,   -27 ,   -27 ,   -27 ,   -27 ,   -27 ,   -27 ,   0   ,   -27,   -27,   -27},
                        { -29     ,   -29 ,   -29 ,   -29 ,   -29 ,   -29 ,   -29 ,   -29 ,   -29 ,   -29 ,   -29 ,   -29 ,   -29 ,   -29 ,   -29 ,   -29 ,   -29 ,   -29 ,   -29 ,   -29 ,   -30 ,   -29 ,   -29 ,   -29 ,   -29 ,   -29 ,   -29 ,   -29 ,   -29 ,   -29 ,   -29 ,   -29 ,   0   ,   -29,   -29,   -29},
                        { -32     ,   -32 ,   -32 ,   -32 ,   -32 ,   -32 ,   -32 ,   -32 ,   -32 ,   -32 ,   -32 ,   -32 ,   -32 ,   -32 ,   -32 ,   -32 ,   -32 ,   -32 ,   -32 ,   16  ,   -34 ,   -35 ,   -32 ,   -32 ,   -32 ,   -32 ,   -32 ,   -32 ,   -32 ,   -32 ,   -32 ,   -32 ,   0   ,   -32,   -32,   -32},
                        { -33     ,   -33 ,   -33 ,   -33 ,   -33 ,   -33 ,   -33 ,   -33 ,   -33 ,   -33 ,   -33 ,   -33 ,   -33 ,   -33 ,   -33 ,   -33 ,   -33 ,   -33 ,   -33 ,   -33 ,   -33 ,   -36 ,   -33 ,   -33 ,   -33 ,   -33 ,   -33 ,   -33 ,   -33 ,   -33 ,   -33 ,   -33 ,   0   ,   -33,   -33,   -33},
                        { -37     ,   -37 ,   -37 ,   -37 ,   -37 ,   -37 ,   -37 ,   -37 ,   -37 ,   -37 ,   -37 ,   -37 ,   -37 ,   -37 ,   -37 ,   -37 ,   -37 ,   -37 ,   -37 ,   -37 ,   -38 ,   -37 ,   -37 ,   -37 ,   -37 ,   -37 ,   -37 ,   -37 ,   -37 ,   -37 ,   -37 ,   -37 ,   0   ,   -37,   -37,   -37},
                        { -39     ,   -39 ,   -39 ,   -39 ,   -39 ,   -39 ,   -39 ,   -39 ,   -39 ,   -39 ,   -39 ,   -39 ,   -39 ,   -39 ,   -39 ,   -39 ,   -39 ,   -39 ,   -39 ,   -39 ,   -42 ,   19  ,   -39 ,   -39 ,   -39 ,   -39 ,   -39 ,   -39 ,   -39 ,   -39 ,   -39 ,   -39 ,   0   ,   -39,   -39,   -39},
                        { -40     ,   -40 ,   -40 ,   -40 ,   -40 ,   -40 ,   -40 ,   -40 ,   -40 ,   -40 ,   -40 ,   -40 ,   -40 ,   -40 ,   -40 ,   -40 ,   -40 ,   -40 ,   -40 ,   -40 ,   -41 ,   -40 ,   -40 ,   -40 ,   -40 ,   -40 ,   -40 ,   -40 ,   -40 ,   -40 ,   -40 ,   -40 ,   0   ,   -40,   -40,   -40},
                        { -46     ,   -46 ,   -46 ,   -46 ,   -46 ,   -46 ,   -46 ,   -46 ,   -46 ,   -46 ,   -46 ,   -46 ,   -46 ,   -46 ,   -46 ,   -46 ,   -46 ,   -46 ,   -46 ,   -46 ,   -46 ,   -46 ,   -46 ,   -46 ,   -46 ,   -46 ,   -46 ,   -46 ,   -46 ,   -46 ,   -46 ,   -46 ,   0   ,   -46,   -46,   -46},
                        { 22      ,   22  ,   22  ,   22  ,   22  ,   22  ,   22  ,   22  ,   22  ,   22  ,   22  ,   22  ,   22  ,   22  ,   22  ,   22  ,   22  ,   22  ,   22  ,   22  ,   22  ,   22  ,   22  ,   22  ,   22  ,   22  ,   22  ,   -48 ,   22  ,   22  ,   22  ,   22  ,   0   ,   0,   0,   0},
                        { -502    ,   -502,  -502 ,  -502 ,   -502,  -502 ,  -502 ,  -502 ,  -502 ,  -502 ,  -502 ,  -502 ,  -502 ,  -502 ,  -502 ,  -502 ,  -502 ,  -502 ,  -502 ,  -502 ,  -502 ,  -502 ,  -502 ,  -502 ,  -502 ,  -502 ,  -502 ,   -48 ,  -502 ,  -502 ,  -502 ,  -502 ,  -502 ,  -502,   -502,   -502},
                        { 24      ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   -49 ,   24  ,   24  ,   24  ,   -503    ,   0,   24,   -503},
                        { 24      ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   24  ,   -49 ,   24  ,   24  ,   24  ,   -503    ,   0,   24,   -503 },
                        { -3      ,   25  ,   -3  ,   -3  ,   -3  ,   -3  ,   -3  ,   -3  ,   -3  ,   -3  ,   -3  ,   -3  ,   -3  ,   -3  ,   -3  ,   -3  ,   -3  ,   -3  ,   -3  ,   -3  ,   -3  ,   -3  ,   -3  ,   -3  ,   -3  ,   -3  ,   -3  ,   -3  ,   -3  ,   -3  ,   -3  ,   -3  ,   0   ,   -3,   -3,   -3},
                        { 26      ,   26  ,   26  ,   26  ,   26  ,   26  ,   26  ,   26  ,   26  ,   26  ,   26  ,   26  ,   27  ,   26  ,   26  ,   26  ,   26  ,   26  ,   26  ,   26  ,   26  ,   26  ,   26  ,   26  ,   26  ,   26  ,   26  ,   26  ,   26  ,   26  ,   26  ,   26  ,   0   ,   0,   0,   0},
                        { -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   0   ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   0   ,   -505,   -505,   -505},
                        { -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   0   ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   -505    ,   0   ,   -505,   -505,   -505
                }

            };
            
            
        }
        public int EDO, COL, TOKEN= 0;
        public string LEXEMA, error;
        public int LINEA;
        public char caracter;
        public int tok;
        
        /*public void fuente_ori(string xfuente)
        {
            fuente = xfuente;
        }*/
        public List<Token> analizarLexico(string xfuente)
        {
            GRID_TOKENS.Rows.Clear();
            string fuente = xfuente;
            int puntero = 0;
            LINEA = 1;
            
            do{
                if(caracter == '\n' || caracter == '\r' || caracter == '\t' || caracter == '\f')
                {
                    LEXEMA = "";
                    EDO = 0;
                }
                if (fuente == "") break;
                caracter = fuente[puntero];
                Encontrar_columna(caracter);

                EDO = MT[EDO, COL];

                if ((EDO < 0 && EDO > -500))
                {
                    TOKEN = EDO;
                    

                    if ((TOKEN == -12) || (TOKEN == -14) || (TOKEN == -48) || (TOKEN == -49)  || (TOKEN <= -16 && TOKEN >= -18) || (TOKEN == -20) || (TOKEN == -22) || (TOKEN == -23) || (TOKEN == -25) || (TOKEN == -26) || (TOKEN == -28) || (TOKEN == -30) || (TOKEN <= -33 && TOKEN >= -36) || (TOKEN == -38) || (TOKEN <= -40 && TOKEN >= -42))
                    {
                        LEXEMA += caracter;
                        Crear_token();
                        EDO = 0;
                        LEXEMA = "";
                        puntero += 1;
                        continue;

                    }
                    if (EDO == -1)
                    {
                        TOKEN = ComparaPR(LEXEMA);
                    }
                    if (LEXEMA != "" && LEXEMA != null)
                    {
                        Crear_token();
                    }
                    EDO = 0;

                    if (TOKEN <= -1)
                    {
                        Encontrar_columna(caracter);
                        EDO = MT[EDO, COL];
                        if (EDO <= -1 && EDO > -500)
                        {
                            LEXEMA = caracter.ToString();
                            TOKEN = EDO;
                            if (EDO == -1)
                            {
                                TOKEN = ComparaPR(LEXEMA);
                            }
                            Crear_token();

                            EDO = 0;
                            string nada = " ";
                            caracter = Convert.ToChar(nada);
                        }
                    }
                    LEXEMA = "";
                }
                if(EDO <= -500)
                {
                    if(caracter == '\n' || caracter == '\r' || caracter == 32)
                    {

                    }
                    else
                    {
                        LEXEMA = Convert.ToString(caracter);
                    }
                    TOKEN = EDO;
                    error = Encontrar_Error(TOKEN);
                    GRID_ERRORESS.Rows.Add(TOKEN, error);
                    EDO = 0;
                    LEXEMA = "";
                    puntero += 1;
                    continue;
                }
                if (caracter == '\n' || caracter == '\r' || caracter == 32)
                {
                    puntero += 1;
                    continue;
                }
                LEXEMA += caracter;
                puntero += 1;
                if(puntero == fuente.Length)
                {
                    TOKEN = EDO;
                    if(TOKEN == -1 || TOKEN == -100)
                    {
                        TOKEN = ComparaPR(LEXEMA);
                    }
                    if(TOKEN >= -500)
                    {
                        if(TOKEN == 23)
                        {
                            TOKEN = -503;
                            error = Encontrar_Error(TOKEN);
                            GRID_ERRORESS.Rows.Add(TOKEN, error);
                            LEXEMA = "";

                            EDO = 0;
                            puntero += 1;
                            break;
                        }
                        if (TOKEN == 24)
                        {
                            TOKEN = -503;
                            error = Encontrar_Error(TOKEN);
                            GRID_ERRORESS.Rows.Add(TOKEN, error);
                            LEXEMA = "";

                            EDO = 0;
                            puntero += 1;
                            break;
                        }
                        if (TOKEN == 21)
                        {
                            TOKEN = -502;
                            error = Encontrar_Error(TOKEN);
                            GRID_ERRORESS.Rows.Add(TOKEN, error);
                            LEXEMA = "";

                            EDO = 0;
                            puntero += 1;
                            break;
                        }
                        
                        Crear_token();
                        EDO = 0;
                        LEXEMA = "";
                        puntero += 1;
                    }
                    else
                    {
                        error = Encontrar_Error(TOKEN);
                        GRID_ERRORESS.Rows.Add(TOKEN, error);
                        EDO = 0;
                        LEXEMA = "";
                        puntero += 1;
                    }
                }
                if (puntero > fuente.Length) break;

            } while(fuente.Length > puntero);
            var token_fantasma = new Token();
            token_fantasma.token = 99;
            milista.Add(token_fantasma);
            milista2 = milista;
            return milista;

        }

        public int Encontrar_columna(char xcaracter)
        {
            caracter = xcaracter;
            int dg = 92;
            int espacio = 32;
            switch (caracter)
            {
                #region Todos los Case
                case '_':
                    COL = 2;
                    break;
                case '.':
                    COL = 3;
                    break;
                case '(':
                    COL = 4;
                    break;
                case ')':
                    COL = 5;
                    break;
                case '[':
                    COL = 6;
                    break;
                case ']':
                    COL = 7;
                    break;
                case '{':
                    COL = 8;
                    break;
                case '}':
                    COL = 9;
                    break;
                case '+':
                    COL = 10;
                    break;
                case '-':
                    COL = 11;
                    break;
                case '*':
                    COL = 12;
                    break;
                case '/':
                    COL = 13;
                    break;
                case '%':
                    COL = 14;
                    break;
                case '!':
                    COL = 15;
                    break;
                case '&':
                    COL = 16;
                    break;
                case '|':
                    COL = 17;
                    break;
                case '~':
                    COL = 18;
                    break;
                case '<':
                    COL = 19;
                    break;
                case '=':
                    COL = 20;
                    break;
                case '>':
                    COL = 21;
                    break;
                case ',':
                    COL = 22;
                    break;
                case ':':
                    COL = 23;
                    break;
                case ';':
                    COL = 24;
                    break;
                case '#':
                    COL = 25;
                    break;
                case '"':
                    COL = 28;
                    break;
                case '^':
                    COL = 29;
                    break;
                case '`':
                    COL = 30;
                    break;
                case '\r':
                    COL = 34;
                    break;
                case '\n':
                    COL = 34;
                    LINEA++;
                    break;
                case '\t':
                    COL = 34;
                    break;

                default:
                    COL = 33;
                    break;
                    #endregion

            }
            if (caracter == Convert.ToChar(dg)) COL = 26;
            if (caracter.ToString() == "'") COL = 27;
            if (char.IsDigit(caracter)) COL = 1;
            if (char.IsLetter(caracter)) COL = 0;
            if (caracter == Convert.ToChar(espacio)) COL = 31;

            return COL;
        }

        public void Crear_token()
        {
            string TIPO = Encontrar_Tipo(TOKEN);
            Token objtoken = new Token(TIPO, TOKEN, LEXEMA, LINEA);
            milista.Add(objtoken);
            GRID_TOKENS.Rows.Add(TIPO, TOKEN, LEXEMA, LINEA);
        }

        public string Encontrar_Tipo(int xtoken)
        {
            string tipo = null;

            if (xtoken == -1) tipo = "IDENTIFICADOR";
            else
                if (xtoken == -2) tipo = "ENTERO";

                else
                    if (xtoken == -3) tipo = "DECIMAL";

                    else
                        if ((xtoken <= -12 && xtoken >= -42) || xtoken == -50) tipo = "OPERADOR LOGICO";

                    else
                        if (xtoken <= -100 && xtoken >= -130) tipo = "PALABRA RESERVADA";

                            else 
                                if(xtoken == -60) tipo = "ID";
                                    else tipo = "DELIMITADOR";
            
            return tipo;
        }

        public int ComparaPR(string Clexema)
        {
            switch (Clexema)
            {
                case "AND":
                    toke = -100;
                    break;
                case "WRITE":
                    toke = -101;
                    break;
                case "READ":
                    toke = -102;
                    break;
                case "BREAK":
                    toke = -103;
                    break;
                case "CLASS":
                    toke = -104;
                    break;
                case "CONTINUE":
                    toke = -105;
                    break;
                case "DEF":
                    toke = -106;
                    break;
                case "DEL":
                    toke = -107;
                    break;
                case "ELIF":
                    toke = -108;
                    break;
                case "ELSE":
                    toke = -109;
                    break;
                case "EXCEPT":
                    toke = -110;
                    break;
                case "EXEC":
                    toke = -111;
                    break;
                case "FINALLY":
                    toke = -112;
                    break;
                case "FOR":
                    toke = -113;
                    break;
                case "FROM":
                    toke = -114;
                    break;
                case "PUBLIC":
                    toke = -115;
                    break;
                case "IF":
                    toke = -116;
                    break;
                case "IMPORT":
                    toke = -117;
                    break;
                case "IN":
                    toke = -118;
                    break;
                case "IS":
                    toke = -119;
                    break;
                case "LAMBDA":
                    toke = -120;
                    break;
                case "NOT":
                    toke = -121;
                    break;
                case "OR":
                    toke = -122;
                    break;
                case "PASS":
                    toke = -123;
                    break;
                case "PRINT":
                    toke = -124;
                    break;
                case "RAISE":
                    toke = -125;
                    break;
                case "RETURN":
                    toke = -126;
                    break;
                case "TRY":
                    toke = -127;
                    break;
                case "WHILE":
                    toke = -128;
                    break;
                case "WITH":
                    toke = -129;
                    break;
                case "YIELD":
                    toke = -130;
                    break;
                case "PRIVATE":
                    toke = -131;
                    break;
                case "INT":
                    toke = -132;
                    break;
                case "STRING":
                    toke = -133;
                    break;
                case "DOUBLE":
                    toke = -134;
                    break;
                case "CHAR":
                    toke = -135;
                    break;
                case "BOOL":
                    toke = -136;
                    break;
                case "MAIN":
                    toke = -137;
                    break;
                case "VOID":
                    toke = -138;
                    break;
                case "CATCH":
                    toke = -139;
                    break;
                case "SWITCH":
                    toke = -140;
                    break;
                case "CASE":
                    toke = -141;
                    break;
                case "DEFAULT":
                    toke = -142;
                    break;
                case "CONSTRUCTOR":
                    toke = -143;
                    break;
                default:
                    toke = -60;
                    break;
            }

            return toke;
        }

        public string Encontrar_Error(int xtoken)
        {
            string error = null;

            switch (xtoken)
            {
                case -500:
                    error = "Se esperaba una letra o numero";
                    break;
                case -501:
                    error = "Se esperaba un igual";
                    break;
                case -502:
                    error = "Se esperaba otra comilla simple";
                    break;
                case -503:
                    error = "Se esperaba otra comilla doble";
                    break;
                case -504:
                    error = "Se esperaba un numero";
                    break;
                case -505:
                    error = "Se esperaba una diagonal";
                    break;
            }
            return error;
        }
    }
}

