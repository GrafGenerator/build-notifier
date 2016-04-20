using GalaSoft.MvvmLight;
using GrafGenerator.BuildNotificationTools.ControlApp.Model;
using GrafGenerator.BuildNotificationTools.Interop;
using GalaSoft.MvvmLight.Command;
using System;

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

        public RelayCommand AddMessageCommand { get; private set; }

		public const string WelcomeTitlePropertyName = "WelcomeTitle";

		private string _welcomeTitle = "Hey, build is running!";
		private BuildInfoCollection _buildMessages;

        private Guid[] _buildGuids;

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

		public BuildInfoCollection BuildMessages
		{
			get { return _buildMessages; }
			set { Set(ref _buildMessages, value); }
		}

		public MainViewModel(IBuildMessagesStorageService buildMessagesStorageService)
		{
			_buildMessagesStorageService = buildMessagesStorageService;

            BuildMessages = _buildMessagesStorageService.BuildMessages;

            _buildGuids = new[]
            {
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid()
            };

            AddMessageCommand = new RelayCommand(AddNewMessage, () => true);
		}


        private void AddNewMessage()
        {
            var r = new Random();

            var buildGuid = _buildGuids[r.Next(_buildGuids.Length)];
            var buildMessageKind = (BuildMessageKind)r.Next(8);
            _buildMessagesStorageService.AddMessage(BuildInfo.Create(buildGuid, buildMessageKind, "New message", DateTime.Now.Ticks));
        }
	}
}