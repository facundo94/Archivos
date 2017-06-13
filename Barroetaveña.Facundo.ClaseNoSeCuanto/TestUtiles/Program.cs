using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace TestUtiles
{
    class Program
    {
        static void Main(string[] args)
        {
            Lapicera l1 = new Lapicera(ConsoleColor.Black, "fino", "bic", 5);
            Goma g1 = new Goma(true, "Mapped", 2);
            Lapicera l2 = new Lapicera(ConsoleColor.Blue, "fino", "bic", 4);
            Goma g2 = new Goma(true, "Mapped", 3);
            Lapicera l3 = new Lapicera(ConsoleColor.Red, "Grueso", "bic", 2);
            Goma g3 = new Goma(false, "Mapped", 4);
            Cartuchera<Utiles> c = new Cartuchera<Utiles>("Nose", 4);
                        
            c.ElementoNuevo = l1;
            c.ElementoNuevo = l2;
            c.ElementoNuevo = l3;
            c.ElementoNuevo = g1;

            try
            {
                c.ElementoNuevo = g2;
            }
            catch (CartucheraLLenaException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                c.ElementoNuevo = g3;
            }
            catch (CartucheraLLenaException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Cartuchera:");
            Console.Write(c.ToString());
            Console.ReadLine();
            Console.Clear();

            //Por lo que entendi, para que los datos se guarden bien en un archivo,
            //la clase que vas a guardar tiene que tener al menos una manera 'publica' de obtener los datos.
            //A 'Lapicera', por ejemplo, le tuve que agregar propiedades para 'Trazo' y 'Color'

            //Serializo Lapicera a xml
            l1.SerializarXml("Lapicera.xml");

            Lapicera lv = new Lapicera();

            //Leo Lapicera de xml
            lv.DeSerializarXml("Lapicera.xml");

            Console.WriteLine("\nLapicera leida del archivo xml");
            Console.WriteLine(lv.ToString());

            //Serializo Lapicera a bin

            //Para que no tire exception tanto la clase a serializar (Lapicera en este caso) como
            //todas las clases de las que hereda esta (Utiles en este caso)
            //deben estar marcadas como [Serializable]
            l2.SerializarBin("Lapicera.dat");

            Lapicera lv2 = new Lapicera();
            //Leo Lapicera de bin
            lv2.DeSerializarBin("Lapicera.dat");

            Console.WriteLine("Lapicera leida del archivo bin");
            Console.WriteLine(lv2.ToString());

            //Serializo Lapicera a txt
            ExtendISerializable.SerializarTxt(l3, "Lapicera.txt");
            //Leo Lapicera desde txt
            Console.WriteLine("Lapicera leida del archivo txt");
            Console.WriteLine(ExtendISerializable.DeSerializarTxt("Lapicera.txt"));
            Console.ReadLine();
            Console.Clear();

            //Serializo Cartuchera a xml
            c.SerializarXml("Cartuchera.xml");

            Cartuchera<Utiles> cv = new Cartuchera<Utiles>();
            //Leo Cartuchera desde xml
            cv.DeSerializarXml("Cartuchera.xml");
            Console.WriteLine("Cartuchera leida dese xml");
            Console.Write(cv.ToString());
            Console.ReadLine();
            Console.Clear();

            //Serializo Cartuchera a xml
            c.SerializarBin("Cartuchera.bin");

            Cartuchera<Utiles> cv2 = new Cartuchera<Utiles>();
            //Leo Cartuchera desde xml
            cv2.DeSerializarBin("Cartuchera.bin");
            Console.WriteLine("Cartuchera leida desde bin");
            Console.Write(cv2.ToString());
            Console.ReadLine();
            Console.Clear();

            //Serializo Cartuchera a txt
            ExtendISerializable.SerializarTxt(c, "Cartuchera.txt");
            //Leo Cartuchera desde txt
            Console.WriteLine("Cartuchera leida del archivo txt");
            Console.WriteLine(ExtendISerializable.DeSerializarTxt("Cartuchera.txt"));

            Console.ReadLine();

        }
    }
}
