using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareService.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? StatusID { get; set; }
        public int? ManagerID { get; set; }
        public Employee? Manager { get; set; }
        public DateTime Deadline { get; set; } = DateTime.Now;
    }
}
