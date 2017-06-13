using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using ClasesInstanciables;
using Exepciones;
namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidarNacionalidadInvalidaException()
        {
            

            try
            {
                Alumno alumno = new Alumno(8, "juan", "lopez", "2556448", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
            }
            catch (Exception excepcion)
            {
                Assert.IsInstanceOfType(excepcion, typeof(NacionalidadInvalidaException));
            }
        }

       

       
        [TestMethod]
        public void ValidarAlumnoRepetidoException()
        {
            Universidad universidad = new Universidad();
            Alumno alumno = new Alumno(1, "juan", "lopez", "2556448", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno otroAlumno = new Alumno(1, "juan", "lopez", "2556448", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            universidad += otroAlumno;

            try
            {
                universidad += otroAlumno;
            }
            catch (Exception excepcion)
            {
                Assert.IsInstanceOfType(excepcion, typeof(AlumnoRepetidoException));
            }
        }


     
    
       
        [TestMethod]
        public void validarNombreNulo()
        {
            Alumno Alumno;

            try
            {
                Alumno = new Alumno(4, null, "lalal", "124853", EntidadesAbstractas.Persona.ENacionalidad.Argentino,
            Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            
                Assert.Fail();
            }
            catch (NullReferenceException ex)
            {
                
            }

        }

        [TestMethod]
        public void validarApellidoNulo()
        {
            Alumno Alumno;

            try
            {
                Alumno = new Alumno(2, "lalal", null, "12333",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino,
            Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
                Assert.Fail();
            }
            catch (NullReferenceException ex)
            {


            }

        }
    }
}
