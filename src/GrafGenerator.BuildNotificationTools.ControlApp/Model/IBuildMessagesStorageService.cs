using System.Collections.Generic;
using GrafGenerator.BuildNotificationTools.Interop;
using GrafGenerator.FunctionalExtensions;

namespace GrafGenerator.BuildNotificationTools.ControlApp.Model
{
	public interface IBuildMessagesStorageService
	{
		Result<IEnumerable<BuildInfo>> GetMessages();
		Result AddMessage(BuildInfo message);
	}
}
