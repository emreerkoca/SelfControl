using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Self.Core.Entities
{
    [Table("Notification")]
    public class Notification : BaseEntity
    {
        public Word WordContent{ get; set; }
    }
}
