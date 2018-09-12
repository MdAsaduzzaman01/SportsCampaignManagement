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
    builder.EntitySet<FinalBattingScore>("FinalBattingScores");
    builder.EntitySet<Player>("Players"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    //[EnableCors(origins: "http://localhost:37773", headers: "*", methods: "*")]
    public class FinalBattingScoresController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/FinalBattingScores
        [EnableQuery]
        public IQueryable<FinalBattingScore> GetFinalBattingScores()
        {
            return db.FinalBattingScores;
        }

        // GET: odata/FinalBattingScores(5)
        [EnableQuery]
        public SingleResult<FinalBattingScore> GetFinalBattingScore([FromODataUri] int key)
        {
            return SingleResult.Create(db.FinalBattingScores.Where(finalBattingScore => finalBattingScore.FinalBattingScoreId == key));
        }

        // PUT: odata/FinalBattingScores(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<FinalBattingScore> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FinalBattingScore finalBattingScore = db.FinalBattingScores.Find(key);
            if (finalBattingScore == null)
            {
                return NotFound();
            }

            patch.Put(finalBattingScore);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinalBattingScoreExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(finalBattingScore);
        }

        // POST: odata/FinalBattingScores
        public IHttpActionResult Post(FinalBattingScore finalBattingScore)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FinalBattingScores.Add(finalBattingScore);
            db.SaveChanges();

            return Created(finalBattingScore);
        }

        // PATCH: odata/FinalBattingScores(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<FinalBattingScore> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FinalBattingScore finalBattingScore = db.FinalBattingScores.Find(key);
            if (finalBattingScore == null)
            {
                return NotFound();
            }

            patch.Patch(finalBattingScore);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinalBattingScoreExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(finalBattingScore);
        }

        // DELETE: odata/FinalBattingScores(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            FinalBattingScore finalBattingScore = db.FinalBattingScores.Find(key);
            if (finalBattingScore == null)
            {
                return NotFound();
            }

            db.FinalBattingScores.Remove(finalBattingScore);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/FinalBattingScores(5)/Player
        [EnableQuery]
        public SingleResult<Player> GetPlayer([FromODataUri] int key)
        {
            return SingleResult.Create(db.FinalBattingScores.Where(m => m.FinalBattingScoreId == key).Select(m => m.Player));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FinalBattingScoreExists(int key)
        {
            return db.FinalBattingScores.Count(e => e.FinalBattingScoreId == key) > 0;
        }
    }
}
