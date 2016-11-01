using System;
using System.Collections.Specialized;
using GrafGenerator.FunctionalExtensions;

namespace GrafGenerator.BuildNotificationTools.ControlApp.Model
{
	public abstract class BuildMessagesStorageServiceBase : IBuildMessagesStorageService
	{
        public BuildInfoCollection BuildMessages { get; }
		public event EventHandler<BuildInfoReceivedArgs> BuildInfoReceived;

	    protected BuildMessagesStorageServiceBase()
        {
            BuildMessages = new BuildInfoCollection();

	        InitData();

			BuildMessages.CollectionChanged += BuildMessagesOnCollectionChanged;
        }

		protected abstract void InitData();


		public Result AddMessage(BuildInfo message)
        {
            BuildMessages.Add(message);
            return Result.Ok();
        }


		private void BuildMessagesOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs eventArgs)
		{
			if (eventArgs.Action == NotifyCollectionChangedAction.Add)
			{
				var buildInfos = new BuildInfo[eventArgs.NewItems.Count];
				eventArgs.NewItems.CopyTo(buildInfos, 0);

				OnBuildInfoReceived(BuildInfoReceivedArgs.Create(buildInfos));
			}
		}


		protected virtual void OnBuildInfoReceived(BuildInfoReceivedArgs e)
		{
			BuildInfoReceived?.Invoke(this, e);
		}
	}
}