using System;

namespace USIP.Error
{
	public abstract class AbstractException : Exception
	{
		public string FriendlyMessage { get; protected set; }
		public new Exception InnerException { get; protected set; }
		protected Severity Severity { get; }

		protected AbstractException(Severity severity, string friendlyMessage)
		{
			FriendlyMessage = friendlyMessage;
			Severity = severity;
		}

		protected AbstractException(Exception exception, Severity severity, string friendlyMessage)
			: this (severity, friendlyMessage)
		{
			InnerException = exception;
		}

		protected virtual void LogMessage(string message)
		{
			Logger.Instance.LogMessage(Severity, message);
		}

		public abstract void TrackException();
	}
}
