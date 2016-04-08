using System;
using System.Messaging;
using System.Threading;

namespace GrafGenerator.BuildNotificationTools.Interop
{
    public class NotificationChannel
    {
        private const int RetryCount = 5;
        private const int RetryDelay = 1000;

        private readonly bool _internalFailure;

        private readonly MessageQueue _mq;
        internal MessageQueue MessageQueue
        {
            get
            {
                EnsureIntialized();
                return _mq;
            }
        }

        public string ChannelName { get; private set; }



        public NotificationChannel(string channelName)
        {
            ChannelName = channelName;

            var path = @".\Private$\" + channelName;

            for (var i = 0; i < RetryCount; i++)
            {
                try
                {
                    _mq = MessageQueue.Exists(path) ? new MessageQueue(path) : MessageQueue.Create(path);
                }
                catch
                {
                    _mq = null;
                    Thread.Sleep(RetryDelay);
                }
            }

            if (_mq == null)
            {
                _internalFailure = true;
            }
        }

        private void EnsureIntialized()
        {
            if(_internalFailure)
                throw new InvalidOperationException("Message queue initialization failed");
        }
    }
}
