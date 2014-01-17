using CustomerInterface;
using DBModel;
using Customer = CustomerInterface.Customer;


namespace CustomerService
{
    public class CustomerServiceImplementation : ICustomer
    {
        public int RegisterCustomers(Customer customer)
        {
            using (var dc = new CarRentalCaseEntities())
            {
                var customerToInsert = new DBModel.Customer
                {
                    CustomerName = customer.CustomerName,
                    CustomerFirstName = customer.CustomerFirstName
                };

                dc.Customers.Add(customerToInsert);
                dc.SaveChanges();

                return customerToInsert.CustomerID;
            }
        }
    }
}