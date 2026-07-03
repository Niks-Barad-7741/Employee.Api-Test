using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9-._%+-]+@gmail\.com$")]
        public string Email { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public string Phone { get; set; }

        [Required]
        public string Department { get; set; }

        public Decimal Salary { get; set; }

    }
}
