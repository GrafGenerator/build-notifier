using System;

namespace GrafGenerator.BuildNotificationTools.Interop
{
    public class BuildConfiguration
    {
        public Guid Id { get; private set; }

        private BuildConfiguration(Guid id)
        {
            Id = id;
        }

        public static BuildConfiguration Create()
        {
            return new BuildConfiguration(Guid.NewGuid());
        }
    }
}
