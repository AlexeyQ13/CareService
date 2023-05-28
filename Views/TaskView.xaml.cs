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

        public TaskView(Models.Task task)
        {
            InitializeComponent();
            
            if (task != null ) 
                _task = task;

            this.DataContext = _task;
        }

        public void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            PageManager.Frame.GoBack();
        }

        public void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var dbTask = db.Tasks.Find(_task.Id);

                if (dbTask != null)
                {
                    db.Entry(dbTask).CurrentValues.SetValues(_task);
                    db.SaveChanges();
                }
            }
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
        }
    }
}
