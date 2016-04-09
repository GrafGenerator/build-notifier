using System.Management.Automation;
using System.Messaging;
using GrafGenerator.BuildNotificationTools.Interop;

namespace GrafGenerator.BuildNotificationTools.Commands
{
    [Cmdlet(VerbsCommon.Push, "Notification")]
    public class PushNotificationCommand: PSCmdlet
    {
        private NotificationChannel _channel;
        private BuildMessage _message;

        #region Parameters

        [Parameter(Position = 0, Mandatory = true)]
        [ValidateNotNull]
        public NotificationChannel Channel
        {
            get { return _channel; }
            set { _channel = value; }
        }

        [Parameter(Position = 1, Mandatory = true)]
        [ValidateNotNull]
        public BuildMessage Message
        {
            get { return _message; }
            set { _message = value; }
        }

        #endregion


        #region Overrides

        protected override void ProcessRecord()
        {
            var mq = _channel.MessageQueue;

            var msg = new Message { Recoverable = true, Body = _message };
            mq.Send(msg);
        }

        #endregion
    }
}
