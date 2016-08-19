namespace GrafGenerator.BuildNotificationTools.ControlApp.Core.Abstraction
{
    public interface ITrayCommandGenerator<in TMessage>
    {
        ITrayCommand Create(TMessage message);
    }

    public interface ITrayCommand
    {

    }
}