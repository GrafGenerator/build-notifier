using System.Collections.Generic;
using GrafGenerator.BuildNotificationTools.Interop;
using GrafGenerator.FunctionalExtensions;

namespace GrafGenerator.BuildNotificationTools.ControlApp.Model
{
	public interface IBuildMessagesStorageService
	{
		IEnumerable<BuildMessage> GetMessages();
		Result AddMessage(BuildMessage message);
	}
}
