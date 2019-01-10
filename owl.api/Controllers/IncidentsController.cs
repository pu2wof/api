using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using owl.api.Models;
using System.Web.Http;

namespace owl.api.Controllers
{
	[Route("api/[controller]")]
	public class IncidentsController : Controller
	{
		protected Context db = new Context();

		// GET: api/incidents
		[HttpGet]
		public IActionResult Get()
		{
			return Ok(db.Set<Incidents>());
		}

		// GET api/incidents/5
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var item = db.Set<Incidents>().Where(x => x.Id == id).FirstOrDefault();
			if(item == null)
			{
				return NotFound();
			}

			return Ok(item);
		}

		// POST api/incidents
		[HttpPost]
		public IActionResult Post([FromBody]Incidents incident)
		{
			if(!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			using (var context = new Context())
			{
				try
				{
					incident.CreatedAt = DateTime.UtcNow;
					incident.UpdatedAt = DateTime.UtcNow;
					context.Incidents.Add(incident);

					context.SaveChanges();

					return Created(Url.RouteUrl(incident.Id), incident.Id);
				}
				catch(Exception ex)
				{
					return StatusCode(StatusCodes.Status500InternalServerError, ex);
				}
			}
		}

		// PUT api/incidents/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody]Incidents updatedIncident)
		{
			if(!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var existing = db.Set<Incidents>().Where(x => x.Id == id).FirstOrDefault();

			if(existing == null)
			{
				return NotFound();
			}

			try
			{
				existing.Name = updatedIncident.Name;
				existing.Location = updatedIncident.Location;
				existing.Managers = updatedIncident.Managers;
				existing.Impacted = updatedIncident.Impacted;
				existing.Casualties = updatedIncident.Casualties;
				existing.UpdatedAt = DateTime.UtcNow;

				db.SaveChanges();

				return Ok();
			}
			catch(Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex);
			}
		}

		// DELETE api/incidents/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			using (var context = new Context())
			{
				try
				{
					var item = context.Incidents.Find(id);

					if(item == null)
					{
						return NotFound();
					}
						
					context.Incidents.Remove(item);
					await context.SaveChangesAsync();
					return NoContent();
				}
				catch(Exception ex)
				{
					return StatusCode(StatusCodes.Status500InternalServerError, ex);
				}
			}
		}
	}
}
