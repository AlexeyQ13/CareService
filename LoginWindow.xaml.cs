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
using CareService.Models.Entity;

namespace CareService
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ApplicationContext())
            {
                try
                {
                    var authSession = db.Employees.First(e => e.Login == LoginTextBox.Text);

                    if (authSession.Password != PasswordTextBox.Password) 
                    {
                        MessageBox.Show("Ошибка, указан неверный пароль");
                        return;
                    }

                    Session.User = authSession;

                    Window newWindow = new MainWindow();
                    newWindow.Show();

                    this.Close();
                }
                catch 
                {
                    MessageBox.Show("Ошибка, указанный пользователь не найден");
                }
                //db.Roles.FirstOrDefault(e => e.Id == _employee.RoleID).Id
            }

            
        }
    }
}
