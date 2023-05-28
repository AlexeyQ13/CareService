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

namespace CareService.Views
{
    /// <summary>
    /// Логика взаимодействия для TaskList.xaml
    /// </summary>
    public partial class TaskList : Page
    {
        public TaskList()
        {
            InitializeComponent();
            this.DataContext = new ViewModels.TaskListViewModel();
        }

        private void ViewTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            PageManager.Frame.Navigate(new TaskView((sender as Button).DataContext as Models.Task));
        }
    }
}
