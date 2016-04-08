using System;

namespace GrafGenerator.BuildNotificationTools.Interop
{
    public class BuildMessage
    {
        public Guid BuildId { get; private set; }
        public BuildMessageKind MessageKind { get; private set; }
        public string Message { get; private set; }

        private BuildMessage(Guid buildId, BuildMessageKind messageKind, string message)
        {
            BuildId = buildId;
            MessageKind = messageKind;
            Message = message;
        }


        public static BuildMessage Create(Guid buildId, BuildMessageKind messageKind, string message)
        {
            return new BuildMessage(buildId, messageKind, message);
        }
    }
}
