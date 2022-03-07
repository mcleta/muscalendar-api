using Microsoft.AspNetCore.Mvc;
using MusCalendar.Models;
using MusCalendar.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace MusCalendar.Controllers
{
    [ApiController]
    [Route("api/event")]
    public class EventController : ControllerBase
    {
        private readonly MCServices _mCServices;

        public EventController(MCServices mCServices) =>
            _mCServices = mCServices;

        [HttpGet]
        public async Task<List<EventModel>> GetEvents() =>
            await _mCServices.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<EventModel>> GetEventById(string id)
        {
            var evento = await _mCServices.GetByIdAsync(id);

            if (evento is null)
            {
                return NotFound();
            }

            return Ok(evento);
        }

        [HttpGet("{title}")]
        public async Task<ActionResult<EventModel>> GetEventByTitle(string title)
        {
            var evento = await _mCServices.GetByTitleAsync(title);

            if (evento is null)
            {
                return NotFound();
            }

            return Ok(evento);
        }

        [HttpPost]
        public async Task<IActionResult> PostEvent(EventModel evento)
        {
            await _mCServices.InsertOneAsync(evento);

            return CreatedAtAction(nameof(GetEventById), new { id = evento.Id }, evento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(string id, EventModel alterEvento)
        {
            var evento = await _mCServices.GetByIdAsync(id);

            alterEvento.Id = evento.Id;

            await _mCServices.UpdateOneAsync(id, alterEvento);

            if (evento is null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(string id)
        {
            var evento = await _mCServices.GetByIdAsync(id);

            if (evento is null)
            {
                return NotFound();
            }

            await _mCServices.DeleteAsync(id);

            return NoContent();
        }
    }
}
