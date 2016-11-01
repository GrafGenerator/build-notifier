namespace GrafGenerator.BuildNotificationTools.ControlApp.Core.Abstraction
{
    public interface ITrayCommandGenerator<in TMessage>
    {
        ITrayCommand Create(TMessage message);
    }

    public interface ITrayCommand
    {
        IBalloonInfoDto ToBalloonDto();
    }

    public interface IBalloonInfoDto
    {
        string Title { get; }
        string Text { get; }
        BuildStatus Status { get; }
    }

    public enum BuildStatus
    {
        Progress,
        Success,
        Warning,
        Error
    }
}