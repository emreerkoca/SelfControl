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
        [Display(Name = "Original Word:")]
        [Required]
        [MaxLength(50, ErrorMessage = "Word character limit can' t exceed 50")]
        public string OriginalWord { get; set; }


        [Display(Name = "Translated Word:")]
        [Required]
        [MaxLength(50, ErrorMessage = "Word character limit can' t exceed 50")]
        public string TranslatedWord { get; set; }

        public int ViewCount { get; set; }

        public string Sentence { get; set; }
    }
}
