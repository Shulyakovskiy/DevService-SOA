using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace CustomerInterface
{
    [DataContractFormat]
    public class Customer
    {
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public string CustomerFirstName { get; set; }
        [DataMember]
        public string CustomerMiddleLetter { get; set; }
        [DataMember]
        public DateTime CustomerBirthDate { get; set; }
    }
}