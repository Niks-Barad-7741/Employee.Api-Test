using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee.Core.Entities
{
    public class Employe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9-._%+-]+@gmail\.com$")]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        [MinLength(10)] 
        [MaxLength(10)]
        public string Phone { get; set; }

        [Required]
        public string Department { get; set; }

        public Decimal Salary { get; set; }

        public bool IsDeleted { get; set; } = false;

        public ICollection<EmployeeRoles> EmployeeRoles { get; set; }
    }
}
