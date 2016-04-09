using System;
using System.Management.Automation;
using GrafGenerator.BuildNotificationTools.Interop;

namespace GrafGenerator.BuildNotificationTools.Commands
{
    [Cmdlet(VerbsCommon.Open, "NotificationChannel")]
    public class OpenNotificationChannelCommand: PSCmdlet
    {
        private string _name;

        #region Parameters

        [Parameter(Position = 0, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        #endregion


        #region Overrides

        protected override void BeginProcessing()
        {
            _name = _name.Trim();

            if (_name.Length == 0)
            {
                ThrowTerminatingError(new ErrorRecord(
                    new ArgumentException("Channel name must be not empty or whitespace"),
                    "InvalidChannelname",
                    ErrorCategory.InvalidArgument, 
                    _name
                ));
            }
        }

        protected override void ProcessRecord()
        {
            var notificationChannel = new NotificationChannel(_name);

            WriteObject(notificationChannel);
        }

        #endregion
    }
}
