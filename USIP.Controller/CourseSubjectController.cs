using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using USIP.Data.Context;
using USIP.Model;

namespace USIP.Controller
{
	[AllowAnonymous]
	public class CourseSubjectController : BaseController
	{
		[HttpGet]
		public HttpResponseMessage GetAll()
		{
			var courseSubjects = Repository<CourseSubject>().Select(t=>true);
			
			var s = Request.CreateResponse(
				HttpStatusCode.OK,
				new
				{
					courseSubjects
				});
			return s;
		}

		[HttpPost]
		public HttpResponseMessage Insert(CourseSubject courseSubject)
		{
			var response = Repository<CourseSubject>()
				.Insert(courseSubject);

			return response != null
				? Request.CreateResponse(HttpStatusCode.OK, response)
				: Request.CreateResponse(HttpStatusCode.BadRequest);
		}

		[HttpPut]
		public HttpResponseMessage Update(Subject subject)
		{
			var response = Repository<Subject>()
				.Update(subject);

			return response > 0
				? Request.CreateResponse(HttpStatusCode.OK)
				: Request.CreateResponse(HttpStatusCode.BadRequest);
		}

		[HttpDelete]
		public HttpResponseMessage Delete(int id)
		{
			var response = Repository<CourseSubject>()
				.Delete(subject => subject.Id.Equals(id));

			return response
				? Request.CreateResponse(HttpStatusCode.OK)
				: Request.CreateResponse(HttpStatusCode.BadRequest);
		}
	}
}
