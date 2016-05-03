using System;
using GrafGenerator.BuildNotificationTools.Interop;

namespace GrafGenerator.BuildNotificationTools.ControlApp.Core.MessageQueue
{
	public class MessagesReceivedArgs: EventArgs
	{
		private MessagesReceivedArgs(BuildMessage[] messages)
		{
			Messages = messages;
		}

		public BuildMessage[] Messages { get; private set; }

		public static MessagesReceivedArgs Create(BuildMessage[] messages)
		{
			return new MessagesReceivedArgs(messages);
		}
	}
}
