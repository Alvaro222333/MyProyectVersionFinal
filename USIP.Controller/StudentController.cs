using System.Net;
using System.Net.Http;
using System.Web.Http;
using USIP.Model;

namespace USIP.Controller
{
	[AllowAnonymous]
	public class StudentController : BaseController
	{
		[HttpGet]
		public HttpResponseMessage GetAll()
		{
			// SELECT * FROM Estudiantes
			var students = Repository<Student>()
				.Select(student => true);

			return Request.CreateResponse(
				HttpStatusCode.OK,
				new
				{
					students
				});
		}
		[Route("api/student/id")]
		[HttpPost]
		public HttpResponseMessage IdFind()
		{
			var value = Request.Content.ReadAsStringAsync().Result;
			int id = int.Parse(value);
			var data = Repository<Student>()
				.Select(student => student.Id == id);

			return Request.CreateResponse(
				HttpStatusCode.OK,
				new
				{
					data
				});
		}

		[HttpPost]
		public HttpResponseMessage Insert(Student student)
		{
			var response = Repository<Student>()
				.Insert(student);

			return response != null
				? Request.CreateResponse(HttpStatusCode.OK, response)
				: Request.CreateResponse(HttpStatusCode.BadRequest);
		}

		[HttpPut]
		public HttpResponseMessage Update(Student student)
		{
			var response = Repository<Student>()
				.Update(student);

			return response > 0
				? Request.CreateResponse(HttpStatusCode.OK)
				: Request.CreateResponse(HttpStatusCode.BadRequest);
		}

		[HttpDelete]
		public HttpResponseMessage Delete(int id)
		{
			var response = Repository<Student>()
				.Delete(student => student.Id.Equals(id));

			return response
				? Request.CreateResponse(HttpStatusCode.OK)
				: Request.CreateResponse(HttpStatusCode.BadRequest);
		}
	}
}
