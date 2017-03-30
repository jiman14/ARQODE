using System;

namespace TLogic
{
    public static class Utils
    {
        /// <summary>
        /// Escapar carácteres especiales
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public static string escape_sc(string cadena)
        {

            string escape_chars = "á,é,í,ó,ú,Á,É,Í,Ó,Ú, ,ñ,Ñ,ü,Ü,-,(,),-";
            string replace_escape_chars = "a,e,i,o,u,A,E,I,O,U,_,n,N,u,U,_,_,_,_";
            string[] rec_array = replace_escape_chars.Split(',');
            int i = 0;
            foreach (string spc in escape_chars.Split(','))
            {
                cadena = cadena.Replace(spc, rec_array[i]);
                i++;
            }
            return cadena;
        }
    }
}
