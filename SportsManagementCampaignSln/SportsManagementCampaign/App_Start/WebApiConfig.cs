using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using SportsManagementCampaign.Models;
using SportsManagementCampaign.ViewModels;

namespace SportsManagementCampaign
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Employee>("Employees");
            builder.EntitySet<Campaign>("Campaigns");
            builder.EntitySet<Player>("Players");
            builder.EntitySet<BattingScoreCard>("BattingScoreCards");
            builder.EntitySet<BowlingScoreCard>("BowlingScoreCards");
            builder.EntitySet<FinalBattingScore>("FinalBattingScores");
            builder.EntitySet<FinalBowlingScore>("FinalBowlingScores");
            builder.EntitySet<Sponsor>("Sponsors");
            builder.EntitySet<PlayerFinalBatting>("PlayerFinalBattings");
            builder.EntitySet<PlayerFinalBowling>("PlayerFinalBowlings");
            builder.EntitySet<PlayerFinalAlrounder>("PlayerFinalAlrounders");
            builder.EntitySet<Subscribe>("Subscribes");
            builder.EntitySet<Contact>("Contacts");
            builder.EntitySet<UserDetails>("UserDetails");
            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
