using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self.Data.Domain
{
    [Table("Sentence")]
    public class Sentence : BaseEntity
    {
        [MaxLength(140,ErrorMessage = "Word character limit can' t exceed 140")]
        public string SentenceContent { get; set; }
    }
}
