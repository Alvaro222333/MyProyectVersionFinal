using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(USIP.Startup))]
namespace USIP
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
		}
	}
}