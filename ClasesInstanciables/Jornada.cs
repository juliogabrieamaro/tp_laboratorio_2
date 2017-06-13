using Exepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
namespace ClasesInstanciables
{
    /// <summary>
    /// contiene una lista de alumnos , una clase y el profesor asignado a la clase de dicha jornada
    /// guarda la jornada en un archivo de texto
    /// </summary>
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;

       
        /// <summary>
        /// propiedap de lectura y escritura que puede recibi un alummno y asignar a dicho atributo o lo retornarlo
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }
        /// <summary>
        /// propiedad de lectura y escritura que puede recibir una clase y asignar a dicho atributo o retornarla
        /// </summary>
        public Universidad.EClases Clase
        {
            get { return this._clase; }
            set { this._clase = value; }
        }
        /// <summary>
        /// propiedad de lectura y escritura que puede recibir un instructor y asignarlo a su atributo o returnarlo
        /// </summary>
        public Profesor Instructor
        {
            get { return this._instructor; }
            set { this._instructor = value; }
        }

       
        /// <summary>
        /// constructor privado que instancia la lista de alumnos
        /// </summary>
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }
        /// <summary>
        /// sobrecarga de constructor que asigna los datos recibidos por parametros de la clase y el instructor
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }

        
        /// <summary>
        /// verifica que e alumno este en la jornada tomando una clase
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return (a == j._clase);
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return (a != j._clase);
        }
        /// <summary>
        /// agrega a un alumno si no esta en la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            foreach (Alumno item in j._alumnos)
            {
                if (j == a)
                {
                    throw new AlumnoRepetidoException("Alumno repetido.");
                }
            }

            j._alumnos.Add(a);

            return j;
        }

       
        /// <summary>
        /// retrona los datos de la jornada
        /// el tipo de clase , su instructor y los alumnos que la toman
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder SB = new StringBuilder();

           
            SB.Append("CLASE DE " + this._clase);
            SB.AppendLine(this._instructor.ToString());

            foreach (Alumno item in this._alumnos)
            {
                SB.AppendLine(item.ToString());
            }

            SB.AppendLine("<------------------------------------------------->");

            return SB.ToString();
        }

        /// <summary>
        /// guarda la jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            try
            {
                using (StreamWriter escritor = new StreamWriter("Jornada.txt"))
                {
                    escritor.WriteLine(jornada.ToString());
                }
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }

            return true;
        }
        /// <summary>
        /// lee el archivo de texto y lo retorna
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            StringBuilder SB = new StringBuilder();
            string linea;

            try
            {
                using (StreamReader lector = new StreamReader("Jornada.txt"))
                {
                    while ((linea = lector.ReadLine()) != null)
                    {
                        SB.AppendLine(linea);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }

            return SB.ToString();
        }

       
    }
}
