using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.ServiceModel;


namespace AdventureWorksAdminHost
{
    /// <summary>
    /// Interaction logic for HostController.xaml
    /// </summary>

    public partial class HostController : Window
    {
        private ServiceHost adventureWorksAdminHost;

        public HostController()
        {
            InitializeComponent();
        }

        void start_Click(object sender, EventArgs e)
        {
            adventureWorksAdminHost = new ServiceHost(typeof(AdventureWorksAdmin));
            adventureWorksAdminHost.Open();
            stop.IsEnabled = true;
            start.IsEnabled = false;
            status.Text = "Service Running";
        }

        void stop_Click(object sender, EventArgs e)
        {
            adventureWorksAdminHost.Close();
            stop.IsEnabled = false;
            start.IsEnabled = true;
            status.Text = "Service Stopped";
        }
    }
}