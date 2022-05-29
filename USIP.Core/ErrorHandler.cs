using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using USIP.Error;
using USIP.Error.Critical;

namespace USIP.Core
{
	public class ErrorHandler : ApiControllerActionInvoker
	{
		public override Task<HttpResponseMessage> InvokeActionAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
		{
			var response = base.InvokeActionAsync(actionContext, cancellationToken);
			if (response.Exception == null)
			{
				return response;
			}

			var temporal = response.Exception.GetBaseException();
			AbstractException baseException;
			if (temporal is AbstractException)
			{
				baseException = temporal as AbstractException;
			}
			else
			{
				baseException = new CriticalException(temporal);
			}

			baseException.TrackException();
			var content = JsonConvert.SerializeObject(new
			{
				type = baseException.GetType().Name,
				Message = baseException.FriendlyMessage
			});

			response = Task.Run(() => new HttpResponseMessage(HttpStatusCode.InternalServerError)
			{
				Content = new StringContent(content),
				ReasonPhrase = "An Exception Ocurred"
			}, cancellationToken);

			return response;
		}
	}
}
