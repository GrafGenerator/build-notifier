using GrafGenerator.BuildNotificationTools.ControlApp.Core.Abstraction;
using GrafGenerator.BuildNotificationTools.ControlApp.Model;

namespace GrafGenerator.BuildNotificationTools.ControlApp.Core.TrayIcon
{
    internal class BuildInfoTrayCommandGenerator : ITrayCommandGenerator<BuildInfo>
    {
        public ITrayCommand Create(BuildInfo message)
        {
            return new BalloonTrayCommand(message.Message, message.Id.ToString(), message.MessageKind);
        }
    }
}