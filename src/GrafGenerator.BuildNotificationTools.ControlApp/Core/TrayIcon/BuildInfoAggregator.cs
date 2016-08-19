using System;
using System.Linq;
using GrafGenerator.BuildNotificationTools.ControlApp.Core.Abstraction;
using GrafGenerator.BuildNotificationTools.ControlApp.Model;

namespace GrafGenerator.BuildNotificationTools.ControlApp.Core.TrayIcon
{
    public class BuildInfoAggregator: ITrayMessageSupplier<BuildInfo>
    {
        public BuildInfoAggregator(IBuildMessagesStorageService storage)
        {
            storage.BuildInfoReceived += StorageOnBuildInfoReceived;
        }

        public event EventHandler<IMessagesReceivedArgs<BuildInfo>> MessagesReceived;

        private void StorageOnBuildInfoReceived(object sender, BuildInfoReceivedArgs buildInfoReceivedArgs)
        {
            var latestInfoPerBuild = buildInfoReceivedArgs.BuildInfos
                .GroupBy(i => i.Id)
                .Select(g => new
                {
                    Id = g.Key,
                    LatestInfo = g.OrderByDescending(i => i.Timestamp).First()
                })
                .ToDictionary(a => a.Id, a => a.LatestInfo);

            var args = new MessagesReceivedArgs<BuildInfo>(latestInfoPerBuild.Values.ToArray());
            OnBuildInfoReceived(args);
        }

        protected virtual void OnBuildInfoReceived(MessagesReceivedArgs<BuildInfo> e)
        {
            MessagesReceived?.Invoke(this, e);
        }
    }
}