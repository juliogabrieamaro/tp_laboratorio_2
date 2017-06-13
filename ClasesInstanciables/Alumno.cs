using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
namespace ClasesInstanciables
{
    /// <summary>
    /// clase sellada alumno que hereda de la clase universitaro
    /// contiente los datos de un alumno y los muestra
    /// </summary>
    public sealed class Alumno : Universitario
    {
        /// <summary>
        ///enumerado del estado del alumno
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia,
            Becado,
            Deudor
        }

        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

       
        /// <summary>
        /// contructor por defecto que inicializa la clase que toma el alumno y su estado
        /// </summary>
        public Alumno()
            : base()
        {
            this._claseQueToma = Universidad.EClases.Laboratorio;
            this._estadoCuenta = EEstadoCuenta.Deudor;
        }
        /// <summary>
        /// sobrecarga del constructor que instancia la clase que toma el alumno recibida por parametro
        /// y asigna los demás datos a su base
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }
        /// <summary>
        /// sobrecarga del constructor que instancia el estado de cuenta del alumno recibida por parametro
        /// y asigna los demás datos a su base
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

       
        /// <summary>
        /// muestra los datos del alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder SB = new StringBuilder();

            SB.AppendLine("ALUMNOS: ");
            SB.AppendLine(base.MostrarDatos());
            SB.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta);
            SB.AppendLine(this.ParticiparEnClase());

           

            return SB.ToString();
            
        }
        /// <summary>
        /// retorna la clase que toma el alumno
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return string.Format("TOMA CLASES DE " + this._claseQueToma);
        }

        /// <summary>
        /// retorna los datos del alumno
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

       /// <summary>
       /// retorna true si el alumno no es deudor y esta tomando la clase
       /// retorna false si el alumno es un deudor y sigue tomando la clase
       /// </summary>
       /// <param name="a"></param>
       /// <param name="clase"></param>
       /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return (a._estadoCuenta != EEstadoCuenta.Deudor && a._claseQueToma == clase);
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return (a._claseQueToma != clase);
        }

       
    }
}
