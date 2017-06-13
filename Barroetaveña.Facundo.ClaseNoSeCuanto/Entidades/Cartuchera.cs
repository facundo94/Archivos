using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cartuchera<T>
    {
        public string marca;
        private int _capacidad;
        protected List<T> _elementos;

        public Cartuchera(string marca, int capacidad)
        {
            this.marca = marca;
            this._capacidad = capacidad;
            this._elementos = new List<T>();
        }

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

    }
}
