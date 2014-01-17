using System.Runtime.Serialization;

namespace RentalInterface
{
    [DataContract]
    public enum PaymentStatusEnum
    {
        [EnumMember(Value = "PUV")]
        PaidUpFrontByVaucher,
        [EnumMember(Value = "PUC")]
        PaidUpFronByCreditCard,
        [EnumMember(Value = "TPP")]
        ToBePaidAtPicUp,
        [EnumMember(Value = "INV")]
        ToBePaidByInvoice
    }
}