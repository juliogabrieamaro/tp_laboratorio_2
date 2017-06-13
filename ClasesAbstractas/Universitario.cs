using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    /// <summary>
    /// hereda de la Clase persona y tiene un atributo privado llamado legajo
    /// </summary>
    public abstract class Universitario : Persona
    {
        private int legajo;

       
        /// <summary>
        /// contructor por defecto que inicializa los datos del universitario tomando datos del base
        /// </summary>
        public Universitario() : base()
        {
        }
      /// <summary>
      /// sobrecarga del contructor que asigna el legajo y los datos tomados por la base
      /// </summary>
      /// <param name="legajo"></param>
      /// <param name="nombre"></param>
      /// <param name="apellido"></param>
      /// <param name="dni"></param>
      /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

      
        /// <summary>
        /// metodo virtual que muestra los datos del universitario
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder SB = new StringBuilder();
            
            SB.AppendLine(base.ToString());
            SB.AppendLine("LEGAJO NúMERO: " + this.legajo);

            return SB.ToString();
        }
        /// <summary>
        /// sobrecarga de metodo equals verifica si el objeto es un universitario
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (obj is Universitario);
        }
        /// <summary>
        /// metodo abstracto que retorna la clase en la que participa
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        

      

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return (pg1.Equals(pg2) && (pg1.Dni == pg2.Dni || pg1.legajo == pg2.legajo));
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

    
    }
}
