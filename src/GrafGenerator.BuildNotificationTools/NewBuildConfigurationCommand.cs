using System.Management.Automation;
using GrafGenerator.BuildNotificationTools.Interop;

namespace GrafGenerator.BuildNotificationTools
{
    [Cmdlet(VerbsCommon.New, "BuildConfiguration")]
    public class NewBuildConfigurationCommand: PSCmdlet
    {
        #region Overrides

        protected override void ProcessRecord()
        {
            var buildConfiguration = BuildConfiguration.Create();

            WriteObject(buildConfiguration);
        }

        #endregion
    }
}
