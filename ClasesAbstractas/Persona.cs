using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Exepciones;
namespace EntidadesAbstractas
{
    /// <summary>
    /// Contiente los datos Personales de una persona
    /// </summary>
    public abstract class Persona
    {
        /// <summary>
        /// enumerado de nacionalidades
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;

        /// <summary>
        /// inicializa una instancia por Defecto de la clase Persona.
        /// </summary>

        public Persona()
        {
            this.Apellido = "Sin asignar";
            this._nacionalidad = ENacionalidad.Extranjero;
            this._nombre = "Sin asignar";
        }
       
        /// <summary>
        /// Sobrecarga de la clase Persona se le asigna por parametros los datos de la Persona
        /// </summary>
        /// <param name="nombre">nombre</param>
        /// <param name="apellido">apellido</param>
        /// <param name="nacionalidad">nacionalidad</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            try
            {
                this.Apellido = apellido;
            }

            catch (AlumnoRepetidoException ex)
            {
                throw ex;
            }

            this._nacionalidad = nacionalidad;
            this.Nombre = nombre;


        }
        /// <summary>
        /// Sobrecarga de la clase Persona se le asigna por parametros los datos de la Persona pasados por parametro
        /// </summary>
        /// <param name="nombre">nombre</param>
        /// <param name="apellido">apellido</param>
        /// <param name="dni">Dni</param>
        /// <param name="nacionalidad">nacionalidad</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            try
            {
                this.Dni = dni;
            }
            catch (DniInvalidoException excepcion)
            {
                throw new DniInvalidoException("dni de persona invalido ", excepcion);
            }
            catch (NacionalidadInvalidaException excepcion)
            {
                throw excepcion;
            }

        }
        /// <summary>
        /// Sobrecarga de la clase Persona se le asigna por parametros los datos de la Persona pasados por parametro
        /// Valida el dni de la persona que corresponda con su Nacionalidad
        /// </summary>
        /// <param name="nombre">nombre</param>
        /// <param name="apellido">apellido</param>
        /// <param name="dni">Dni</param>
        /// <param name="nacionalidad">nacionalidad</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {

            try
            {
                this.StringToDNI = dni;
            }
            catch (DniInvalidoException excepcion)
            {
                throw new DniInvalidoException(excepcion.Message);
            }
            catch (NacionalidadInvalidaException excepcion)
            {
                throw excepcion;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura que recibe un apellido y lo valida antes de asignarlo
        /// </summary>
        public string Apellido
        {
            get { return this._apellido; }
            set
            {
                if (Persona.ValidarNombreApellido(value) != "Invalido")
                {
                    this._apellido = value;
                }
                else
                {
                    throw new AlumnoRepetidoException("error en Persona ");

                }
            }
        }
        /// <summary>
        /// Validad que el dni sea correspondiente a la nacionalidad antes de asignarlo
        /// </summary>
        public int Dni
        {
            get { return this._dni; }
            set
            {
                if (Persona.ValidarDNI(this._nacionalidad, value) == 0)
                {
                    throw new DniInvalidoException("DNI introducido invalido.");
                }
                else
                {
                    if (Persona.ValidarDNI(this._nacionalidad, value) == -1)
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no se concide con el numero de DNI.");
                    }
                    else
                    {
                        this._dni = value;
                    }
                }
            }
        }
        /// <summary>
        /// asigna y retorna la nacionalidad de la persona
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }
        }
        /// <summary>
        /// Propiedad de lectura y escritura que recibe un nombre y lo valida  antes de asignarlo
        /// </summary>
        public string Nombre
        {
            get { return this._nombre; }
            set
            {
                if (Persona.ValidarNombreApellido(value) != "Invalido")
                {
                    this._nombre = value;
                }
            }
        }
        /// <summary>
        /// Propiedad de escritura que recibe un dni y valida si es valido antes de asignarlo
        /// </summary>
        public string StringToDNI
        {
            set
            {
                int datoValidado = Persona.ValidarDNI(this._nacionalidad, value);

                if (datoValidado == 0)
                {
                    throw new DniInvalidoException("DNI introducido invalido.");
                }
                else
                {
                    if (datoValidado == -1)
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no se concide con el numero de DNI.");
                    }
                    else
                    {
                        this._dni = datoValidado;
                    }
                }
            }
        }

     

       
       
        /// <summary>
        /// valida el dni que no se pase de su rango y sea coincidente con su nacionalidad
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        static int ValidarDNI(ENacionalidad nacionalidad, int dato)
        {
            if ((nacionalidad == ENacionalidad.Argentino) && (dato < 1 || dato > 89999999))
            {
                return 0;
            }
            else
            {
                if (nacionalidad == ENacionalidad.Extranjero && dato < 89999999)
                {
                    return -1;
                }
            }

            return dato;
        }
        /// <summary>
        /// valida el dni que no se pase de su rango y sea coincidente con su nacionalidad
        /// y lo devuelva como un entero
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        static int ValidarDNI(ENacionalidad nacionalidad, string dato)
        {
            int datoValidado;

            if (int.TryParse(dato, out datoValidado))
            {
                return ValidarDNI(nacionalidad, datoValidado);
            }

            return 0;
        }
        /// <summary>
        /// validad nombre y apellido de la persona, que esten dentro de su rango
        /// devolvera
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        static string ValidarNombreApellido(string dato)
        {
            bool Valido = true;

            foreach (char item in dato)
            {
                if ((item < 'a' || item > 'z') && (item < 'A' || item > 'Z'))
                {
                    Valido = false;
                    break;
                }
            }

            if (Valido)
            {
                return dato;
            }

            return "Invalido";
        }

       
        /// <summary>
        /// retorna los datos de la persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder SB = new StringBuilder();

            SB.Append("NOMBRE COMPLETO: " + this._apellido);
            SB.AppendLine(", " + this._nombre);
            SB.AppendLine("NACIONALIDAD: " + this._nacionalidad);
            

            return SB.ToString();
        }
    }
}
