using System.Net;
using System.Net.Http;
using System.Web.Http;
using USIP.Model;

namespace USIP.Controller
{
	[AllowAnonymous]
	public class StudyController : BaseController
	{
		[HttpGet]
		public HttpResponseMessage GetAll()
		{
			var studies = Repository<Study>()
				.Select(student => true);

			return Request.CreateResponse(
				HttpStatusCode.OK,
				new
				{
					studies
				});
		}
		
		
		[HttpPost]
		public HttpResponseMessage Insert(Study study)
		{
			var response = Repository<Study>()
				.Insert(study);

			return response != null
				? Request.CreateResponse(HttpStatusCode.OK, response)
				: Request.CreateResponse(HttpStatusCode.BadRequest);
		}


		[HttpDelete]
		public HttpResponseMessage Delete(int id)
		{
			var response = Repository<Study>()
				.Delete(student => student.Id.Equals(id));

			return response
				? Request.CreateResponse(HttpStatusCode.OK)
				: Request.CreateResponse(HttpStatusCode.BadRequest);
		}
	}
}
