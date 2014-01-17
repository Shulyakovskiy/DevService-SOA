using System.Runtime.Serialization;

namespace RentalInterface
{
    [DataContract]
    public enum IncludedInsurance
    {
        [EnumMember]
        LiabilityInsurance = 1,
        [EnumMember]
        FireInsurance = 2,
        [EnumMember]
        TheftProtection = 4,
        [EnumMember]
        AllRiskInsurance = 1 + 2 + 4
    }
}