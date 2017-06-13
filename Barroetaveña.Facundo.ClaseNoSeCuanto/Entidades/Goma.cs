using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Goma : Utiles
    {
        protected bool _soloLapiz;

        public Goma(bool soloLapiz, string marca, double precio)
            :base(marca, precio)
        {
            this._soloLapiz = soloLapiz; ;
        }

        public override string Marca
        {
            get { return this._marca; }
            set { this._marca = value; }
        }

        public override double Precio
        {
            get { return this._precio; }
            set { this._precio = value; }
        }

        protected override string UtilesToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.UtilesToString());
            sb.Append("Solo lapiz? ");
            sb.AppendLine(this._soloLapiz.ToString());

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.UtilesToString();
        }

    }
}
