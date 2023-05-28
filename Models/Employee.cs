using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareService.Models
{
    public class Employee : Person
    {
        public string Login { get; set; }
        public string? Role { get; set; }
    }
}
