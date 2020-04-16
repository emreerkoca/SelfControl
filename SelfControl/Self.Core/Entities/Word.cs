using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Self.Core.Entities
{
    [Table("Word")]
    public class Word : BaseEntity
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Word character limit can' t exceed 50")]
        public string Vocable { get; set; }

        [Required]
        [MaxLength(140, ErrorMessage = "Word meaning character limit can' t exceed 50")]
        public string Meaning { get; set; }

        [Required]
        [MaxLength(140, ErrorMessage = "Sentence character limit can' t exceed 50")]
        public string Sentence { get; set; }

        public int ViewCount { get; set; }

        [Required]
        public string OwnerId { get; set; }

    }
}
