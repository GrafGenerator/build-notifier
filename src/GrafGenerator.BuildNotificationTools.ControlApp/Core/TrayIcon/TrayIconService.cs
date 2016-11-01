using System;
using System.Configuration;
using System.Windows.Forms;
using GrafGenerator.BuildNotificationTools.ControlApp.Core.Abstraction;
using GrafGenerator.BuildNotificationTools.ControlApp.Properties;

namespace GrafGenerator.BuildNotificationTools.ControlApp.Core.TrayIcon
{
    internal class TrayIconService<TMessage> : IDisposable
    {
        private readonly TrayIconSettings _settings;
        private readonly ITrayCommandGenerator<TMessage> _trayCommandGenerator;
        private readonly int _balloonDuration;
        private NotifyIcon _notifyIcon;

        public TrayIconService(TrayIconSettings settings, ITrayMessageSupplier<TMessage> trayMessageSupplier,
            ITrayCommandGenerator<TMessage> trayCommandGenerator)
        {
            _settings = settings;
            _trayCommandGenerator = trayCommandGenerator;
            trayMessageSupplier.MessagesReceived += TrayMessageSupplierOnMessagesReceived;

            _balloonDuration = Convert.ToInt32(ConfigurationManager.AppSettings["DefaultBalloonDuration"]);
        }

        public void Dispose()
        {
            _notifyIcon.Dispose();
        }

        private void TrayMessageSupplierOnMessagesReceived(object sender,
            IMessagesReceivedArgs<TMessage> messagesReceivedArgs)
        {
            if (_notifyIcon == null) return;

            foreach (var info in messagesReceivedArgs.Messages)
            {
                var command = _trayCommandGenerator.Create(info);
                DispatchCommand(command);
            }
        }

        private void DispatchCommand(ITrayCommand command)
        {
            if (_notifyIcon == null)
                return;

            var dto = command.ToBalloonDto();

            _notifyIcon.ShowBalloonTip(_balloonDuration, dto.Title, dto.Text, GetToolTipIconForBuildStatus(dto.Status));
        }

        private static ToolTipIcon GetToolTipIconForBuildStatus(BuildStatus status)
        {
            switch (status)
            {
                case BuildStatus.Progress:
                case BuildStatus.Success:
                    return ToolTipIcon.Info;

                case BuildStatus.Warning:
                    return ToolTipIcon.Warning;

                case BuildStatus.Error:
                    return ToolTipIcon.Error;

                default:
                    return ToolTipIcon.None;
            }
        }

        public void Start()
        {
            _notifyIcon = new NotifyIcon
            {
                Icon = _settings.Icon,
                Text = Resources.TrayIconService_AppName,
                Visible = true
            };
        }
    }
}