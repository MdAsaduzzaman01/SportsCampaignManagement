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
    builder.EntitySet<Player>("Players");
    builder.EntitySet<BattingScoreCard>("BattingScoreCards"); 
    builder.EntitySet<BowlingScoreCard>("BowlingScoreCards"); 
    builder.EntitySet<Campaign>("Campaigns"); 
    builder.EntitySet<FinalBattingScore>("FinalBattingScores"); 
    builder.EntitySet<FinalBowlingScore>("FinalBowlingScores"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    //[EnableCors(origins: "http://localhost:37773", headers: "*", methods: "*")]
    public class PlayersController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/Players
        [EnableQuery]
        public IQueryable<Player> GetPlayers()
        {
            return db.Players;
        }

        // GET: odata/Players(5)
        [EnableQuery]
        public SingleResult<Player> GetPlayer([FromODataUri] int key)
        {
            return SingleResult.Create(db.Players.Where(player => player.PlayerId == key));
        }

        // PUT: odata/Players(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Player> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Player player = db.Players.Find(key);
            if (player == null)
            {
                return NotFound();
            }

            patch.Put(player);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(player);
        }

        // POST: odata/Players
        public IHttpActionResult Post(Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Players.Add(player);
            db.SaveChanges();

            return Created(player);
        }

        // PATCH: odata/Players(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Player> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Player player = db.Players.Find(key);
            if (player == null)
            {
                return NotFound();
            }

            patch.Patch(player);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(player);
        }

        // DELETE: odata/Players(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Player player = db.Players.Find(key);
            if (player == null)
            {
                return NotFound();
            }

            db.Players.Remove(player);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Players(5)/BattingScoreCards
        [EnableQuery]
        public IQueryable<BattingScoreCard> GetBattingScoreCards([FromODataUri] int key)
        {
            return db.Players.Where(m => m.PlayerId == key).SelectMany(m => m.BattingScoreCards);
        }

        // GET: odata/Players(5)/BowlingScoreCards
        [EnableQuery]
        public IQueryable<BowlingScoreCard> GetBowlingScoreCards([FromODataUri] int key)
        {
            return db.Players.Where(m => m.PlayerId == key).SelectMany(m => m.BowlingScoreCards);
        }

        // GET: odata/Players(5)/Campaign
        [EnableQuery]
        public SingleResult<Campaign> GetCampaign([FromODataUri] int key)
        {
            return SingleResult.Create(db.Players.Where(m => m.PlayerId == key).Select(m => m.Campaign));
        }

        // GET: odata/Players(5)/FinalBattingScores
        [EnableQuery]
        public IQueryable<FinalBattingScore> GetFinalBattingScores([FromODataUri] int key)
        {
            return db.Players.Where(m => m.PlayerId == key).SelectMany(m => m.FinalBattingScores);
        }

        // GET: odata/Players(5)/FinalBowlingScores
        [EnableQuery]
        public IQueryable<FinalBowlingScore> GetFinalBowlingScores([FromODataUri] int key)
        {
            return db.Players.Where(m => m.PlayerId == key).SelectMany(m => m.FinalBowlingScores);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlayerExists(int key)
        {
            return db.Players.Count(e => e.PlayerId == key) > 0;
        }
    }
}
