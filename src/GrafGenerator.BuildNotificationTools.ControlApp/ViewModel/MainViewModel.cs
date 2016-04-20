using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GrafGenerator.BuildNotificationTools.ControlApp.Model;
using GrafGenerator.BuildNotificationTools.Interop;

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
		private readonly IBuildMessagesStorageService _buildMessagesStorageService;

		/// <summary>
		/// The <see cref="WelcomeTitle" /> property's name.
		/// </summary>
		public const string WelcomeTitlePropertyName = "WelcomeTitle";

		private string _welcomeTitle = "Hey, build is running!";
		private ObservableCollection<BuildInfo> _buildMessages;

		public string WelcomeTitle
		{
			get
			{
				return _welcomeTitle;
			}
			set
			{
				Set(ref _welcomeTitle, value);
			}
		}

		public ObservableCollection<BuildInfo> BuildMessages
		{
			get { return _buildMessages; }
			set { Set(ref _buildMessages, value); }
		}

		public MainViewModel(IBuildMessagesStorageService buildMessagesStorageService)
		{
			_buildMessagesStorageService = buildMessagesStorageService;

			var messagesResult = _buildMessagesStorageService.GetMessages();

			if (messagesResult.Success)
			{
				BuildMessages = new ObservableCollection<BuildInfo>(messagesResult.Value);
			}
		}
	}
}