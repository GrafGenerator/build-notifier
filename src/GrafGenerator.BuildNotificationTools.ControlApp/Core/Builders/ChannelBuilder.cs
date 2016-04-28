using System.Configuration;
using GrafGenerator.BuildNotificationTools.Interop;

namespace GrafGenerator.BuildNotificationTools.ControlApp.Core.Builders
{
	public enum SettingsSource
	{
		AppConfig = 1
	}

	public class ChannelBuilder
	{
		public string ChannelName { get; private set; }
		public SettingsSource SettingsSource { get; private set; }

		private ChannelBuilder()
		{
			ChannelName = null;
		}

		private ChannelBuilder(ChannelBuilder other, SettingsSource settingsSource)
		{
			ChannelName = other.ChannelName;
			SettingsSource = settingsSource;
		}

		private ChannelBuilder(ChannelBuilder other, string name)
		{
			ChannelName = name;
			SettingsSource = other.SettingsSource;
		}

		public static ChannelBuilder Create()
		{
			return new ChannelBuilder();
		}

		public ChannelBuilder UseAppConfig()
		{
			return new ChannelBuilder(this, SettingsSource.AppConfig);
		}

		public ChannelBuilder UseChannelName(string name)
		{
			return new ChannelBuilder(this, name);
		}


		public NotificationChannel Build()
		{
			var builder = SettingsSourceBuilderFactory.Create(SettingsSource);
			return builder.Build(this);
		}
	}

	internal class SettingsSourceBuilderFactory
	{
		public static INotificationChannelBuilder Create(SettingsSource settingsSource)
		{
			throw new System.NotImplementedException();
		}
	}

	internal interface INotificationChannelBuilder
	{
		NotificationChannel Build(ChannelBuilder channelBuilder);
	}

	class AppConfigNotificationChannelBuilder : INotificationChannelBuilder
	{
		public NotificationChannel Build(ChannelBuilder channelBuilder)
		{
			var defaultChannelName = ConfigurationManager.AppSettings["DefaultChannelName"];
			var name = channelBuilder.ChannelName ?? defaultChannelName;

			return new NotificationChannel(name);
		}
	}
}
