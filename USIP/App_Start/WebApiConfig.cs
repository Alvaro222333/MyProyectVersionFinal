using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace USIP.App_Start
{
	public class WebApiConfig
	{
		public static void Register(HttpConfiguration configuration)
		{
			configuration.MapHttpAttributeRoutes();
			configuration.Formatters.JsonFormatter.SerializerSettings
				.ContractResolver = new CamelCasePropertyNamesContractResolver();
		}
	}
}