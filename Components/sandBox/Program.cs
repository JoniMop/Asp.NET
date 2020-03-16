using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class Program
    {


        static void Main(string[] args)
        {

            DoIt();

        }

        public static void DoIt()
        {
            try
            {
                var mng = new UsuarioManager();
                var customer = new Usuario();

                Console.WriteLine("Customers CRUD options");
                Console.WriteLine("1.CREATE");


                Console.WriteLine("Choose an option: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("***************************");
                        Console.WriteLine("*****     CREATE    *******");
                        Console.WriteLine("***************************");
                        Console.WriteLine("Type the id");
                        var cedula = Console.ReadLine();
                        Console.WriteLine("Type the rol");
                        var rol = Console.ReadLine();

                        mng.Create(cedula, rol);

                        Console.WriteLine("Customer was created");

                        break;

                 
                }
            }
            catch (BussinessException bex)
            {
                Console.WriteLine("***************************");
                Console.WriteLine("ERROR: \n");
                Console.WriteLine(bex.AppMessage.Message);
                Console.WriteLine("***************************");
            }
            finally
            {
                Console.WriteLine("Continue? Y/N");
                var moreActions = Console.ReadLine();

                if (moreActions.Equals("Y", StringComparison.CurrentCultureIgnoreCase))
                    DoIt();
            }

            Console.ReadLine();
        }
    }
}
