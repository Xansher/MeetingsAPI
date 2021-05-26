using AutoMapper;
using MeetingsAPI.DTOs;
using MeetingsAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingsAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<MeetingCreatingDTO, Meeting>();
            CreateMap<Meeting, MeetingDTO>().ForMember(x => x.Members, options => options.MapFrom(MapMeetingMembers)).ReverseMap();
            CreateMap<MemberCreatingDTO, Member>();
        }

        private List<MemberDTO> MapMeetingMembers(Meeting meeting, MeetingDTO meetingDTO)
        {
            var result = new List<MemberDTO>();
            if(meeting.MeetingsMembers != null)
            {
                foreach (var member in meeting.MeetingsMembers)
                {
                    result.Add(new MemberDTO()
                    {
                        Id = member.MemberId,
                        Name = member.Member.Name,
                        Email = member.Member.Email
                    });
                }
            }
            return result;
        }
    }
}
