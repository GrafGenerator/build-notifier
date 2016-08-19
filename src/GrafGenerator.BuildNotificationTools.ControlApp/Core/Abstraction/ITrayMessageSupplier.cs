using System;

namespace GrafGenerator.BuildNotificationTools.ControlApp.Core.Abstraction
{
    interface ITrayMessageSupplier<TMessage>
    {
        event EventHandler<IMessagesReceivedArgs<TMessage>> MessagesReceived;
    }
}
