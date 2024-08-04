using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi_ef.Data;
using dotnet_webapi_ef.DTOs.Meeting;
using dotnet_webapi_ef.Mappers;
using dotnet_webapi_ef.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_webapi_ef.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeetingController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public  MeetingController(ApplicationDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll(){
            var Meetings = _context.Meetings;
            return Ok(Meetings);
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id){
            var Meeting = _context.Meetings.Find(id);
            if (Meeting == null)
            {
                return NotFound();
            }
            return Ok(Meeting.ToMeetingDTO());
        }
        [HttpPost]
        public IActionResult InsertMeeting([FromBody] MeetingDTO meetingDTO){
            Meeting meeting = meetingDTO.ToMeeting();
            _context.Meetings.Add(meeting);
            int rowAffs = _context.SaveChanges();
            if (rowAffs > 0)
            {
                return CreatedAtAction(nameof(GetById),new {id = meeting.Idx}, meeting.ToMeetingDTO());
            }
            return StatusCode(400);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateMeeting([FromRoute] int  id,[FromBody] MeetingDTO meetingDTO){
            var Meeting = _context.Meetings.Find(id);
            if (Meeting == null)
            {
                return NotFound();
            }
            Meeting.Detail = meetingDTO.Detail;
            Meeting.Meetingdatetime = meetingDTO.Meetingdatetime;
            Meeting.Latitude = meetingDTO.Latitude;
            Meeting.Longitude = meetingDTO.Longitude;
            _context.Meetings.Update(Meeting);
            int rowAffs = _context.SaveChanges();
            if (rowAffs > 0)
            {
                return AcceptedAtAction(nameof(GetById),new {id = Meeting.Idx}, Meeting.ToMeetingDTO());
            }
            return StatusCode(400);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMeeting([FromRoute] int  id){
            var Meeting = _context.Meetings.Find(id);
            if (Meeting == null)
            {
                return NotFound();
            }
            _context.Meetings.Remove(Meeting);
            int rowAffs = _context.SaveChanges();
            return Ok(rowAffs);
        }
    }
}