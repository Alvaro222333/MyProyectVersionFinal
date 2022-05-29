using System.Net;
using System.Net.Http;
using System.Web.Http;
using USIP.Model;

namespace USIP.Controller
{
	[AllowAnonymous]
	public class CourseController : BaseController
	{
		[HttpGet]
		public HttpResponseMessage GetAll()
		{
			var courses = Repository<Course>()
				.Select(course => true);

			return Request.CreateResponse(
				HttpStatusCode.OK,
				new
				{
					courses
				});
		}
		[Route("api/course/id")]
		[HttpPost]
		public HttpResponseMessage Get()
		{
			var value = Request.Content.ReadAsStringAsync().Result;
			int id = int.Parse(value);
			var data = Repository<Course>()
				.Select(w => w.Id == id);

			return Request.CreateResponse(
				HttpStatusCode.OK,
				new
				{
					data
				});
		}
		[HttpPost]
		public HttpResponseMessage Insert(Course course)
		{
			var response = Repository<Course>()
				.Insert(course);

			return response != null
				? Request.CreateResponse(HttpStatusCode.OK, response)
				: Request.CreateResponse(HttpStatusCode.BadRequest);
		}

		[HttpPut]
		public HttpResponseMessage Update(Course course)
		{
			var response = Repository<Course>()
				.Update(course);

			return response > 0
				? Request.CreateResponse(HttpStatusCode.OK)
				: Request.CreateResponse(HttpStatusCode.BadRequest);
		}

		[HttpDelete]
		public HttpResponseMessage Delete(int id)
		{
			var response = Repository<Course>()
				.Delete(course => course.Id.Equals(id));

			return response
				? Request.CreateResponse(HttpStatusCode.OK)
				: Request.CreateResponse(HttpStatusCode.BadRequest);
		}
	}
}
