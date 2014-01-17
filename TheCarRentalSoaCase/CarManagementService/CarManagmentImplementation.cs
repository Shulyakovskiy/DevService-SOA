using System;
using System.Collections.Generic;
using System.IO;
using CarManagmentInterface;

namespace CarManagementService
{
    public class CarManagmentImplementation : ICarManagement
    {

        public int InsertNewcar(Car car)
        {
            Console.WriteLine("InsertNewCar" + car.BrandName + " " + car.TypeName);
            return 1;
        }

        public bool RemoveCar(Car car)
        {
            Console.WriteLine("RemoveCar" + car.BrandName + " " + car.TypeName);
            return true;
        }

        public void UpdateMillage(Car car)
        {
           Console.WriteLine("UpdateMilage" + car.BrandName + " " + car.TypeName);
        }

        public List<Car> ListCars()
        {
            Console.WriteLine("ListCar");

            var listCar = new List<Car>
            {
                new Car {BrandName = "XXX", Transmission = TransmissionTypeEnum.Automatic, TypeName = "YYY"},
                new Car {BrandName = "XXX", Transmission = TransmissionTypeEnum.Manual, TypeName = "YYY"},
            };

            return listCar;
        }

        public byte[] GetCarPicture(string carID)
        {
            Console.WriteLine("GetCarPicture");

            byte[] buff;
            string pathToPicture;
            pathToPicture = @"H:\SRCDeveloper\DEVELOPER\4.2-WCF  Book and Unity\Developer\TheCarRentalSoaCase\CarManagementService\Pic\CarRentale.jpg";

            var fileStream = new FileStream(pathToPicture, FileMode.Open, FileAccess.Read);
            var binaryReader = new BinaryReader(fileStream);
            buff = binaryReader.ReadBytes((int) fileStream.Length);

            return buff;
        }
    }
}