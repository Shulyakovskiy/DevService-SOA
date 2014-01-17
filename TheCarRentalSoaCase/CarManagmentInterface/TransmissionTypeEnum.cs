using System.Runtime.Serialization;

namespace CarManagmentInterface
{
    [DataContract]
    public enum TransmissionTypeEnum
    {
        [EnumMember]
        Manual,
        [EnumMember]
        Automatic
    }
}