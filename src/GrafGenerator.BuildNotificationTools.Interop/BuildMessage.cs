using System;
using System.Runtime.Serialization;
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


		public static BuildMessage Create(Guid buildId, BuildMessageKind messageKind, string message)
        {
            return new BuildMessage(buildId, messageKind, message);
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

			_buildId = Guid.Parse(buildIdStr);
		    _messageKind = (BuildMessageKind) Enum.Parse(typeof (BuildMessageKind), messageKindStr);
		    _message = messageStr;
	    }

	    public void WriteXml(XmlWriter writer)
	    {

		    writer.WriteElementString("id",_buildId.ToString());
		    writer.WriteElementString("kind", Enum.GetName(typeof (BuildMessageKind), _messageKind));
		    writer.WriteElementString("message", _message);
	    }
    }
}
