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
    builder.EntitySet<BattingScoreCard>("BattingScoreCards");
    builder.EntitySet<Player>("Players"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    //[EnableCors(origins: "http://localhost:37773", headers: "*", methods: "*")]
    public class BattingScoreCardsController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/BattingScoreCards
        [EnableQuery]
        public IQueryable<BattingScoreCard> GetBattingScoreCards()
        {
            return db.BattingScoreCards;
        }

        // GET: odata/BattingScoreCards(5)
        [EnableQuery]
        public SingleResult<BattingScoreCard> GetBattingScoreCard([FromODataUri] int key)
        {
            return SingleResult.Create(db.BattingScoreCards.Where(battingScoreCard => battingScoreCard.BattingScoreCardId == key));
        }

        // PUT: odata/BattingScoreCards(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<BattingScoreCard> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BattingScoreCard battingScoreCard = db.BattingScoreCards.Find(key);
            if (battingScoreCard == null)
            {
                return NotFound();
            }

            patch.Put(battingScoreCard);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BattingScoreCardExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(battingScoreCard);
        }

        // POST: odata/BattingScoreCards
        public IHttpActionResult Post(BattingScoreCard battingScoreCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BattingScoreCards.Add(battingScoreCard);
            db.SaveChanges();

            return Created(battingScoreCard);
        }

        // PATCH: odata/BattingScoreCards(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<BattingScoreCard> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BattingScoreCard battingScoreCard = db.BattingScoreCards.Find(key);
            if (battingScoreCard == null)
            {
                return NotFound();
            }

            patch.Patch(battingScoreCard);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BattingScoreCardExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(battingScoreCard);
        }

        // DELETE: odata/BattingScoreCards(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            BattingScoreCard battingScoreCard = db.BattingScoreCards.Find(key);
            if (battingScoreCard == null)
            {
                return NotFound();
            }

            db.BattingScoreCards.Remove(battingScoreCard);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/BattingScoreCards(5)/Player
        [EnableQuery]
        public SingleResult<Player> GetPlayer([FromODataUri] int key)
        {
            return SingleResult.Create(db.BattingScoreCards.Where(m => m.BattingScoreCardId == key).Select(m => m.Player));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BattingScoreCardExists(int key)
        {
            return db.BattingScoreCards.Count(e => e.BattingScoreCardId == key) > 0;
        }
    }
}
