using System;
using System.Collections.Generic;
using GrafGenerator.BuildNotificationTools.Interop;
using GrafGenerator.FunctionalExtensions;

namespace GrafGenerator.BuildNotificationTools.ControlApp.Model
{
	public class BuildMessagesStorageService : IBuildMessagesStorageService
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