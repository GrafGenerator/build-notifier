using System;
using System.ComponentModel;
using GrafGenerator.BuildNotificationTools.Interop;
using System.Runtime.CompilerServices;

namespace GrafGenerator.BuildNotificationTools.ControlApp.Model
{
	public class BuildInfo: INotifyPropertyChanged
	{
        private Guid _id;

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

        public BuildMessageKind MessageKind { get; }

		public string Message { get; }

		public long Timestamp { get; }

		private BuildInfo(Guid id, BuildMessageKind messageKind, string message, long timestamp)
		{
			Id = id;
            MessageKind = messageKind;
            Message = message;
            Timestamp = timestamp;
		}


        public static BuildInfo Create(Guid id, BuildMessageKind messageKind, string message, long timestamp)
        {
            return new BuildInfo(id, messageKind, message, timestamp);
        }

		public static BuildInfo Create(BuildMessage message)
		{
			return new BuildInfo(message.BuildId, message.MessageKind, message.Message, message.Timestamp);
		}

		public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
	        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
	}
}
