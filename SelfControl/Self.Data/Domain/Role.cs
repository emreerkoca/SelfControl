using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self.Data.Domain
{
    [Table("Role")]
    public class Role : BaseEntity
    {
        [Display(Name = "Role Name:")]
        [MinLength(3, ErrorMessage = "Min Length = 3 character"), MaxLength(150, ErrorMessage = "Max Length = 150 character")]
        public string RoleName { get; set; }
    }
}
