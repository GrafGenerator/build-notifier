using GrafGenerator.BuildNotificationTools.ControlApp.Core.Abstraction;

namespace GrafGenerator.BuildNotificationTools.ControlApp.Core.TrayIcon
{
    public class MessagesReceivedArgs<TMessage>: IMessagesReceivedArgs<TMessage>
    {
        public MessagesReceivedArgs(TMessage[] messages)
        {
            Messages = messages;
        }

        public TMessage[] Messages { get; }
    }
}