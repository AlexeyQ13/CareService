using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareService.Models.Entity;
using System.Windows.Data;

namespace CareService.Views
{
    public class RoleNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            int roleID = (int)value;

            using (var db = new ApplicationContext())
            {
                var role = db.Roles.FirstOrDefault(e => e.Id == roleID);

                if (role == null)
                    return null;

                return role.ToString();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
