using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Client_WPF.MyServiceReference;

namespace Client_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e){

            ServiceJSONClient MyClient = ConfigureClientProxy();
            MyClient.Open();
            MyClient.MyMethodCompleted += new EventHandler<MyMethodCompletedEventArgs>(MyMethodCompleted);


            ServiceJSONInput InputData = new ServiceJSONInput{
                Customer= new Customer{
                    FirstName = "Steve",
                    LastName = "Jobs"
                },
                Account = new Account{
                    UserName = "my_user_name",
                    Password = "my_password"
                }
            };

            MyClient.MyMethodAsync(InputData);

        }



        private ServiceJSONClient ConfigureClientProxy(){

            BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportCredentialOnly);
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;

            // Replace <machinename> with the name of the development server.
            EndpointAddress remoteAddress = new EndpointAddress(string.Format("{0}/soap", wcfAddress.Text));

            ServiceJSONClient client = new ServiceJSONClient(binding, remoteAddress);
            using (HostingEnvironment.Impersonate())
            {
                client.ClientCredentials.Windows.ClientCredential = CredentialCache.DefaultNetworkCredentials;
            }

            return client;
        }

        static void MyMethodCompleted(object sender, MyMethodCompletedEventArgs e){
            ServiceJSONResult result = (ServiceJSONResult)e.Result;
            Console.WriteLine("Service Message: {0}", result.Message);
        }

    }
}
