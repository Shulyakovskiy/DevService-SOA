using System;
using DBModel;
using RentalInterface;

namespace RentalService
{
    public class RentalServiceImplementation : IRental
    {

        public string RegisterCarRental(RentalRegistration rentalRegistration)
        {
            Console.WriteLine("Register Car Rental");

            using (var dc = new CarRentalCaseEntities())
            {
                var rentalToInsert = new Rental
                {
                    CustomerID = rentalRegistration.CustomerID,
                    CarID = rentalRegistration.CarID,
                    Comments = rentalRegistration.Comments
                };

                dc.Rentals.Add(rentalToInsert);
                dc.SaveChanges();

                return "Add Rental Done";
            }
        }

        public void RegisterCarRentalAsPaid(string rentalID)
        {
            throw new System.NotImplementedException();
        }

        public void StartCarRental(string rentalID)
        {
            throw new System.NotImplementedException();
        }

        public void StopcarRental(string rentalID)
        {
            throw new System.NotImplementedException();
        }

        public RentalRegistration GetRentalRegistration(string rentalID)
        {
            throw new System.NotImplementedException();
        }
    }
}