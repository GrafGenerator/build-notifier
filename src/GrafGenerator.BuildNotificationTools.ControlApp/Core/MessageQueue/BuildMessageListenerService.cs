﻿using GrafGenerator.BuildNotificationTools.ControlApp.Model;
using GrafGenerator.BuildNotificationTools.Interop;

namespace GrafGenerator.BuildNotificationTools.ControlApp.Core.MessageQueue
{
	public class BuildMessageListenerService
	{
		private readonly NotificationChannel _channel;
		private readonly IBuildMessagesStorageService _storage;

		public BuildMessageListenerService(NotificationChannel channel, IBuildMessagesStorageService storage)
		{
			_channel = channel;
			_storage = storage;
		}
	}
}
