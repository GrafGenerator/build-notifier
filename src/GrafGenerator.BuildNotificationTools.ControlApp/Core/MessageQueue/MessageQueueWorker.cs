using System;
using System.Linq;
using System.Threading;
using GrafGenerator.BuildNotificationTools.Interop;
using GrafGenerator.FunctionalExtensions;

namespace GrafGenerator.BuildNotificationTools.ControlApp.Core.MessageQueue
{
	public class MessageQueueWorker
	{
		private readonly NotificationChannel _channel;
		private readonly int _requestInterval;

		public event EventHandler<MessagesReceivedArgs> MessagesReceived;

		public MessageQueueWorker(NotificationChannel channel, int requestInterval = 200)
		{
			Contract.Requires<ArgumentNullException>(channel != null);
			Contract.Requires<ArgumentException>(requestInterval > 0);

			_channel = channel;
			_requestInterval = requestInterval;
		}

		public void Listen()
		{
			var thread = new Thread(ListenRoutine)
			{
				IsBackground = true,
				Name = "Message queue watcher thread"
			};

			thread.Start();
		}

		private void ListenRoutine()
		{
			try
			{
				var mq = _channel.MessageQueue;
				mq.Purge();

				while(true)
				{
					var rawMessages = mq.GetAllMessages();
					mq.Purge();

					var messages = rawMessages.Where(m => m != null).Select(m => (BuildMessage)m.Body).ToArray();
					OnMessagesReceived(MessagesReceivedArgs.Create(messages));

					Thread.Sleep(_requestInterval);
				}
			}
			catch (Exception e)
			{
				if (e is ThreadAbortException) return;
				throw;
			}
		}

		protected virtual void OnMessagesReceived(MessagesReceivedArgs e)
		{
			MessagesReceived?.Invoke(this, e);
		}
	}
}
