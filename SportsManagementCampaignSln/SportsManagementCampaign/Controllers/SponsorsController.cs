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
    builder.EntitySet<Sponsor>("Sponsors");
    builder.EntitySet<Campaign>("Campaigns"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    //[EnableCors(origins: "http://localhost:37773", headers: "*", methods: "*")]
    public class SponsorsController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/Sponsors
        [EnableQuery]
        public IQueryable<Sponsor> GetSponsors()
        {
            return db.Sponsors;
        }

        // GET: odata/Sponsors(5)
        [EnableQuery]
        public SingleResult<Sponsor> GetSponsor([FromODataUri] int key)
        {
            return SingleResult.Create(db.Sponsors.Where(sponsor => sponsor.SponsorId == key));
        }

        // PUT: odata/Sponsors(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Sponsor> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Sponsor sponsor = db.Sponsors.Find(key);
            if (sponsor == null)
            {
                return NotFound();
            }

            patch.Put(sponsor);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SponsorExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(sponsor);
        }

        // POST: odata/Sponsors
        public IHttpActionResult Post(Sponsor sponsor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sponsors.Add(sponsor);
            db.SaveChanges();

            return Created(sponsor);
        }

        // PATCH: odata/Sponsors(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Sponsor> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Sponsor sponsor = db.Sponsors.Find(key);
            if (sponsor == null)
            {
                return NotFound();
            }

            patch.Patch(sponsor);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SponsorExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(sponsor);
        }

        // DELETE: odata/Sponsors(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Sponsor sponsor = db.Sponsors.Find(key);
            if (sponsor == null)
            {
                return NotFound();
            }

            db.Sponsors.Remove(sponsor);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Sponsors(5)/Campaign
        [EnableQuery]
        public SingleResult<Campaign> GetCampaign([FromODataUri] int key)
        {
            return SingleResult.Create(db.Sponsors.Where(m => m.SponsorId == key).Select(m => m.Campaign));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SponsorExists(int key)
        {
            return db.Sponsors.Count(e => e.SponsorId == key) > 0;
        }
    }
}
