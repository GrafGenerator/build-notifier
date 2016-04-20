using GrafGenerator.FunctionalExtensions;

namespace GrafGenerator.BuildNotificationTools.ControlApp.Model
{
    public interface IBuildMessagesStorageService
	{
        BuildInfoCollection BuildMessages { get; }
		Result AddMessage(BuildInfo message);
	}
}
