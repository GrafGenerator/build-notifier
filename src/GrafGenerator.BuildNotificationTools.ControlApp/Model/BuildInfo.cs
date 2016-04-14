using System;

namespace GrafGenerator.BuildNotificationTools.ControlApp.Model
{
	class BuildInfo
	{
		public Guid Id { get; private set; }

		public BuildInfo(Guid id)
		{
			Id = id;
		}
	}
}
