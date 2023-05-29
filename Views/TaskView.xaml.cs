using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using CareService.Models;
using CareService.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace CareService.Views
{
    /// <summary>
    /// Логика взаимодействия для TaskView.xaml
    /// </summary>
    public partial class TaskView : Page
    {
        private Models.Task _task = new Models.Task();

        //public IList<Models.Role> Roles 
        //{ 
        //    get 
        //    {
        //        using (ApplicationContext db = new ApplicationContext())
        //        {
        //            return db.Roles.ToList();
        //        }
        //    }
        //}

        public TaskView(Models.Task task)
        {
            InitializeComponent();
            
            if (task != null )
                _task = task;

            this.DataContext = _task;
            this.Title += _task.Name;

            using (ApplicationContext db = new ApplicationContext())
            {
                ComboStatus.ItemsSource = db.TaskStatuses.ToList();
                ComboManager.ItemsSource = db.Employees.ToList();

                var selectedEmployee = db.Employees.FirstOrDefault(e => e.Id == _task.ManagerID);
                var selectedStatus = db.TaskStatuses.FirstOrDefault(e => e.Id == _task.StatusID);

                ComboManager.SelectedItem = selectedEmployee;
                ComboStatus.SelectedItem = selectedStatus;

                if (_task.ManagerID != null )
                    _task.ManagerID = db.Employees.FirstOrDefault(e => e.Id == _task.ManagerID).Id;

                if (_task.StatusID != null)
                    _task.StatusID = db.Employees.FirstOrDefault(e => e.Id == _task.StatusID).Id;
            }

            //MessageBox.Show(_task.ManagerID);
        }

        public void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            PageManager.Frame.GoBack();
        }

        public void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_task.Name == null)
            {
                MessageBox.Show("Укажите название задачи");
                return;
            }
                

            using (ApplicationContext db = new ApplicationContext())
            {
                var dbTask = db.Tasks.Find(_task.Id);

                if (dbTask != null)
                {
                    db.Entry(dbTask).CurrentValues.SetValues(_task);
                }
                else
                {
                    var employeeID = ComboManager.SelectedItem as Employee;
                    db.Tasks.Add(_task);
                }

                db.SaveChanges();
            }

            PageManager.Frame.GoBack();
        }

        public void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var dbTask = db.Tasks.Find(_task.Id);

                if (dbTask != null)
                {
                    db.Entry(dbTask).Context.Remove(dbTask);
                    db.SaveChanges();
                }
            }

            PageManager.Frame.GoBack();
        }

        private void ComboManager_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Проверяем наличие выбранного элемента
            if (ComboManager.SelectedItem != null)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    // Получаем выбранного сотрудника из базы данных
                    var selectedEmployee = db.Employees
                        .FirstOrDefault(e => e.Id == ((Employee)ComboManager.SelectedItem).Id);

                   // MessageBox.Show($"Выбран сотрудник: {_task.ManagerID}");

                    // Записываем выбранного сотрудника в свойство Manager
                    _task.ManagerID = selectedEmployee.Id;
                }
            }
        }

        private void ComboStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Проверяем наличие выбранного элемента
            if (ComboStatus.SelectedItem != null)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    // Получаем выбранного сотрудника из базы данных
                    var selectedStatus = db.TaskStatuses
                        .FirstOrDefault(e => e.Id == ((Models.TaskStatus)ComboStatus.SelectedItem).Id);

                    // MessageBox.Show($"Выбран сотрудник: {_task.ManagerID}");

                    // Записываем выбранного сотрудника в свойство Manager
                    _task.ManagerID = selectedStatus.Id;
                }
            }
        }
    }
}
