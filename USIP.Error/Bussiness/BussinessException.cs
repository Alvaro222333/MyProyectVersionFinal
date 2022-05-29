namespace USIP.Error.Bussiness
{
	public class BussinessException : AbstractException
	{
		public BussinessException(string message, Severity severity = Severity.Warning)
			: base(severity, message)
		{ }

		public override void TrackException()
		{
			LogMessage(FriendlyMessage);
		}
	}
}
