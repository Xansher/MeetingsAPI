using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingsAPI.Entities
{
    public class MeetingsMembers
    {
        public int MeetingId { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}
