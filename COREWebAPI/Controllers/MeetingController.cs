using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

[ApiController]
[Route("[controller]")]
public class MeetingController : ControllerBase
{
    private static readonly ConcurrentDictionary<int, Meeting> Meetings = new();
    private static int _idCounter = 1;

    [HttpGet("{id}")]
    public ActionResult<Meeting> GetMeeting(int id)
    {
        if (Meetings.TryGetValue(id, out var meeting))
            return Ok(meeting);
        throw new Exception("Meeting not found."); // Will be caught by the global handler
    }

    [HttpGet]
    public ActionResult<IEnumerable<Meeting>> GetAllMeetings()
    {
        return Ok(Meetings.Values);
    }

    [HttpPost]
    public ActionResult<Meeting> ScheduleMeeting([FromBody] Meeting meeting)
    {
        meeting.Id = _idCounter++;
        Meetings[meeting.Id] = meeting;
        return CreatedAtAction(nameof(GetMeeting), new { id = meeting.Id }, meeting);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMeeting(int id, [FromBody] Meeting updated)
    {
        if (!Meetings.ContainsKey(id))
            throw new Exception("Meeting not found.");
        updated.Id = id;
        Meetings[id] = updated;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMeeting(int id)
    {
        if (Meetings.TryRemove(id, out _))
            return NoContent();
        throw new Exception("Meeting not found.");
    }
}

public class Meeting
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime ScheduledAt { get; set; }
    public string Organizer { get; set; }
}
