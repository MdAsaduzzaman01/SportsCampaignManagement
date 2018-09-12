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
    builder.EntitySet<PlayerFinalAlrounder>("PlayerFinalAlrounders");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
   // [EnableCors(origins: "http://localhost:37773", headers: "*", methods: "*")]
    public class PlayerFinalAlroundersController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/PlayerFinalAlrounders
        [EnableQuery]
        public IQueryable<PlayerFinalAlrounder> GetPlayerFinalAlrounders()
        {
            var query = (from p in db.Players
                         join fba in db.FinalBattingScores on p.PlayerId equals fba.PlayerId
                         join c in db.Campaigns on p.CampaignId equals c.CampaignId
                         join fbw in db.FinalBowlingScores on p.PlayerId equals fbw.PlayerId
                         orderby (fba.FinalScore + fbw.FinalScore)
                         select new PlayerFinalAlrounder
                         {
                             PlayerId = p.PlayerId,
                             PlayerName = p.PlayerName,
                             FatherName = p.FatherName,
                             MotherName = p.MotherName,
                             PlayerType = p.PlayerType,
                             CampaignVenue = c.CampaignVenue,
                             CampaignDate = c.CampaignDate,
                             CampaignLevel = c.CampaignLevel,
                             BattingFinalScore=fba.FinalScore,
                             BowlingFinalScore=fbw.FinalScore,
                             TotalScore = fba.FinalScore + fbw.FinalScore,
                             CampaignId = c.CampaignId
                         }).Take(5);
            return query;
        }

        // GET: odata/PlayerFinalAlrounders(5)
        [EnableQuery]
        public SingleResult<PlayerFinalAlrounder> GetPlayerFinalAlrounder([FromODataUri] int key)
        {
            var query = from p in db.Players
                        join fba in db.FinalBattingScores on p.PlayerId equals fba.PlayerId
                        join c in db.Campaigns on p.CampaignId equals c.CampaignId
                        join fbw in db.FinalBowlingScores on p.PlayerId equals fbw.PlayerId
                        where p.PlayerId == key
                        select new PlayerFinalAlrounder
                        {
                            PlayerId = p.PlayerId,
                            PlayerName = p.PlayerName,
                            FatherName = p.FatherName,
                            MotherName = p.MotherName,
                            PlayerType = p.PlayerType,
                            CampaignVenue = c.CampaignVenue,
                            CampaignDate = c.CampaignDate,
                            CampaignLevel = c.CampaignLevel,
                            BattingFinalScore = fba.FinalScore,
                            BowlingFinalScore = fbw.FinalScore,
                            TotalScore = fba.FinalScore + fbw.FinalScore,
                            CampaignId = c.CampaignId
                        };
            return SingleResult.Create(query);
        }

        // PUT: odata/PlayerFinalAlrounders(5)
        //public IHttpActionResult Put([FromODataUri] int key, Delta<PlayerFinalAlrounder> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    PlayerFinalAlrounder playerFinalAlrounder = db.PlayerFinalAlrounders.Find(key);
        //    if (playerFinalAlrounder == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Put(playerFinalAlrounder);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PlayerFinalAlrounderExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(playerFinalAlrounder);
        //}

        //// POST: odata/PlayerFinalAlrounders
        //public IHttpActionResult Post(PlayerFinalAlrounder playerFinalAlrounder)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.PlayerFinalAlrounders.Add(playerFinalAlrounder);
        //    db.SaveChanges();

        //    return Created(playerFinalAlrounder);
        //}

        //// PATCH: odata/PlayerFinalAlrounders(5)
        //[AcceptVerbs("PATCH", "MERGE")]
        //public IHttpActionResult Patch([FromODataUri] int key, Delta<PlayerFinalAlrounder> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    PlayerFinalAlrounder playerFinalAlrounder = db.PlayerFinalAlrounders.Find(key);
        //    if (playerFinalAlrounder == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Patch(playerFinalAlrounder);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PlayerFinalAlrounderExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(playerFinalAlrounder);
        //}

        //// DELETE: odata/PlayerFinalAlrounders(5)
        //public IHttpActionResult Delete([FromODataUri] int key)
        //{
        //    PlayerFinalAlrounder playerFinalAlrounder = db.PlayerFinalAlrounders.Find(key);
        //    if (playerFinalAlrounder == null)
        //    {
        //        return NotFound();
        //    }

        //    db.PlayerFinalAlrounders.Remove(playerFinalAlrounder);
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

        //private bool PlayerFinalAlrounderExists(int key)
        //{
        //    return db.PlayerFinalAlrounders.Count(e => e.PlayerId == key) > 0;
        //}
    }
}
