using System.ServiceModel;

namespace CustomerInterface
{
    [ServiceContract]
    public interface ICustomer
    {
        [OperationContract]
        int RegisterCustomers(Customer customer);
    }
}