using System;
using System.Windows.Forms;
using GrafGenerator.BuildNotificationTools.ControlApp.Core.Abstraction;
using GrafGenerator.BuildNotificationTools.ControlApp.Properties;

namespace GrafGenerator.BuildNotificationTools.ControlApp.Core.TrayIcon
{
    internal class TrayIconService<TMessage>
    {
        private readonly TrayIconSettings _settings;
        private readonly ITrayCommandGenerator<TMessage> _trayCommandGenerator;
        private NotifyIcon _notifyIcon;

        public TrayIconService(TrayIconSettings settings, ITrayMessageSupplier<TMessage> trayMessageSupplier, ITrayCommandGenerator<TMessage> trayCommandGenerator)
        {
            _settings = settings;
            _trayCommandGenerator = trayCommandGenerator;
            trayMessageSupplier.MessagesReceived += TrayMessageSupplierOnMessagesReceived;
        }

        private void TrayMessageSupplierOnMessagesReceived(object sender, IMessagesReceivedArgs<TMessage> messagesReceivedArgs)
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
            throw new NotImplementedException();
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