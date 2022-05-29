namespace USIP.Error.Bussiness
{
	public class NotValidCredentialsException : BussinessException
	{
		public NotValidCredentialsException(string user, Severity severity = Severity.Warning) 
			: base($"El usuario: {user} es invalido", severity)
		{ }
	}
}
