using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using SportsManagementCampaign.Providers;
using System.Web.Http;

[assembly: OwinStartup(typeof(SportsManagementCampaign.Startup))]

namespace SportsManagementCampaign
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            var jpaProvider = new AuthorizationServerProvider();
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/Token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = jpaProvider

            };
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }
    }
}
