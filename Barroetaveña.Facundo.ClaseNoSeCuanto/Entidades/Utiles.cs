using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public abstract class Utiles
    {
        protected string _marca;
        protected double _precio;

        public Utiles()
        { }

        public Utiles(string marca, double precio)
        {
            this._marca = marca;
            this._precio = precio;
        }

        public abstract double Precio
        {
            get;
            set;
        }

        public abstract string Marca
        {
            get;
            set;
        }

        protected virtual string UtilesToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Marca: ");
            sb.AppendLine(this._marca);
            sb.Append("Precio: ");
            sb.AppendLine(this._precio.ToString());

            return sb.ToString();
        }

    }
}
