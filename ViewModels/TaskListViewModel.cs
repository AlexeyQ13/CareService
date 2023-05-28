using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CareService.Models;
using CareService.Models.Entity;
using CareService.Views;

namespace CareService.ViewModels
{
    public class TaskListViewModel : ViewModelBase
    {
        private List<Models.Task> _taskList = new();
        public List<Models.Task> Tasks { get => _taskList; set => SetProperty(ref _taskList, value); }

        public TaskListViewModel() 
        {
            try
            {
                using (ApplicationContext db  = new ApplicationContext())
                {
                    _taskList = db.Tasks.ToList();
                }
            }
            catch 
            {

            }
        }
    }
}
