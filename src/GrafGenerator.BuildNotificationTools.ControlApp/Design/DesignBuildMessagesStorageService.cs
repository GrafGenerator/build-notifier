using System;
using GrafGenerator.BuildNotificationTools.ControlApp.Model;
using GrafGenerator.BuildNotificationTools.Interop;

namespace GrafGenerator.BuildNotificationTools.ControlApp.Design
{
	public class DesignBuildMessagesStorageService : BuildMessagesStorageServiceBase
	{
		protected override void InitData()
		{
			var id = Guid.NewGuid();

			BuildMessages.Add(BuildInfo.Create(id, BuildMessageKind.Start, "Message 1", DateTime.Now.Ticks));
			BuildMessages.Add(BuildInfo.Create(id, BuildMessageKind.Init, "Message 2", DateTime.Now.Ticks));
			BuildMessages.Add(BuildInfo.Create(id, BuildMessageKind.Progress, "Message 3", DateTime.Now.Ticks));
			BuildMessages.Add(BuildInfo.Create(id, BuildMessageKind.Unknown, "Message 4", DateTime.Now.Ticks));
			BuildMessages.Add(BuildInfo.Create(id, BuildMessageKind.Warning, "Message 5", DateTime.Now.Ticks));
			BuildMessages.Add(BuildInfo.Create(id, BuildMessageKind.Error, "Message 6", DateTime.Now.Ticks));
			BuildMessages.Add(BuildInfo.Create(id, BuildMessageKind.Finish, "Message 7", DateTime.Now.Ticks));
		}
	}
}