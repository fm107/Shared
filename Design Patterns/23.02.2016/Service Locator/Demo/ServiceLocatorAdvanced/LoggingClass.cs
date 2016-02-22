using System.IO;

namespace ServiceLocatorAdvanced
{
	class LoggingClass : ILog
	{
		public void Log(string txt)
		{
			InternalLog(txt);
		}
		public void LogFormat(string txt, params object[] p)
		{
			string msg = string.Format(txt, p);
			InternalLog(msg);
		}

		private StreamWriter logFile;
		private void InternalLog( string txt)
		{
			if (logFile == null)
			{
				logFile = new StreamWriter("actions.log");
			}
			logFile.WriteLine(txt);
			logFile.Flush();
		}
	}
}
