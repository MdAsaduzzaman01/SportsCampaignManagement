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
    builder.EntitySet<PlayerFinalBatting>("PlayerFinalBattings");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    //[EnableCors(origins: "http://localhost:37773", headers: "*", methods: "*")]
    public class PlayerFinalBattingsController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/PlayerFinalBattings
        [EnableQuery]
        public IQueryable<PlayerFinalBatting> GetPlayerFinalBattings()
        {
            var query = (from p in db.Players
                        join fba in db.FinalBattingScores on p.PlayerId equals fba.PlayerId
                        join c in db.Campaigns on p.CampaignId equals c.CampaignId
                        orderby fba.FinalScore 
                        select new PlayerFinalBatting
                        {
                            PlayerId=p.PlayerId,
                            PlayerName=p.PlayerName,
                            FatherName=p.FatherName,
                            MotherName=p.MotherName,
                            PlayerType=p.PlayerType,
                            CampaignVenue=c.CampaignVenue,
                            CampaignDate=c.CampaignDate,
                            CampaignLevel=c.CampaignLevel,
                            Ball1Total=fba.Ball1Total,
                            Ball2Total=fba.Ball2Total,
                            Ball3Total=fba.Ball3Total,
                            Ball4Total=fba.Ball4Total,
                            Ball5Total=fba.Ball5Total,
                            Ball6Total=fba.Ball6Total,
                            FinalScore=fba.FinalScore,
                            CampaignId=c.CampaignId
                        }).Take(5);
            return query;
        }

        // GET: odata/PlayerFinalBattings(5)
        [EnableQuery]
        public SingleResult<PlayerFinalBatting> GetPlayerFinalBatting([FromODataUri] int key)
        {
            var query = from p in db.Players
                        join fba in db.FinalBattingScores on p.PlayerId equals fba.PlayerId
                        join c in db.Campaigns on p.CampaignId equals c.CampaignId
                        where fba.FinalBattingScoreId == key
                        select new PlayerFinalBatting
                        {
                            PlayerId = p.PlayerId,
                            PlayerName = p.PlayerName,
                            FatherName = p.FatherName,
                            MotherName = p.MotherName,
                            PlayerType = p.PlayerType,
                            CampaignVenue = c.CampaignVenue,
                            CampaignDate = c.CampaignDate,
                            CampaignLevel = c.CampaignLevel,
                            Ball1Total = fba.Ball1Total,
                            Ball2Total = fba.Ball2Total,
                            Ball3Total = fba.Ball3Total,
                            Ball4Total = fba.Ball4Total,
                            Ball5Total = fba.Ball5Total,
                            Ball6Total = fba.Ball6Total,
                            FinalBattingScoreId = fba.FinalBattingScoreId,
                            FinalScore = fba.FinalScore
                        };
            return SingleResult.Create(query);
        }

        // PUT: odata/PlayerFinalBattings(5)
        //public IHttpActionResult Put([FromODataUri] int key, Delta<PlayerFinalBatting> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    PlayerFinalBatting playerFinalBatting = db.PlayerFinalBattings.Find(key);
        //    if (playerFinalBatting == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Put(playerFinalBatting);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PlayerFinalBattingExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(playerFinalBatting);
        //}

        //// POST: odata/PlayerFinalBattings
        //public IHttpActionResult Post(PlayerFinalBatting playerFinalBatting)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.PlayerFinalBattings.Add(playerFinalBatting);
        //    db.SaveChanges();

        //    return Created(playerFinalBatting);
        //}

        //// PATCH: odata/PlayerFinalBattings(5)
        //[AcceptVerbs("PATCH", "MERGE")]
        //public IHttpActionResult Patch([FromODataUri] int key, Delta<PlayerFinalBatting> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    PlayerFinalBatting playerFinalBatting = db.PlayerFinalBattings.Find(key);
        //    if (playerFinalBatting == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Patch(playerFinalBatting);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PlayerFinalBattingExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(playerFinalBatting);
        //}

        //// DELETE: odata/PlayerFinalBattings(5)
        //public IHttpActionResult Delete([FromODataUri] int key)
        //{
        //    PlayerFinalBatting playerFinalBatting = db.PlayerFinalBattings.Find(key);
        //    if (playerFinalBatting == null)
        //    {
        //        return NotFound();
        //    }

        //    db.PlayerFinalBattings.Remove(playerFinalBatting);
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

        //private bool PlayerFinalBattingExists(int key)
        //{
        //    return db.PlayerFinalBattings.Count(e => e.PlayerId == key) > 0;
        //}
    }
}
