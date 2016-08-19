namespace GrafGenerator.BuildNotificationTools.ControlApp.Core.Abstraction
{
    public interface IMessagesReceivedArgs<out TMessage>
    {
        TMessage[] Messages { get; }
    }
}