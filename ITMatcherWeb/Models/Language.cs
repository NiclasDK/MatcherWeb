﻿using System.ComponentModel.DataAnnotations;

namespace ITMatcherWeb.Models
{
    public class Language
    {
        public string LanguageId { get; set; }
        public string Name { get; set; }
        public LanguageMastery Mastery { get; set; }
        [Required]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int ApplicationUserId { get; set; }
    }

    public enum LanguageMastery
    {
        Basic,
        Good,
        Excellent,
        native,
    }


}