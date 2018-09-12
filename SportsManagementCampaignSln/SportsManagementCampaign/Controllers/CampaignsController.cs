using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using SportsManagementCampaign.Models;

namespace SportsManagementCampaign.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using SportsManagementCampaign.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Campaign>("Campaigns");
    builder.EntitySet<Employee>("Employees"); 
    builder.EntitySet<Player>("Players"); 
    builder.EntitySet<Sponsor>("Sponsors"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    //[EnableCors(origins: "http://localhost:37773", headers: "*", methods: "*")]
   
    public class CampaignsController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/Campaigns
        [EnableQuery]
        public IQueryable<Campaign> GetCampaigns()
        {
            return db.Campaigns;
        }

        // GET: odata/Campaigns(5)
        [EnableQuery]
        public SingleResult<Campaign> GetCampaign([FromODataUri] int key)
        {
            return SingleResult.Create(db.Campaigns.Where(campaign => campaign.CampaignId == key));
        }

        // PUT: odata/Campaigns(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Campaign> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Campaign campaign = db.Campaigns.Find(key);
            if (campaign == null)
            {
                return NotFound();
            }

            patch.Put(campaign);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampaignExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(campaign);
        }

        // POST: odata/Campaigns
        public IHttpActionResult Post(Campaign campaign)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Campaigns.Add(campaign);
            db.SaveChanges();

            return Created(campaign);
        }

        // PATCH: odata/Campaigns(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Campaign> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Campaign campaign = db.Campaigns.Find(key);
            if (campaign == null)
            {
                return NotFound();
            }

            patch.Patch(campaign);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampaignExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(campaign);
        }

        // DELETE: odata/Campaigns(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Campaign campaign = db.Campaigns.Find(key);
            if (campaign == null)
            {
                return NotFound();
            }

            db.Campaigns.Remove(campaign);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Campaigns(5)/Employee
        [EnableQuery]
        public SingleResult<Employee> GetEmployee([FromODataUri] int key)
        {
            return SingleResult.Create(db.Campaigns.Where(m => m.CampaignId == key).Select(m => m.Employee));
        }

        // GET: odata/Campaigns(5)/Players
        [EnableQuery]
        public IQueryable<Player> GetPlayers([FromODataUri] int key)
        {
            return db.Campaigns.Where(m => m.CampaignId == key).SelectMany(m => m.Players);
        }

        // GET: odata/Campaigns(5)/Sponsors
        [EnableQuery]
        public IQueryable<Sponsor> GetSponsors([FromODataUri] int key)
        {
            return db.Campaigns.Where(m => m.CampaignId == key).SelectMany(m => m.Sponsors);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CampaignExists(int key)
        {
            return db.Campaigns.Count(e => e.CampaignId == key) > 0;
        }
    }
}
