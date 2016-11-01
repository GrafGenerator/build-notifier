using GrafGenerator.BuildNotificationTools.ControlApp.Core.Abstraction;

namespace GrafGenerator.BuildNotificationTools.ControlApp.Core.TrayIcon
{
    class BalloonInfoDto : IBalloonInfoDto
    {
        public string Title { get; }
        public string Text { get; }
        public BuildStatus Status { get; }

        public BalloonInfoDto(string title, string text, BuildStatus status)
        {
            Title = title;
            Text = text;
            Status = status;
        }
    }
}