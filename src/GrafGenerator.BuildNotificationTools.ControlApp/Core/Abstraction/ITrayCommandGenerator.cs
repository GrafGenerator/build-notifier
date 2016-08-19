namespace GrafGenerator.BuildNotificationTools.ControlApp.Core.Abstraction
{
    public interface ITrayCommandGenerator<TMessage>
    {
        ITrayCommand Create(TMessage message);
    }

    public interface ITrayCommand
    {

    }
}