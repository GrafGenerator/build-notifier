using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GrafGenerator.BuildNotificationTools.ControlApp.Core.Builders;
using GrafGenerator.BuildNotificationTools.ControlApp.Core.MessageQueue;
using GrafGenerator.BuildNotificationTools.ControlApp.Core.TrayIcon;
using GrafGenerator.BuildNotificationTools.ControlApp.Model;

namespace GrafGenerator.BuildNotificationTools.ControlApp.ViewModel
{
    /// <summary>
    ///     This class contains properties that the main View can data bind to.
    ///     <para>
    ///         See http://www.mvvmlight.net
    ///     </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private BuildInfoCollection _buildMessages;

        public MainViewModel(IBuildMessagesStorageService buildMessagesStorageService)
        {
            var channel = ChannelBuilder.Create().UseAppConfig().Build();

            var buildMessagesStorageService1 = buildMessagesStorageService;
            var buildMessageListenerService = new BuildMessageListenerService(channel, buildMessagesStorageService1);

            BuildMessages = buildMessagesStorageService1.BuildMessages;

            buildMessageListenerService.Listen();

            var trayNotifierService = new TrayNotifierService(buildMessagesStorageService1);
            trayNotifierService.Start();
        }

        public BuildInfoCollection BuildMessages
        {
            get { return _buildMessages; }
            set { Set(ref _buildMessages, value); }
        }
    }
}