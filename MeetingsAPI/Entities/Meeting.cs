using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingsAPI.Entities
{
    public class Meeting
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Name { get; set; }
        public string Type { get; set; }
        public List<MeetingsMembers> MeetingsMembers { get; set; }
    }
}
