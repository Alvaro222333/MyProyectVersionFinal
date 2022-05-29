using log4net;
using log4net.Config;

namespace USIP.Error
{
	public class Logger
	{
		private readonly ILog logger;
		private static Logger instance;

		public static Logger Instance => instance ?? (instance = new Logger());

		private Logger()
		{
			logger = LogManager.GetLogger("Logger");
			XmlConfigurator.Configure();
		}

		public void LogMessage(Severity severity, string message)
		{
			switch (severity)
			{
				case Severity.Debug: logger.Debug(message); break;
				case Severity.Warning: logger.Warn(message); break;
				case Severity.Information: logger.Info(message); break;
				case Severity.Error: logger.Error(message); break;
				case Severity.Fatal: logger.Fatal(message); break;
			}
		}
	}
}
