using System.Threading;
using GrafGenerator.BuildNotificationTools.ControlApp.Model;
using GrafGenerator.BuildNotificationTools.Interop;

namespace GrafGenerator.BuildNotificationTools.ControlApp.Core.MessageQueue
{
	public class BuildMessageListenerService
	{
		private readonly NotificationChannel _channel;
		private readonly IBuildMessagesStorageService _storage;
		private SynchronizationContext _callerContext;

		public BuildMessageListenerService(NotificationChannel channel, IBuildMessagesStorageService storage)
		{
			_channel = channel;
			_storage = storage;
		}

		public void Listen()
		{
			// ensure we store caller thread context (expect it to be UI thread)
			_callerContext = SynchronizationContext.Current;

			var worker = new MessageQueueWorker(_channel);
			worker.MessagesReceived += MqWorderOnMessagesReceived;

			worker.Listen();
		}

		private void MqWorderOnMessagesReceived(object sender, MessagesReceivedArgs messagesReceivedArgs)
		{
			foreach (var message in messagesReceivedArgs.Messages)
			{
				_callerContext.Send(_ => _storage.AddMessage(BuildInfo.Create(message)), null);
			}
		}
	}
}
