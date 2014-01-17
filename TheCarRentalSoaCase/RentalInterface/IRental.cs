using System.ServiceModel;

namespace RentalInterface
{
    [ServiceContract]
    public interface IRental
    {
        [OperationContract]
        string RegisterCarRental(RentalRegistration rentalRegistration);

        [OperationContract]
        void RegisterCarRentalAsPaid(string rentalID);

        [OperationContract]
        void StartCarRental(string rentalID);

        [OperationContract]
        void StopcarRental(string rentalID);

        [OperationContract]
        RentalRegistration GetRentalRegistration(string rentalID);
    }
}