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
    builder.EntitySet<FinalBowlingScore>("FinalBowlingScores");
    builder.EntitySet<Player>("Players"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    //[EnableCors(origins: "http://localhost:37773", headers:"*",methods:"*")]
    public class FinalBowlingScoresController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/FinalBowlingScores
        [EnableQuery]
        public IQueryable<FinalBowlingScore> GetFinalBowlingScores()
        {
            return db.FinalBowlingScores;
        }

        // GET: odata/FinalBowlingScores(5)
        [EnableQuery]
        public SingleResult<FinalBowlingScore> GetFinalBowlingScore([FromODataUri] int key)
        {
            return SingleResult.Create(db.FinalBowlingScores.Where(finalBowlingScore => finalBowlingScore.FinalBowlingScoreId == key));
        }

        // PUT: odata/FinalBowlingScores(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<FinalBowlingScore> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FinalBowlingScore finalBowlingScore = db.FinalBowlingScores.Find(key);
            if (finalBowlingScore == null)
            {
                return NotFound();
            }

            patch.Put(finalBowlingScore);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinalBowlingScoreExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(finalBowlingScore);
        }

        // POST: odata/FinalBowlingScores
        public IHttpActionResult Post(FinalBowlingScore finalBowlingScore)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FinalBowlingScores.Add(finalBowlingScore);
            db.SaveChanges();

            return Created(finalBowlingScore);
        }

        // PATCH: odata/FinalBowlingScores(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<FinalBowlingScore> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FinalBowlingScore finalBowlingScore = db.FinalBowlingScores.Find(key);
            if (finalBowlingScore == null)
            {
                return NotFound();
            }

            patch.Patch(finalBowlingScore);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinalBowlingScoreExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(finalBowlingScore);
        }

        // DELETE: odata/FinalBowlingScores(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            FinalBowlingScore finalBowlingScore = db.FinalBowlingScores.Find(key);
            if (finalBowlingScore == null)
            {
                return NotFound();
            }

            db.FinalBowlingScores.Remove(finalBowlingScore);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/FinalBowlingScores(5)/Player
        [EnableQuery]
        public SingleResult<Player> GetPlayer([FromODataUri] int key)
        {
            return SingleResult.Create(db.FinalBowlingScores.Where(m => m.FinalBowlingScoreId == key).Select(m => m.Player));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FinalBowlingScoreExists(int key)
        {
            return db.FinalBowlingScores.Count(e => e.FinalBowlingScoreId == key) > 0;
        }
    }
}
