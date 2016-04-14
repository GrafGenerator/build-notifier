using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace GrafGenerator.BuildNotificationTools.Interop
{
    [Serializable]
    public class BuildMessage: IXmlSerializable
    {
	    private Guid _buildId;
	    private BuildMessageKind _messageKind;
	    private string _message;
	    private long _timestamp;

	    public Guid BuildId => _buildId;
	    public BuildMessageKind MessageKind => _messageKind;
	    public string Message => _message;
	    public long Timestamp => _timestamp; 

	    public BuildMessage()
	    {
	    }


	    private BuildMessage(Guid buildId, BuildMessageKind messageKind, string message, long timestamp)
        {
            _buildId = buildId;
            _messageKind = messageKind;
            _message = message;
		    _timestamp = timestamp;
        }


		public static BuildMessage Create(Guid buildId, BuildMessageKind messageKind, string message, long timestamp)
        {
            return new BuildMessage(buildId, messageKind, message, timestamp);
        }

	    public XmlSchema GetSchema()
	    {
		    return null;
	    }

	    public void ReadXml(XmlReader reader)
	    {
		    reader.ReadToFollowing("id");
		    var buildIdStr = reader.ReadElementContentAsString();
		    var messageKindStr = reader.ReadElementContentAsString();
			var messageStr = reader.ReadElementContentAsString();
			var timestampStr = reader.ReadElementContentAsString();

			_buildId = Guid.Parse(buildIdStr);
		    _messageKind = (BuildMessageKind) Enum.Parse(typeof (BuildMessageKind), messageKindStr);
		    _message = messageStr;
		    _timestamp = long.Parse(timestampStr);
	    }

	    public void WriteXml(XmlWriter writer)
	    {
		    writer.WriteElementString("id",_buildId.ToString());
		    writer.WriteElementString("kind", Enum.GetName(typeof (BuildMessageKind), _messageKind));
		    writer.WriteElementString("message", _message);
		    writer.WriteElementString("timestamp", _timestamp.ToString());
	    }
    }
}
