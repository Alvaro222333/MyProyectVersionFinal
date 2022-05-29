using System.Web.Http;
using USIP.Data;
using USIP.Data.Context;

namespace USIP.Controller
{
	[Authorize]
	public class BaseController : ApiController
	{
		protected Repository<T> Repository<T>() where T : class, new()
		{
			return new Repository<T>(new BaseContext());
		}

		public BaseController()
		{ }
	}
}
