using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using USIP.Core;

namespace USIP
{
	public partial class Startup
	{
		public static string ClientId { get; }
		public static OAuthAuthorizationServerOptions Authorization { get;  }

		static Startup()
		{
			ClientId = "USIP_APP";
			Authorization = new OAuthAuthorizationServerOptions
			{
				TokenEndpointPath = new PathString("/Token"),
				AuthorizeEndpointPath = new PathString("/api/Login"),
				Provider = new AccessProvider(ClientId),
				AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),
				AllowInsecureHttp = true
			};
		}

		public void ConfigureAuth(IAppBuilder app)
		{
			app.UseOAuthAuthorizationServer(Authorization);
		}
	}
}