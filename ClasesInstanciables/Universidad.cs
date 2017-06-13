using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Exepciones;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
namespace ClasesInstanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Laboratorio,
            Programacion,
            Legislacion,
            SPD
        }

        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;


        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornadas = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }


        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return this.jornadas; }
            set { this.jornadas = value; }
        }

        public List<Profesor> Profesores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        public Jornada this[int indice]
        {
            get
            {
                if (indice < 0)
                {
                    return this.jornadas[0];
                }
                else
                {
                    if (indice >= 0 && indice < this.jornadas.Count)
                    {
                        return this.jornadas[indice];
                    }
                    else
                    {
                        return this.jornadas[(this.jornadas.Count) - 1];
                    }
                }
            }
            set
            {
                if (indice < 0)
                {
                    this.jornadas[0] = value;
                }
                else
                {
                    if (indice >= 0 && indice < this.jornadas.Count)
                    {
                        this.jornadas[indice] = value;
                    }
                    else
                    {
                        this.jornadas[(this.jornadas.Count)-1] = value;
                    }
                }
            }
        }

        public static Universidad operator +(Universidad univ, Alumno alum)
        {
            if (univ == alum)
            {
                throw new AlumnoRepetidoException("alumno repetido");
            }
            else
            {
                univ.alumnos.Add(alum);
            }

            return univ;
        
        }

        public static Universidad operator +(Universidad univ, EClases clase)
        {

           
            Jornada jornada;
            int cont = 0;

            foreach (Profesor item in univ.profesores)
            {
                if (item == clase)
                {

                  jornada   = new Jornada(clase, item);
                   

                      univ.Jornadas.Add(jornada);
                    
                    foreach (Alumno alum in univ.alumnos)
                    {
                        if (alum == clase)
                        {
                            jornada.Alumnos.Add(alum);

                        }

                    }
                    cont++;
                }
               
               
              
                   
            }
          


            if (cont == univ.profesores.Count)
            {
                throw new SinProfesorException("No hay profesor para esta clase");
            }

            return univ;
        }

        public static Universidad operator +(Universidad univ, Profesor prof)
        {
            foreach (Universitario item in univ.profesores)
            {
                if (item == (Universitario)prof)
                {
                    return univ;
                }
            }

            univ.profesores.Add(prof);

            return univ;

        }


        public static Profesor operator ==(Universidad univ, EClases clase)
        {
            Profesor Aux = new Profesor();
           
            int cont = 0;

            foreach (Profesor item in univ.profesores)
            {
                if (item == clase)
                {
                    Aux = item;
                    cont = -1;
                    break;
                }

                cont++;
            }

            if (cont == univ.profesores.Count)
            {
                throw new SinProfesorException();
            }

            return Aux;
        }

        public static bool operator ==(Universidad univ, Alumno alum)
        {
            foreach (Universitario item in univ.alumnos)
            {
                if (item == alum)
                {
                    
                    return true;
                }
            }

            return false;
        }

        public static bool operator !=(Universidad univ, Alumno alum)
        {
            return !(univ == alum);
        }


        public static bool operator ==(Universidad univ, Profesor prof)
        {
            foreach (Jornada item in univ.jornadas)
            {
                if (prof == item.Clase)
                {
                    return true;
                }
            }

            return false;
        }
        public static bool operator !=(Universidad univ, Profesor prof)
        {
            return !(univ == prof);
        }

        public static Profesor operator !=(Universidad univ, EClases clase)
        {
            Profesor Aux = new Profesor();

            int cont = 0;

            foreach (Profesor item in univ.profesores)
            {
                if (item != clase)
                {
                    Aux = item;
                    cont = -1;
                    break;
                }

                cont++;
            }

            if (cont == univ.profesores.Count)
            {
                throw new SinProfesorException();
            }

            return Aux;
        }






        public override string ToString()
        {
            return MostrarDatos(this);
        }


        private static string MostrarDatos(Universidad univ)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            foreach (Jornada item in univ.jornadas)
            {
                
                sb.AppendLine(item.ToString());
                
            }

            return sb.ToString();
        }

        public static bool Guardar(Universidad univ)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(Universidad));

            try
            {
                using (StreamWriter escritor = new StreamWriter("universidad.xml"))
                {
                    serializador.Serialize(escritor, univ);
                }
            }
            catch (Exception excepcion)
            {
                throw new ArchivosException(excepcion);
            }

            return true;
        }

        public static Universidad Leer()
        {
            Universidad Aux;
            XmlSerializer serializador = new XmlSerializer(typeof(Universidad));

            try
            {
                using (StreamReader lector = new StreamReader("universidad.xml"))
                {
                    Aux = (Universidad)serializador.Deserialize(lector);
                }
            }
            catch (Exception excepcion)
            {
                throw new ArchivosException(excepcion);
            }

            return Aux;
        }   

    }
}
