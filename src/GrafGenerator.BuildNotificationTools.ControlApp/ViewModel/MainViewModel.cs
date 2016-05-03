using GalaSoft.MvvmLight;
using GrafGenerator.BuildNotificationTools.ControlApp.Core.Builders;
using GrafGenerator.BuildNotificationTools.ControlApp.Core.MessageQueue;
using GrafGenerator.BuildNotificationTools.ControlApp.Model;
using GalaSoft.MvvmLight.Command;

namespace GrafGenerator.BuildNotificationTools.ControlApp.ViewModel
{
	/// <summary>
	/// This class contains properties that the main View can data bind to.
	/// <para>
	/// See http://www.mvvmlight.net
	/// </para>
	/// </summary>
	public class MainViewModel : ViewModelBase
	{
		public RelayCommand AddMessageCommand { get; private set; }



		private readonly IBuildMessagesStorageService _buildMessagesStorageService;
		private BuildInfoCollection _buildMessages;
		private BuildMessageListenerService _buildMessageListenerService;



		public BuildInfoCollection BuildMessages
		{
			get { return _buildMessages; }
			set { Set(ref _buildMessages, value); }
		}

		public MainViewModel(IBuildMessagesStorageService buildMessagesStorageService)
		{
			var channel = ChannelBuilder.Create().UseAppConfig().Build();

			_buildMessagesStorageService = buildMessagesStorageService;
			_buildMessageListenerService = new BuildMessageListenerService(channel, _buildMessagesStorageService);

			BuildMessages = _buildMessagesStorageService.BuildMessages;

			_buildMessageListenerService.Listen();
		}
	}
}