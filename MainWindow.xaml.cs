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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CareService.Models.Entity;

namespace CareService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SessionInfo.DataContext = CareService.Session.User;
            PageManager.Frame = Frame;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                //db.Tasks.Add(new Models.Task() { Name = "задача намбэр ту", Description = "нет." });
                try
                {
                    //db.Employees.Add(new Models.Employee() { FirstName = "Алексей", LastName = "Горшков", Login = "admin", Password = "admin" });
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
        }

        private void TasksBtn_Click(object sender, RoutedEventArgs e)
        {
            PageManager.Frame.Navigate(new Views.TaskList());
        }

        private void CustomersBtn_Click(object sender, RoutedEventArgs e)
        {
            PageManager.Frame.Navigate(new Views.CustomerList());
        }

        private void EmployeersBtn_Click(object sender, RoutedEventArgs e)
        {
            PageManager.Frame.Navigate(new Views.EmployeeList());
        }
    }
}
