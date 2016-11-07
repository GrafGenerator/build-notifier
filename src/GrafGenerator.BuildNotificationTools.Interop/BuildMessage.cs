using System;

namespace GrafGenerator.BuildNotificationTools.Interop
{
    [Serializable]
    public class BuildMessage
    {
        public Guid BuildId { get; set; }
        public BuildMessageKind MessageKind { get; set; }
        public string Message { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}