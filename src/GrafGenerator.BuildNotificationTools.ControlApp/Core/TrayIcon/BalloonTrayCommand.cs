using GrafGenerator.BuildNotificationTools.ControlApp.Core.Abstraction;
using GrafGenerator.BuildNotificationTools.ControlApp.Properties;
using GrafGenerator.BuildNotificationTools.Interop;

namespace GrafGenerator.BuildNotificationTools.ControlApp.Core.TrayIcon
{
    public class BalloonTrayCommand : ITrayCommand
    {
        private static readonly string DefaultTitle = Resources.TrayIconService_AppName;
        private readonly BuildMessageKind _kind;
        private readonly string _text;

        private readonly string _title;

        public BalloonTrayCommand(string text = null, string title = null,
            BuildMessageKind kind = BuildMessageKind.Unknown)
        {
            _title = title;
            _kind = kind;
            _text = text;
        }


        public string Title => _title ?? DefaultTitle;

        public string Text => _text ?? "";

        public IBalloonInfoDto ToBalloonDto()
        {
            return new BalloonInfoDto(Title, Text, BuildMessageKindToStatus(_kind));
        }

        private static BuildStatus BuildMessageKindToStatus(BuildMessageKind kind)
        {
            switch (kind)
            {
                case BuildMessageKind.Init:
                case BuildMessageKind.Start:
                case BuildMessageKind.Progress:
                    return BuildStatus.Progress;

                case BuildMessageKind.Finish:
                    return BuildStatus.Success;

                case BuildMessageKind.Error:
                    return BuildStatus.Error;

                case BuildMessageKind.Warning:
                    return BuildStatus.Warning;

                default:
                    return BuildStatus.Progress;
            }
        }
    }
}