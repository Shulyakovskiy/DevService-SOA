using System;
using AdventureWorksAdminTestClient.AdventureWorksAdmin;

namespace AdventureWorksAdminTestClient
{
    class Program
    {
        static void Main()
        {
            try
            {
                var proxy =
                    new AdministrativeServiceClient("MsmqBinding_AdventureWorksAdmin");

                Console.WriteLine("Press ENTER to send messages");
                Console.ReadLine();

                Console.WriteLine("Requesting first report at {0}", DateTime.Now);
                proxy.GenerateDailySalesReport("3 Report");
                Console.WriteLine("First report request completed at {0}", DateTime.Now);
                Console.WriteLine("Requesting second report at {0}", DateTime.Now);
                proxy.GenerateDailySalesReport("4 Report");
                Console.WriteLine("Second report request completed at {0}", DateTime.Now);

                proxy.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
            }

            Console.WriteLine("Press ENTER to finish");
            Console.ReadLine();
        }
    }
}
