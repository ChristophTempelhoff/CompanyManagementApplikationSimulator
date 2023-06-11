using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CompanyManagementApplikation
{
    /// <summary>
    /// Interaktionslogik für ChooseAsManagement.xaml
    /// </summary>
    public partial class ChooseAsManagement : Window
    {
        public ChooseAsManagement()
        {
            InitializeComponent();
        }

        private void SendToHR(object sender, RoutedEventArgs e)
        {
            HumanRessources humanRessources = new HumanRessources();
            humanRessources.Show();
            this.Close();
        }
    }
}
