﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingsAPI.DTOs
{
    public class MeetingCreatingDTO
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
