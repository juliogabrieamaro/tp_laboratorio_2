using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exepciones
{
   public class SinProfesorException:Exception
    {

       public SinProfesorException() : base() 
       { }
       public SinProfesorException(string message)
           : base(message)
        {
        }
    }
}
