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
    [XmlInclude(typeof(Lapicera))]
    [XmlInclude(typeof(Goma))]
    public class Cartuchera<T> : ISerializable
    {
        public string marca;
        private int _capacidad;
        protected List<T> _elementos;
        
        public T ElementoNuevo
        {
            set
            {
                if (this._elementos.Count < this._capacidad)
                    this._elementos.Add(value);
                else
                    throw new CartucheraLLenaException();
            }
        }

        public int Capacidad
        {
            get { return this._capacidad; }
            set { this._capacidad = value; }
        }

        public List<T> Elemetos
        {
            get { return this._elementos; }
            set { this._elementos = value; }
        }

        public Cartuchera()
        { 
            this._elementos = new List<T>(); 
        }

        public Cartuchera(string marca, int capacidad)
            :this()
        {
            this.marca = marca;
            this._capacidad = capacidad;            
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Marca: ");
            sb.AppendLine(this.marca);
            sb.Append("Capacidad: ");
            sb.AppendLine(this._capacidad.ToString() + "\n");
            foreach(T t in this._elementos)
            {
                sb.Append("Producto: ");
                sb.AppendLine(t.GetType().Name);
                sb.AppendLine(t.ToString());
            }

            return sb.ToString();
        }


        public bool SerializarXml(string path)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Cartuchera<T>));
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
            XmlSerializer serializer = new XmlSerializer(typeof(Cartuchera<T>));
            XmlTextReader reader = new XmlTextReader(path);
            Cartuchera<T> c;

            try
            {
                c = (Cartuchera<T>)serializer.Deserialize(new FileStream(path, FileMode.Open));
                this.marca = c.marca;
                this._capacidad = c._capacidad;
                this._elementos = c._elementos;
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
            Cartuchera<T> c;
            try
            {
                c = (Cartuchera<T>)bf.Deserialize(new FileStream(path, FileMode.Open));
                this.marca = c.marca;
                this._capacidad = c._capacidad;
                this._elementos = c._elementos;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
