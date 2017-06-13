using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface ISerializable
    {
        bool SerializarXml(string path);
        bool SerializarBin(string path);
        bool DeSerializarXml(string path);
        bool DeSerializarBin(string path);
    }
}
