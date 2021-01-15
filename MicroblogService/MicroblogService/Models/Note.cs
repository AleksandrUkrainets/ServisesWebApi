﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MicroblogService.Models
{
    public class Note
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 10)]
        public string Title { get; set; }
        [Required]
        [StringLength(160, MinimumLength = 10)]
        public string Description { get; set; }
        [Required]
        public int UserId { get; set; } //class User

    }
}
