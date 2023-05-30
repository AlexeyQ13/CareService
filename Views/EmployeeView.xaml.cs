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
using CareService.Models;

namespace CareService.Views
{
    /// <summary>
    /// Логика взаимодействия для EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : Page
    {
        private Models.Employee _employee = new Models.Employee();

        public EmployeeView(Models.Employee employee)
        {
            InitializeComponent();

            if (employee != null)
                _employee = employee;
            this.DataContext = _employee;
            this.Title += string.Format("{0} {1}", _employee.FirstName, _employee.LastName);

            using (ApplicationContext db = new ApplicationContext())
            {
                ComboRole.ItemsSource = db.Roles.ToList();
                //ComboManager.ItemsSource = db.Employees.ToList();

                var selectedRole = db.Roles.FirstOrDefault(e => e.Id == _employee.RoleID);
                //var selectedStatus = db.TaskStatuses.FirstOrDefault(e => e.Id == _task.StatusID);

                ComboRole.SelectedItem = selectedRole;
                //ComboStatus.SelectedItem = selectedStatus;

                if (_employee.RoleID != 0)
                    _employee.RoleID = db.Roles.FirstOrDefault(e => e.Id == _employee.RoleID).Id;

                //if (_task.StatusID != null)
                //    _task.StatusID = db.Employees.FirstOrDefault(e => e.Id == _task.StatusID).Id;
            }
        }

        public void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            PageManager.Frame.GoBack();
        }

        public void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_employee.FirstName == null)
            {
                MessageBox.Show("Укажите название задачи");
                return;
            }

            if (PasswordTextBox != null)
                _employee.Password = PasswordTextBox.Text;


            using (ApplicationContext db = new ApplicationContext())
            {
                var dbEmployee = db.Employees.Find(_employee.Id);

                if (dbEmployee != null)
                {
                    db.Entry(dbEmployee).CurrentValues.SetValues(_employee);
                }
                else
                {
                    //var employeeID = ComboManager.SelectedItem as Employee;
                    db.Employees.Add(_employee);
                }

                db.SaveChanges();
            }

            PageManager.Frame.GoBack();
        }

        public void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var dbEmployee = db.Employees.Find(_employee.Id);

                if (dbEmployee != null)
                {
                    db.Entry(dbEmployee).Context.Remove(dbEmployee);
                    db.SaveChanges();
                }
            }

            PageManager.Frame.GoBack();
        }
    }
}
