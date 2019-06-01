using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using owl.api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace owl.api.Controllers
{
	[Route("api/[controller]")]
	public class ClusterdatasController : Controller
	{
		protected ibmclouddbContext db;

		public ClusterdatasController(IOptions<EnvironmentConfig> configuration)
		{
			db = new ibmclouddbContext(configuration);
		}

		// GET: api/incidents
		[HttpGet("{apiToken}")]
		public IActionResult Get(Guid apiToken)
		{
			//first lookup apiToken to ensure it's good and active
			//this will provide us with the correct company id to retrieve data
			var company = db.Companies.Where(x => x.ApiToken == apiToken).FirstOrDefault();
			if (company != null)
			{
				var clusterdata = db.Clusterdata.Where(x => x.CompanyId == company.Id).OrderByDescending(x => x.CreatedAt).Take(100).ToList();

				return Ok(clusterdata);
			}
			else
			{
				return BadRequest();
			}
		}

		// GET api/incidents/5
		[HttpGet("{apiToken}/{id}")]
		public IActionResult Get(Guid apiToken, int id)
		{
			var company = db.Companies.Where(x => x.ApiToken == apiToken).FirstOrDefault();
			if (company != null)
			{
				var clusterdata = db.Clusterdata.Where(x => x.CompanyId == company.Id && x.Id == id).SingleOrDefault();
				if (clusterdata != null)
				{
					return Ok(clusterdata);
				}
				else
				{
					return NotFound();
				}
			}
			else
			{
				return BadRequest();
			}
		}
	}
}
