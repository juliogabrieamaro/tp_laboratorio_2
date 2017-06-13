using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    /// <summary>
    /// clase sellada alumno que hereda de la clase universitaro
    /// contiente los datos de un profesor y los muestra
    /// 
    /// </summary>
    public sealed class Profesor:Universitario
    {
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;

      /// <summary>
      /// constructor statico que instancia el attributo _random
      /// </summary>
        static Profesor()
        {
            _random = new Random();
        }
        /// <summary>
        /// constructor por defecto que instancia la lista de clases
        /// y lanza un random de las clases
        /// </summary>
        public Profesor()
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        /// <summary>
        /// sobrecarga de constructor que instancia la lista de clases,lanza un random de las clases
        /// y asinga los datos recibidos por parametros a su base
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

       
        /// <summary>
        /// retorna los datos del profesor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder SB = new StringBuilder();
            
            SB.AppendLine(" POR " +base.MostrarDatos());
            SB.AppendLine(this.ParticiparEnClase());
            return SB.ToString();
        }

        /// <summary>
        /// hace un random de las clases y se la asigna a la lista de clases
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                this._clasesDelDia.Enqueue((Universidad.EClases)_random.Next(0, 4));
            }
        }

        /// <summary>
        /// metodo abstracto que retorna la clase en la que participa
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder SB = new StringBuilder();

            SB.AppendLine("CLASES DEL DÍA ");

            foreach (Universidad.EClases item in this._clasesDelDia)
            {
                SB.AppendLine(item.ToString());
            }

            return SB.ToString();
        }

        /// <summary>
        /// retorna datos de profesor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prof"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor prof, Universidad.EClases clase)
        {
            foreach (Universidad.EClases item in prof._clasesDelDia)
            {
                if (item == clase)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        
    }
}
