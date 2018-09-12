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
using SportsManagementCampaign.ViewModels;
using System.Web.Http.Cors;

namespace SportsManagementCampaign.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using SportsManagementCampaign.ViewModels;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<PlayerFinalBowling>("PlayerFinalBowlings");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    //[EnableCors(origins: "http://localhost:37773", headers: "*", methods: "*")]
    public class PlayerFinalBowlingsController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/PlayerFinalBowlings
        [EnableQuery]
        public IQueryable<PlayerFinalBowling> GetPlayerFinalBowlings()
        {
            var query = (from p in db.Players
                         join fbw in db.FinalBowlingScores on p.PlayerId equals fbw.PlayerId
                         join c in db.Campaigns on p.CampaignId equals c.CampaignId
                         orderby fbw.FinalScore
                         select new PlayerFinalBowling
                         {
                             PlayerId = p.PlayerId,
                             PlayerName = p.PlayerName,
                             FatherName = p.FatherName,
                             MotherName = p.MotherName,
                             PlayerType = p.PlayerType,
                             CampaignVenue = c.CampaignVenue,
                             CampaignDate = c.CampaignDate,
                             CampaignLevel = c.CampaignLevel,
                             Ball1Total = fbw.Ball1Total,
                             Ball2Total = fbw.Ball2Total,
                             Ball3Total = fbw.Ball3Total,
                             Ball4Total = fbw.Ball4Total,
                             Ball5Total = fbw.Ball5Total,
                             Ball6Total = fbw.Ball6Total,
                             FinalScore = fbw.FinalScore,
                             CampaignId = c.CampaignId
                         }).Take(5);
            return query;
        }

        // GET: odata/PlayerFinalBowlings(5)
        [EnableQuery]
        public SingleResult<PlayerFinalBowling> GetPlayerFinalBowling([FromODataUri] int key)
        {
            var query = from p in db.Players
                        join fbw in db.FinalBowlingScores on p.PlayerId equals fbw.PlayerId
                        join c in db.Campaigns on p.CampaignId equals c.CampaignId
                        where fbw.FinalBowlingScoreId == key
                        select new PlayerFinalBowling
                        {
                            PlayerId = p.PlayerId,
                            PlayerName = p.PlayerName,
                            FatherName = p.FatherName,
                            MotherName = p.MotherName,
                            PlayerType = p.PlayerType,
                            CampaignVenue = c.CampaignVenue,
                            CampaignDate = c.CampaignDate,
                            CampaignLevel = c.CampaignLevel,
                            Ball1Total = fbw.Ball1Total,
                            Ball2Total = fbw.Ball2Total,
                            Ball3Total = fbw.Ball3Total,
                            Ball4Total = fbw.Ball4Total,
                            Ball5Total = fbw.Ball5Total,
                            Ball6Total = fbw.Ball6Total,
                            FinalBowlingScoreId = fbw.FinalBowlingScoreId,
                            FinalScore = fbw.FinalScore
                        };
            return SingleResult.Create(query);
        }

        // PUT: odata/PlayerFinalBowlings(5)
        //public IHttpActionResult Put([FromODataUri] int key, Delta<PlayerFinalBowling> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    PlayerFinalBowling playerFinalBowling = db.PlayerFinalBowlings.Find(key);
        //    if (playerFinalBowling == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Put(playerFinalBowling);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PlayerFinalBowlingExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(playerFinalBowling);
        //}

        //// POST: odata/PlayerFinalBowlings
        //public IHttpActionResult Post(PlayerFinalBowling playerFinalBowling)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.PlayerFinalBowlings.Add(playerFinalBowling);
        //    db.SaveChanges();

        //    return Created(playerFinalBowling);
        //}

        //// PATCH: odata/PlayerFinalBowlings(5)
        //[AcceptVerbs("PATCH", "MERGE")]
        //public IHttpActionResult Patch([FromODataUri] int key, Delta<PlayerFinalBowling> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    PlayerFinalBowling playerFinalBowling = db.PlayerFinalBowlings.Find(key);
        //    if (playerFinalBowling == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Patch(playerFinalBowling);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PlayerFinalBowlingExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(playerFinalBowling);
        //}

        //// DELETE: odata/PlayerFinalBowlings(5)
        //public IHttpActionResult Delete([FromODataUri] int key)
        //{
        //    PlayerFinalBowling playerFinalBowling = db.PlayerFinalBowlings.Find(key);
        //    if (playerFinalBowling == null)
        //    {
        //        return NotFound();
        //    }

        //    db.PlayerFinalBowlings.Remove(playerFinalBowling);
        //    db.SaveChanges();

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool PlayerFinalBowlingExists(int key)
        //{
        //    return db.PlayerFinalBowlings.Count(e => e.PlayerId == key) > 0;
        //}
    }
}
