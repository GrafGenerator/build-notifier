using System;

namespace GrafGenerator.BuildNotificationTools.ControlApp.Model
{
	public class BuildInfoReceivedArgs: EventArgs
	{
		public BuildInfo[] BuildInfos { get; }

		private BuildInfoReceivedArgs(BuildInfo[] buildInfos)
		{
			BuildInfos = buildInfos;
		}


		public static BuildInfoReceivedArgs Create(BuildInfo[] buildInfos)
		{
			return new BuildInfoReceivedArgs(buildInfos);
		}
	}
}
