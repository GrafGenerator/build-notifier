using System;
using System.Messaging;
using System.Threading;
using GrafGenerator.BuildNotificationTools.Interop;

namespace SampleWatcher
{
    class Program
    {
        static void Main()
        {
            const string name = "build-notifications";
            var mq = new NotificationChannel(name).MessageQueue;
            ((XmlMessageFormatter)mq.Formatter).TargetTypes = new[] { typeof(BuildMessage) };

            Console.WriteLine("Purge queue...");
            mq.Purge();
            Console.WriteLine("Start listening build notifications...");
            while (true)
            {
                var messages = mq.GetAllMessages();
                mq.Purge();

                foreach (var msg in messages)
                {
                    if (msg != null)
                    {
                        var message = (BuildMessage) msg.Body;
	                    var time = message.OccurredOn;
	                    Console.WriteLine("[{0}]: [{1}] {2} (build '{3}')",
		                    $"{time.ToShortDateString()} {time.ToShortTimeString()}", message.MessageKind,
                            message.Message, message.BuildId);
                    }
                }
                Thread.Sleep(200);
            }
        }
    }
}
