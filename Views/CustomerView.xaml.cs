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
using System.Collections;

namespace CareService.Views
{
    /// <summary>
    /// Логика взаимодействия для CustomerView.xaml
    /// </summary>
    public partial class CustomerView : Page
    {
        private Models.Customer _customer = new Models.Customer();

        public CustomerView(Models.Customer customer)
        {
            InitializeComponent();

            if (customer != null)
                _customer = customer;

            this.DataContext = _customer;
            this.Title += string.Format("{0} {1}", _customer.FirstName, _customer.LastName);
        }

        public void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            PageManager.Frame.GoBack();
        }

        public void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_customer.FirstName == null)
            {
                MessageBox.Show("Укажите название задачи");
                return;
            }


            using (ApplicationContext db = new ApplicationContext())
            {
                var dbCustomer = db.Customers.Find(_customer.Id);

                if (dbCustomer != null)
                {
                    db.Entry(dbCustomer).CurrentValues.SetValues(_customer);
                }
                else
                {
                    //var employeeID = ComboManager.SelectedItem as Employee;
                    db.Customers.Add(_customer);
                }

                db.SaveChanges();
            }

            PageManager.Frame.GoBack();
        }

        public void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var dbCustomer = db.Customers.Find(_customer.Id);

                if (dbCustomer != null)
                {
                    db.Entry(dbCustomer).Context.Remove(dbCustomer);
                    db.SaveChanges();
                }
            }

            PageManager.Frame.GoBack();
        }
    }
}
