using MeetingsAPI.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingsAPI.DTOs
{
    public class MemberJoiningDTO
    {
        [Required]
        public int MeetingId { get; set; }
        public MemberCreatingDTO Member { get; set; }

    }
}
