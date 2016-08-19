using System.Drawing;
using GrafGenerator.BuildNotificationTools.ControlApp.Core.Abstraction;
using GrafGenerator.BuildNotificationTools.ControlApp.Properties;

namespace GrafGenerator.BuildNotificationTools.ControlApp.Core.TrayIcon
{
    public class BalloonTrayCommand : ITrayCommand
    {
        private static readonly string DefaultTitle = Resources.TrayIconService_AppName;
        private static readonly Icon DefaultIcon = Resources.app;
        private readonly Icon _icon;
        private readonly string _text;

        private readonly string _title;

        public BalloonTrayCommand(string text = null, string title = null, Icon icon = null)
        {
            _title = title;
            _text = text;
            _icon = icon;
        }


        public string Title => _title ?? DefaultTitle;

        public string Text => _text ?? "";

        public Icon Icon => _icon ?? DefaultIcon;
    }
}