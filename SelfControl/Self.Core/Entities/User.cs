using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Self.Core.Entities
{
    [Table("User")]
    public class User : BaseEntity
    {
        [MaxLength(50, ErrorMessage = "Max Length: 50 ")]
        [Display(Name = "User name:")]
        public string UserName { get; set; }

        [Display(Name = "E-mail:")]
        [Required]
        [RegularExpression("^\\w+@[a-zA-Z_]+?\\.[a-zA-Z]{2,3}$", ErrorMessage = "Please enter valid email address!")]
        public string Email { get; set; }

        [MaxLength(50, ErrorMessage = "Max Length: 16 ")]
        [Display(Name = "Password:")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        public virtual Role UserRole { get; set; }
    }
}
