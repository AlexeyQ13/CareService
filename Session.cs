using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareService.Models;

namespace CareService
{
    public static class Session
    {
        public static Employee? User { get; set; }
    }
}
