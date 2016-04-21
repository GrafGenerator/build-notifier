namespace GrafGenerator.BuildNotificationTools.ControlApp.Core.Builders.Configuration
{
	public class ChannelConfiguration
	{
		private ChannelConfiguration()
		{
			// todo: init config
		}

		public static ChannelConfiguration Create()
		{
			return new ChannelConfiguration();
		}

		// todo: provide methods for fluent style initialization
		// todo: fetch data from app.config
	}
}
