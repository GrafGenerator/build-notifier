using System;
using System.ComponentModel;
using GrafGenerator.BuildNotificationTools.Interop;
using System.Runtime.CompilerServices;

namespace GrafGenerator.BuildNotificationTools.ControlApp.Model
{
	public class BuildInfo: INotifyPropertyChanged
	{
        private Guid _id;
        private BuildMessageKind _messageKind;
        private string _message;
        private long _timestamp;

        public Guid Id
        {
            get { return _id; }
            set
            {
                if (!_id.Equals(value))
                {
                    _id = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public BuildMessageKind MessageKind => _messageKind;
        public string Message => _message;
        public long Timestamp => _timestamp;

        private BuildInfo(Guid id, BuildMessageKind messageKind, string message, long timestamp)
		{
			Id = id;
            _messageKind = messageKind;
            _message = message;
            _timestamp = timestamp;
		}


        public static BuildInfo Create(Guid id, BuildMessageKind messageKind, string message, long timestamp)
        {
            return new BuildInfo(id, messageKind, message, timestamp);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
