using System.Collections.Generic;
using System.ServiceModel;

namespace CarManagmentInterface
{
    [ServiceContract]
    public interface ICarManagement
    {
        [OperationContract]
        int InsertNewcar(Car car);

        [OperationContract]
        bool RemoveCar(Car car);

        [OperationContract]
        void UpdateMillage(Car car);

        [OperationContract]
        List<Car> ListCars();

        [OperationContract]
        byte[] GetCarPicture(string carID);
    }
}