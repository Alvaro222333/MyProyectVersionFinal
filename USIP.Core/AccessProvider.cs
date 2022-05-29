using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Claims;
using System.Threading.Tasks;
using USIP.Error.Bussiness;
using USIP.Model;

namespace USIP.Core
{
	//Owin
	public class AccessProvider : OAuthAuthorizationServerProvider
	{
		private readonly string clientId;

		public AccessProvider(string clientId)
		{
			this.clientId = clientId;
		}

		public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
		{
			var credentials = new Credentials
			{
				User = context.UserName,
				Password = context.Password
			};
			var isAValidUser = IsAValidUser(credentials);
			if (!isAValidUser)
			{
				throw new NotValidCredentialsException(context.UserName);
			}

			var identity = new ClaimsIdentity(context.Options.AuthenticationType);
			identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
			var properties = new Dictionary<string, string>
			{
				{ "username", context.UserName},
				// Other User Custom Settings
			};

			var ticket = new AuthenticationTicket(identity, new AuthenticationProperties(properties));
			context.Validated(ticket);

			return base.GrantResourceOwnerCredentials(context);
		}

		public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
		{
			if (context.ClientId == null)
			{
				context.Validated();
			}
			return Task.FromResult<object>(null);
		}

		public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
		{
			return context.ClientId != clientId
				? Task.FromResult<object>(null)
				: base.ValidateClientRedirectUri(context);
		}

		public override Task TokenEndpoint(OAuthTokenEndpointContext context)
		{
			foreach (var property in context.Properties.Dictionary)
			{
				context.AdditionalResponseParameters.Add(property.Key, property.Value);
			}
			return Task.FromResult<object>(null);
		}

		private bool IsAValidUser(Credentials credentials)
		{
			return credentials.User == "sa" && credentials.Password == "sa";
		}
	}
}
