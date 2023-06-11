using CompanyManagementApplikation.Backend;
using CompanyManagementApplikation.Classes;
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
    /// Interaktionslogik für HumanRessources.xaml
    /// </summary>
    public partial class HumanRessources : Window
    {
        public HumanRessources()
        {
            InitializeComponent();
            FillDataGrid();
        }

        private void HRDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void HRDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void AddUserFromDatagrid(object sender, RoutedEventArgs e)
        {

        }

        private void RefreshDataGrid(object sender, RoutedEventArgs e)
        {
            HRDataGrid.Items.Clear();
            FillDataGrid();
        }

        private async void FillDataGrid()
        {
            Database db = new Database();
            List<User> users = await db.GetEmployees();
            foreach (User user in users)
            {
                HRDataGrid.Items.Add(user);
            }
        }
    }
}
