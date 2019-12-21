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

        [Display(Name = "Translated Word:")]
        [Required]
        [MaxLength(140, ErrorMessage = "Word meaning character limit can' t exceed 50")]
        public string EnglishMeaning { get; set; }

        [Required]
        [MaxLength(140, ErrorMessage = "Sentence character limit can' t exceed 50")]
        public string Sentence { get; set; }

        public int ViewCount { get; set; }

        [Required]
        public string OwnerId { get; set; }

    }
}
