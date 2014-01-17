using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace RentalInterface
{
    [DataContract]
    public class RentalRegistration
    {
        [DataMember]
        public int CustomerID { get; set; }
        [DataMember]
        public string CarID { get; set; }
        [DataMember]
        public int PickupLocation { get; set; }
        [DataMember]
        public int DropOfLocation { get; set; }
        [DataMember]
        public DateTime PickUpDateTime { get; set; }
        [DataMember]
        public DateTime DropOffDateTime { get; set; }
        [DataMember]
        public PaymentStatusEnum PaymentStatus { get; set; }
        [DataMember]
        public string Comments { get; set; }
    }
}
