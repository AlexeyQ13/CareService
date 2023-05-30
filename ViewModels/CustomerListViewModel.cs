using System.Collections.Generic;
using System.Linq;
using CareService.Models.Entity;

namespace CareService.ViewModels
{
    public class CustomerListViewModel : ViewModelBase
    {
        private List<Models.Customer> _customerList = new();
        public List<Models.Customer> Customers { get => _customerList; set => SetProperty(ref _customerList, value); }

        public CustomerListViewModel()
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    _customerList = db.Customers.ToList();
                }
            }
            catch
            {

            }
        }
    }
}
