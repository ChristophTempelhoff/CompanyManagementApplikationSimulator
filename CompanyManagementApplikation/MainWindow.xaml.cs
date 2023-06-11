using System.Windows;
using System.Windows.Input;
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
            var res = await database.CheckLogIn(Username.Text, Password.Password);
            if (res.HasValue)
            {
                User user = await database.GetEmployee(res.Value);
                if(user.Team == "Management")
                {
                    ChooseAsManagement chooseAsManagement = new();
                    chooseAsManagement.Show();
                    this.Close();
                }
                else if(user.Team == "HR")
                {
                    HumanRessources humanRessources = new();
                    humanRessources.Show();
                    this.Close();
                }
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
