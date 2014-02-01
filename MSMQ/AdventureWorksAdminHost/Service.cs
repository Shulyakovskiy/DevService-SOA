using System;
using System.ServiceModel;
using System.Windows;

public class AdventureWorksAdmin : IAdventureWorksAdmin
{
    public void GenerateDailySalesReport(string id)
    {
        // Simulate generating the report 
        // by sleeping for 10 seconds
        System.Threading.Thread.Sleep(1000);
        MessageBox.Show("Report " + id + " generated");
    }
}

