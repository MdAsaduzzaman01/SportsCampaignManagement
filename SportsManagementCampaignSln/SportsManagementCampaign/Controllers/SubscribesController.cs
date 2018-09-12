using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using SportsManagementCampaign.Models;
using System.Web.Http.Cors;

namespace SportsManagementCampaign.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using SportsManagementCampaign.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Subscribe>("Subscribes");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    //[EnableCors(origins: "http://localhost:37773", headers: "*", methods: "*")]
    public class SubscribesController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/Subscribes
        [EnableQuery]
        public IQueryable<Subscribe> GetSubscribes()
        {
            return db.Subscribes;
        }

        // GET: odata/Subscribes(5)
        [EnableQuery]
        public SingleResult<Subscribe> GetSubscribe([FromODataUri] int key)
        {
            return SingleResult.Create(db.Subscribes.Where(subscribe => subscribe.SubscribeId == key));
        }

        // PUT: odata/Subscribes(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Subscribe> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Subscribe subscribe = db.Subscribes.Find(key);
            if (subscribe == null)
            {
                return NotFound();
            }

            patch.Put(subscribe);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscribeExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(subscribe);
        }

        // POST: odata/Subscribes
        public IHttpActionResult Post(Subscribe subscribe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Subscribes.Add(subscribe);
            db.SaveChanges();

            return Created(subscribe);
        }

        // PATCH: odata/Subscribes(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Subscribe> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Subscribe subscribe = db.Subscribes.Find(key);
            if (subscribe == null)
            {
                return NotFound();
            }

            patch.Patch(subscribe);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscribeExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(subscribe);
        }

        // DELETE: odata/Subscribes(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Subscribe subscribe = db.Subscribes.Find(key);
            if (subscribe == null)
            {
                return NotFound();
            }

            db.Subscribes.Remove(subscribe);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubscribeExists(int key)
        {
            return db.Subscribes.Count(e => e.SubscribeId == key) > 0;
        }
    }
}
