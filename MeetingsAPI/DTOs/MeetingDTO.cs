using MeetingsAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingsAPI.DTOs
{
    public class MeetingDTO
    {
        public int Id { get; set; }  
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<MemberDTO> Members { get; set; }
    }
}
