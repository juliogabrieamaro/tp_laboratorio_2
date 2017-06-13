using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using EntidadesAbstractas;
using Exepciones;
using ClasesInstanciables;
namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        
        public bool guardar(string archivo, Jornada datos)
        {
            XmlSerializer serializador = new XmlSerializer(datos.GetType());

            try
            {
                using (StreamWriter escritor = new StreamWriter(archivo))
                {
                    serializador.Serialize(escritor, datos);
                }
            }
            catch (Exception excepcion)
            {
                throw new ArchivosException(excepcion);
            }

            return true;
        }

       
        public bool leer(string archivo, out Jornada datos)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(Jornada));

            try
            {
                using (StreamReader lector = new StreamReader(archivo))
                {
                    datos = (Jornada)serializador.Deserialize(lector);
                }
            }
            catch (Exception excepcion)
            {
                throw new ArchivosException(excepcion);
            }

            return true;
        }

        public bool guardar(string archivo, T datos)
        {
            throw new NotImplementedException();
        }

        public bool leer(string archivo, out T datos)
        {
            throw new NotImplementedException();
        }
    }
}
