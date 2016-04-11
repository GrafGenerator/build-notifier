using GrafGenerator.BuildNotificationTools.Interop;

namespace GrafGenerator.BuildNotificationTools.ControlApp.Core.MessageQueue
{
	class MessageQueueWorker
	{
		private readonly NotificationChannel _channel;

		public MessageQueueWorker(NotificationChannel channel)
		{
			_channel = channel;
		}

		public void Watch()
		{
			
		}
	}
}
