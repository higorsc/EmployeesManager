using EmployeesManager.Helpers;
using EmployeesManager.Services.Interfaces;
using EmployeesManager.ViewModels;
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

namespace EmployeesManager.Views
{
    /// <summary>
    /// Interaction logic for CreateEmployeeWindow.xaml
    /// </summary>
    public partial class CreateEmployeeWindow : Window
    {
        public CreateEmployeeWindow(IEmployeesService employeesService, Mapper mapper)
        {
            InitializeComponent();
            DataContext = new CreateEmployeeViewModel(employeesService, mapper);
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
