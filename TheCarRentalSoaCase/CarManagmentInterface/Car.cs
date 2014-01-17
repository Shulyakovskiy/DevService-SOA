using System.Runtime.Serialization;

namespace CarManagmentInterface
{
   [DataContract]
    public class Car
    {
       [DataMember]
       public string BrandName { get; set; }
       [DataMember]
       public string TypeName { get; set; }
       [DataMember]
       public TransmissionTypeEnum Transmission { get; set; }
       [DataMember]
       public int NumberOfDoors { get; set; }
       [DataMember]
       public int NumberOfPerson { get; set; }
       [DataMember]
       public int MaxNumberOfPerson { get; set; }
       [DataMember]
       public int LitersOfLuggage { get; set; }
    }
}