using System;
using System.Collections.Generic;
using GrafGenerator.BuildNotificationTools.ControlApp.Model;
using GrafGenerator.BuildNotificationTools.Interop;
using GrafGenerator.FunctionalExtensions;

namespace GrafGenerator.BuildNotificationTools.ControlApp.Design
{
	public class DesignBuildMessagesStorageService : IBuildMessagesStorageService
	{
		public IEnumerable<BuildMessage> GetMessages()
		{
			throw new NotImplementedException();
		}

		public Result AddMessage(BuildMessage message)
		{
			throw new NotImplementedException();
		}
	}
}