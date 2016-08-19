using GrafGenerator.BuildNotificationTools.ControlApp.Model;

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
	        var trayIcon = new TrayIconService<BuildInfo>(messageAggregator);
	        var traySettings = new TrayIconSettings();

	        trayIcon.Start();
	    }
	}
}
