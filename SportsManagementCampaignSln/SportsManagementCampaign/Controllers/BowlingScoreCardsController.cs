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
    builder.EntitySet<BowlingScoreCard>("BowlingScoreCards");
    builder.EntitySet<Player>("Players"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    //[EnableCors(origins: "http://localhost:37773", headers: "*", methods: "*")]
    public class BowlingScoreCardsController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/BowlingScoreCards
        [EnableQuery]
        public IQueryable<BowlingScoreCard> GetBowlingScoreCards()
        {
            return db.BowlingScoreCards;
        }

        // GET: odata/BowlingScoreCards(5)
        [EnableQuery]
        public SingleResult<BowlingScoreCard> GetBowlingScoreCard([FromODataUri] int key)
        {
            return SingleResult.Create(db.BowlingScoreCards.Where(bowlingScoreCard => bowlingScoreCard.BowlingScoreCardId == key));
        }

        // PUT: odata/BowlingScoreCards(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<BowlingScoreCard> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BowlingScoreCard bowlingScoreCard = db.BowlingScoreCards.Find(key);
            if (bowlingScoreCard == null)
            {
                return NotFound();
            }

            patch.Put(bowlingScoreCard);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BowlingScoreCardExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(bowlingScoreCard);
        }

        // POST: odata/BowlingScoreCards
        public IHttpActionResult Post(BowlingScoreCard bowlingScoreCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BowlingScoreCards.Add(bowlingScoreCard);
            db.SaveChanges();

            return Created(bowlingScoreCard);
        }

        // PATCH: odata/BowlingScoreCards(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<BowlingScoreCard> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BowlingScoreCard bowlingScoreCard = db.BowlingScoreCards.Find(key);
            if (bowlingScoreCard == null)
            {
                return NotFound();
            }

            patch.Patch(bowlingScoreCard);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BowlingScoreCardExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(bowlingScoreCard);
        }

        // DELETE: odata/BowlingScoreCards(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            BowlingScoreCard bowlingScoreCard = db.BowlingScoreCards.Find(key);
            if (bowlingScoreCard == null)
            {
                return NotFound();
            }

            db.BowlingScoreCards.Remove(bowlingScoreCard);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/BowlingScoreCards(5)/Player
        [EnableQuery]
        public SingleResult<Player> GetPlayer([FromODataUri] int key)
        {
            return SingleResult.Create(db.BowlingScoreCards.Where(m => m.BowlingScoreCardId == key).Select(m => m.Player));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BowlingScoreCardExists(int key)
        {
            return db.BowlingScoreCards.Count(e => e.BowlingScoreCardId == key) > 0;
        }
    }
}
