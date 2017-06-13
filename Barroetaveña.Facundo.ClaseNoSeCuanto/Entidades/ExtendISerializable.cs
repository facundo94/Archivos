using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Entidades
{
    public static class ExtendISerializable
    {
        //No me acuerdo si esto habia que hacerlo asi, asi que posiblemente sea cualquiera, pero guarda el archivo
        //y lee bien el txt, asi que soy feliz

        public static bool SerializarTxt(this ISerializable s,string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "Lapicera.txt"))
                {
                    sw.WriteLine(s.ToString());
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string DeSerializarTxt(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "Lapicera.txt"))
                {
                    return sr.ReadToEnd();
                }

            }
            catch (Exception)
            {
                return "";
            }
        }

    }
}
