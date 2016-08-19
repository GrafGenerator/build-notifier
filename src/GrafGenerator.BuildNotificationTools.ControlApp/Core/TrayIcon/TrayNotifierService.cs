using GrafGenerator.BuildNotificationTools.ControlApp.Model;
using GrafGenerator.BuildNotificationTools.ControlApp.Properties;

namespace GrafGenerator.BuildNotificationTools.ControlApp.Core.TrayIcon
{
	public class TrayNotifierService
	{
	    private readonly IBuildMessagesStorageService _storage;

	    public TrayNotifierService(IBuildMessagesStorageService storage)
	    {
	        _storage = storage;
	    }

	    public void Start()
	    {
	        var messageAggregator = new BuildInfoAggregator(_storage);
	        var traySettings = new TrayIconSettings {Icon = Resources.app};

            var trayIcon = new TrayIconService<BuildInfo>(traySettings, messageAggregator, new BuildInfoTrayCommandGenerator());

	        trayIcon.Start();
	    }
	}
}
