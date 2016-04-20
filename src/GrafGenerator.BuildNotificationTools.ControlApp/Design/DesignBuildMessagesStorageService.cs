using System;
using System.Collections.Generic;
using GrafGenerator.BuildNotificationTools.ControlApp.Model;
using GrafGenerator.BuildNotificationTools.Interop;
using GrafGenerator.FunctionalExtensions;

namespace GrafGenerator.BuildNotificationTools.ControlApp.Design
{
	public class DesignBuildMessagesStorageService : IBuildMessagesStorageService
	{
        public Result<IEnumerable<BuildInfo>> GetMessages()
        {
            var id = Guid.NewGuid();
            var buildMessages = (IEnumerable<BuildInfo>)new List<BuildInfo>
            {
                BuildInfo.Create(id, BuildMessageKind.Start, "Message 1", DateTime.Now.Ticks),
                BuildInfo.Create(id, BuildMessageKind.Init, "Message 2", DateTime.Now.Ticks),
                BuildInfo.Create(id, BuildMessageKind.Progress, "Message 3", DateTime.Now.Ticks),
                BuildInfo.Create(id, BuildMessageKind.Unknown, "Message 4", DateTime.Now.Ticks),
                BuildInfo.Create(id, BuildMessageKind.Warning, "Message 5", DateTime.Now.Ticks),
                BuildInfo.Create(id, BuildMessageKind.Error, "Message 6", DateTime.Now.Ticks),
                BuildInfo.Create(id, BuildMessageKind.Finish, "Message 7", DateTime.Now.Ticks),
            };
            return Result.Ok(buildMessages);
        }

        public Result AddMessage(BuildInfo message)
        {
            throw new NotImplementedException();
        }
    }
}