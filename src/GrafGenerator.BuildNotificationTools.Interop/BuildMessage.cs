using System;

namespace GrafGenerator.BuildNotificationTools.Interop
{
    [Serializable]
    public class BuildMessage
    {
        public Guid BuildId { get; set; }
        public BuildMessageKind MessageKind { get; set; }
        public string Message { get; set; }

        public BuildMessage()
        {
            
        }

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
