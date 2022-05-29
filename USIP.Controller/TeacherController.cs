using System.Net;
using System.Net.Http;
using System.Web.Http;
using USIP.Model;

namespace USIP.Controller
{
	[AllowAnonymous]
	public class TeacherController : BaseController
	{
		[HttpGet]
		public HttpResponseMessage GetAll()
		{
			var teachers = Repository<Teacher>()
				.Select(teacher => true);

			return Request.CreateResponse(
				HttpStatusCode.OK,
				new
				{
					teachers
				});
		}

		[HttpPost]
		public HttpResponseMessage Insert(Teacher teacher)
		{
			var response = Repository<Teacher>()
				.Insert(teacher);

			return response != null
				? Request.CreateResponse(HttpStatusCode.OK, response)
				: Request.CreateResponse(HttpStatusCode.BadRequest);
		}

		[HttpPut]
		public HttpResponseMessage Update(Teacher teacher)
		{
			var response = Repository<Teacher>()
				.Update(teacher);

			return response > 0
				? Request.CreateResponse(HttpStatusCode.OK)
				: Request.CreateResponse(HttpStatusCode.BadRequest);
		}

		[HttpDelete]
		public HttpResponseMessage Delete(int id)
		{
			var response = Repository<Teacher>()
				.Delete(teacher => teacher.Id.Equals(id));

			return response
				? Request.CreateResponse(HttpStatusCode.OK)
				: Request.CreateResponse(HttpStatusCode.BadRequest);
		}
	}
}
