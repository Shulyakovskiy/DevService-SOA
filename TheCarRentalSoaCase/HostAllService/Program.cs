using System;
using System.ServiceModel;

namespace HostAllService
{
    class Program
    {
        private static ServiceHost _carManagementServiceHost;
        private static ServiceHost _customerServiceHost;
        private static ServiceHost _rentalServicehost;
        private static ServiceHost _externalServiceHost;
        static void Main(string[] args)
        {
            Console.WriteLine("ServiceHost");

            try
            {
                _carManagementServiceHost = new ServiceHost(typeof(CarManagementService.CarManagmentImplementation));
                _carManagementServiceHost.Open();

                _customerServiceHost = new ServiceHost(typeof(CustomerService.CustomerServiceImplementation));
                _customerServiceHost.Open();

                _rentalServicehost = new ServiceHost(typeof(RentalService.RentalServiceImplementation));
                _rentalServicehost.Open();

                _externalServiceHost = new ServiceHost(typeof(ExternalInterfaceFacade.ExternalInterfaceFacadeImplementation));
                _externalServiceHost.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("ServiceStarted");

            Console.ReadKey();
        }
    }
}
