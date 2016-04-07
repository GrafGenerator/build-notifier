using System.Management.Automation;

namespace GrafGenerator.BuildNotificationTools
{
    [Cmdlet(VerbsCommon.Copy, "Resx", DefaultParameterSetName = "DefaultParameterSet")]
    public class GetNotificationChannelCommand: PSCmdlet
    {
        private string _path;

        #region Parameters

        [Parameter(Position = 0, ParameterSetName = "DefaultParameterSet", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }


        #endregion


        #region Overrides

        protected override void BeginProcessing()
        {

        }

        protected override void ProcessRecord()
        {

        }

        #endregion
    }
}
