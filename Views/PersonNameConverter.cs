using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using CareService.Models.Entity;

namespace CareService.Views
{
    public class PersonNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            int employeeId = (int)value;

            using (var db = new ApplicationContext())
            {
                var employee = db.Employees.FirstOrDefault(e => e.Id == employeeId);

                if (employee == null)
                    return null;

                return employee.ToString();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
