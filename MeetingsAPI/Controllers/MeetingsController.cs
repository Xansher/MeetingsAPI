using AutoMapper;
using MeetingsAPI.DTOs;
using MeetingsAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingsAPI.Controllers
{
    [ApiController]
    [Route("meetings")]
    public class MeetingsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public MeetingsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<MeetingDTO>>> Get()
        {
            var meetings = await context.Meetings.OrderBy(x => x.Date)
                .Include(x => x.MeetingsMembers).ThenInclude(x => x.Member)
                .ToListAsync(); ;
            return mapper.Map<List<MeetingDTO>>(meetings);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MeetingDTO>> Get(int id)
        {
            var meeting = await context.Meetings
                .Include(x => x.MeetingsMembers).ThenInclude(x => x.Member)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (meeting == null)
                return NotFound();

            return mapper.Map<MeetingDTO>(meeting);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] MeetingCreatingDTO meetingCreatingDTO)
        {
            var meeting = mapper.Map<Meeting>(meetingCreatingDTO);
            context.Add(meeting);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("join/{id:int}")]
        public async Task<ActionResult> AddMember(int id, [FromBody] MemberCreatingDTO memberDTO)
        {
            var meetingResult = await Get(id);
            if (meetingResult.Result is NotFoundResult)
                return NotFound("Not found meeting");

            if (meetingResult.Value.Members.Count >= 25)
                return Content("Meeting is full");

            var member = mapper.Map<Member>(memberDTO);
            context.Add(member);
    
            
            context.SaveChanges();
            context.MeetingsMembers.Add(new MeetingsMembers() { MeetingId = id, MemberId = member.Id });
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var meeting = await context.Meetings
                .Include(x => x.MeetingsMembers).ThenInclude(x => x.Member)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (meeting == null)
                return NotFound();

            context.Remove(meeting);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
