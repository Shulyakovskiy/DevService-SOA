﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdventureWorksAdminTestClient.AdventureWorksAdmin
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://adventure-works.com/2010/07/01", ConfigurationName="AdventureWorksAdminTestClient.AdventureWorksAdmin.AdministrativeService")]
    public interface AdministrativeService
    {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://adventure-works.com/2010/07/01/AdministrativeService/GenerateDailySalesRep" +
            "ort")]
        void GenerateDailySalesReport(string id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface AdministrativeServiceChannel : AdventureWorksAdminTestClient.AdventureWorksAdmin.AdministrativeService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AdministrativeServiceClient : System.ServiceModel.ClientBase<AdventureWorksAdminTestClient.AdventureWorksAdmin.AdministrativeService>, AdventureWorksAdminTestClient.AdventureWorksAdmin.AdministrativeService
    {
        
        public AdministrativeServiceClient()
        {
        }
        
        public AdministrativeServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName)
        {
        }
        
        public AdministrativeServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public AdministrativeServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public AdministrativeServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public void GenerateDailySalesReport(string id)
        {
            base.Channel.GenerateDailySalesReport(id);
        }
    }
}
