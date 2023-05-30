using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareService.Models.Entity;
using CareService.Views;

namespace CareService.ViewModels
{
    public class EmployeeListViewModel : ViewModelBase
    {
        private List<Models.Employee> _employeeList = new();
        public List<Models.Employee> Employeers { get => _employeeList; set => SetProperty(ref _employeeList, value); }

        public EmployeeListViewModel()
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    _employeeList = db.Employees.ToList();
                }
            }
            catch
            {

            }
        }
    }
}
