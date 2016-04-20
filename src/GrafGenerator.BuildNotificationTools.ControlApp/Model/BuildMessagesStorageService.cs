using System;
using System.Collections.Generic;
using GrafGenerator.BuildNotificationTools.Interop;
using GrafGenerator.FunctionalExtensions;

namespace GrafGenerator.BuildNotificationTools.ControlApp.Model
{
	public class BuildMessagesStorageService : IBuildMessagesStorageService
	{
        public BuildInfoCollection BuildMessages { get; private set; }

        public BuildMessagesStorageService()
        {
            var id = Guid.NewGuid();

            BuildMessages = new BuildInfoCollection();

            BuildMessages.Add(BuildInfo.Create(id, BuildMessageKind.Start, "Message 1", DateTime.Now.Ticks));
            BuildMessages.Add(BuildInfo.Create(id, BuildMessageKind.Init, "Message 2", DateTime.Now.Ticks));
            BuildMessages.Add(BuildInfo.Create(id, BuildMessageKind.Progress, "Message 3", DateTime.Now.Ticks));
            BuildMessages.Add(BuildInfo.Create(id, BuildMessageKind.Unknown, "Message 4", DateTime.Now.Ticks));
            BuildMessages.Add(BuildInfo.Create(id, BuildMessageKind.Warning, "Message 5", DateTime.Now.Ticks));
            BuildMessages.Add(BuildInfo.Create(id, BuildMessageKind.Error, "Message 6", DateTime.Now.Ticks));
            BuildMessages.Add(BuildInfo.Create(id, BuildMessageKind.Finish, "Message 7", DateTime.Now.Ticks));
        }

        public Result AddMessage(BuildInfo message)
        {
            BuildMessages.Add(message);
            return Result.Ok();
        }
    }
}