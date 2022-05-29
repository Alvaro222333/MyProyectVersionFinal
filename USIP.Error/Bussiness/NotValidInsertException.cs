namespace USIP.Error.Bussiness
{
	public class NotValidInsertException : BussinessException
	{
		public NotValidInsertException(Severity severity = Severity.Warning) 
			: base("Este usuario no te permito insertar Estudiantes", severity)
		{
		}
	}
}
