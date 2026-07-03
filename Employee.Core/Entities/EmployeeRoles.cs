using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.Entities
{
    public class EmployeeRoles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public int RoleId { get; set; }


        [ForeignKey("EmplyeeId")]
        public Employe Employe { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }
    }
}
