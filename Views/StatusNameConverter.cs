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
    public class StatusNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            int statusID = (int)value;

            using (var db = new ApplicationContext())
            {
                var taskStatus = db.TaskStatuses.FirstOrDefault(e => e.Id == statusID);

                if (taskStatus == null)
                    return null;

                return taskStatus.ToString();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
