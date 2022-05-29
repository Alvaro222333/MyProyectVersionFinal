using System;

namespace USIP.Error.Critical
{
	public class CriticalException : AbstractException
	{
		public CriticalException(Exception exception)
			: base(exception, Severity.Error, "El servidor fallo. por favor contacte con el administrador del sistema")
		{
			InnerException = exception;
		}

		public override void TrackException()
		{
			var current = InnerException;
			do
			{
				LogMessage($"Message: {current.Message}. Trace: {current.StackTrace}");
				current = current.InnerException;
			} while (current != null);
		}
	}
}
