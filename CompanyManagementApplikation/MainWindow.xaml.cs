using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CompanyManagementApplikation.Backend;
using CompanyManagementApplikation.Classes;

namespace CompanyManagementApplikation
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

        public async void TryLogIn(object sender, RoutedEventArgs e)
        {
            Database database = new Database();
            if (await database.CheckLogIn(Username.Text, Password.Password))
            {
                MessageBox.Show("Erfolg!");
                return;
            }
            MessageBox.Show("Username or password is wrong.");
        }

        public void CheckForEnter(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return)
            {
                TryLogIn(sender, e);
            }
        }
    }
}
