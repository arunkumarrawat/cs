using System;

namespace Assemblies.Ftp.FtpCommands
{
	/// <summary>
	/// Base class for present current directory commands
	/// </summary>
	class PwdCommandHandlerBase : FtpCommandHandler
	{
		public PwdCommandHandlerBase(string sCommand, FtpConnectionObject connectionObject)
			: base(sCommand, connectionObject)
		{
			
		}

		protected override string OnProcess(string sMessage)
		{
            System.Diagnostics.Debugger.Launch();
			string sDirectory = ConnectionObject.CurrentDirectory;
			sDirectory = sDirectory.Replace('\\', '/');
			return GetMessage(257, string.Format("\"{0}\" PWD Successful.", sDirectory));
		}
	}
}
