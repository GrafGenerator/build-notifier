using System;
using System.Runtime.Serialization;

namespace GrafGenerator.BuildNotificationTools.Interop
{
    [Serializable]
    public class BuildMessage: ISerializable
    {
	    private readonly Guid _buildId;
	    private readonly BuildMessageKind _messageKind;
	    private readonly string _message;

	    public Guid BuildId => _buildId;
	    public BuildMessageKind MessageKind => _messageKind;
	    public string Message => _message;

	    public BuildMessage()
	    {
		    
	    }

        private BuildMessage(Guid buildId, BuildMessageKind messageKind, string message)
        {
            _buildId = buildId;
            _messageKind = messageKind;
            _message = message;
        }

	    protected BuildMessage(SerializationInfo info, StreamingContext context)
	    {
		    _buildId = (Guid) info.GetValue("id", typeof (Guid));
		    _messageKind = (BuildMessageKind) info.GetValue("kind", typeof (BuildMessageKind));
		    _message = info.GetString("message");
	    }


		public static BuildMessage Create(Guid buildId, BuildMessageKind messageKind, string message)
        {
            return new BuildMessage(buildId, messageKind, message);
        }

	    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	    {
		    info.AddValue("id", _buildId);
			info.AddValue("kind", _messageKind);
			info.AddValue("message", _message);
	    }
    }
}
