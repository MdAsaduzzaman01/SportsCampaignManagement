﻿using System;
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

namespace SportsManagementCampaign.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using SportsManagementCampaign.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<UserDetails>("UserDetails");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class UserDetailsController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/UserDetails
        [EnableQuery]
        public IQueryable<UserDetails> GetUserDetails()
        {
            return db.UserDetails;
        }

        // GET: odata/UserDetails(5)
        [EnableQuery]
        public SingleResult<UserDetails> GetUserDetails([FromODataUri] string key)
        {
            return SingleResult.Create(db.UserDetails.Where(userDetails => userDetails.UserEmail == key));
        }

        // PUT: odata/UserDetails(5)
        public IHttpActionResult Put([FromODataUri] string key, Delta<UserDetails> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserDetails userDetails = db.UserDetails.Find(key);
            if (userDetails == null)
            {
                return NotFound();
            }

            patch.Put(userDetails);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDetailsExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(userDetails);
        }

        // POST: odata/UserDetails
        public IHttpActionResult Post(UserDetails userDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserDetails.Add(userDetails);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UserDetailsExists(userDetails.UserEmail))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(userDetails);
        }

        // PATCH: odata/UserDetails(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] string key, Delta<UserDetails> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserDetails userDetails = db.UserDetails.Find(key);
            if (userDetails == null)
            {
                return NotFound();
            }

            patch.Patch(userDetails);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDetailsExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(userDetails);
        }

        // DELETE: odata/UserDetails(5)
        public IHttpActionResult Delete([FromODataUri] string key)
        {
            UserDetails userDetails = db.UserDetails.Find(key);
            if (userDetails == null)
            {
                return NotFound();
            }

            db.UserDetails.Remove(userDetails);
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

        private bool UserDetailsExists(string key)
        {
            return db.UserDetails.Count(e => e.UserEmail == key) > 0;
        }
    }
}
