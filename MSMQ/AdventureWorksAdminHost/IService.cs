using System.ServiceModel;

[ServiceContract(Namespace="http://adventure-works.com/2010/07/01", 
                 Name="AdministrativeService")]
public interface IAdventureWorksAdmin
{
    [OperationContract(IsOneWay = true)]
    void GenerateDailySalesReport(string id);
}

