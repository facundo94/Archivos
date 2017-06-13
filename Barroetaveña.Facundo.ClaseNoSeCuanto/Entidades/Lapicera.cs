using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades 
{
    [Serializable]
    public class Lapicera : Utiles, ISerializable
    {
        protected ConsoleColor _color;
        protected string _trazo;

        public Lapicera()
        { }

        public Lapicera(ConsoleColor color, string trazo, string marca, double precio)
            :base (marca, precio)
        {
            this._color = color;
            this._trazo = trazo;
        }

        public override string Marca
        {
            get { return this._marca;}
            set { this._marca = value; }
        }

        public override double Precio
        {
            get { return this._precio; }
            set { this._precio = value; }
        }

        public string Trazo
        {
            get { return this._trazo; }
            set { this._trazo = value; }
        }

        public ConsoleColor Color
        {
            get { return this._color; }
            set { this._color = value; }
        }

        protected override string UtilesToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.UtilesToString());
            sb.Append("Color: ");
            sb.AppendLine(this._color.ToString());
            sb.Append("Trazo: ");
            sb.AppendLine(this._trazo);

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.UtilesToString();
        }

        public bool SerializarXml(string path)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Lapicera));
                XmlTextWriter writer = new XmlTextWriter(path, Encoding.UTF8);

                serializer.Serialize(writer, this);
                writer.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeSerializarXml(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Lapicera));
            XmlTextReader reader = new XmlTextReader(path);
            Lapicera l;

            try
            {
                //Uso una nueva lapicera por que no me deja usar 'this' directamente
                l = (Lapicera)serializer.Deserialize(new FileStream(path, FileMode.Open));
                this._color = l._color;
                this._marca = l._marca;
                this._precio = l._precio;
                this._trazo = l._trazo;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool SerializarBin(string path)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Create);

            try
            {
                bf.Serialize(fs, this);
                fs.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeSerializarBin(string path)
        {
            BinaryFormatter bf = new BinaryFormatter();
            Lapicera l;
            try
            {
                l = (Lapicera)bf.Deserialize(new FileStream(path, FileMode.Open));
                this._color = l._color;
                this._marca = l._marca;
                this._precio = l._precio;
                this._trazo = l._trazo;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
