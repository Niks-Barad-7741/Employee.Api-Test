using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.DTO
{
    public class UpdateEmployeeDTO
    {
       public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Department { get; set; }

        public Decimal Salary { get; set; }
    }
}
