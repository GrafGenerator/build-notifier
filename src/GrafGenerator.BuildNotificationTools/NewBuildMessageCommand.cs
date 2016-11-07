using System;
using System.Management.Automation;
using GrafGenerator.BuildNotificationTools.Interop;

namespace GrafGenerator.BuildNotificationTools.Commands
{
    [Cmdlet(VerbsCommon.New, "BuildMessage")]
    public class NewBuildMessageCommand: PSCmdlet
    {
        private BuildConfiguration _configuration;
        private string _message;
        private string _messageKind;
        private BuildMessageKind _messageKindEnum;

        #region Parameters

        [Parameter(Position = 0, Mandatory = true)]
        [ValidateNotNull]
        [Alias("Conf", "B")]
        public BuildConfiguration Build
        {
            get { return _configuration; }
            set { _configuration = value; }
        }

        [Parameter(Position = 1, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        [Alias("Kind")]
        public string MessageKind
        {
            get { return _messageKind; }
            set { _messageKind = value; }
        }

        [Parameter(Position = 2, Mandatory = false)]
        [Alias("M")]
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }



        #endregion

        #region Overrides

        protected override void BeginProcessing()
        {
            BuildMessageKind kind;

            var result = Enum.TryParse(_messageKind, true, out kind);

            _messageKindEnum = result ? kind : BuildMessageKind.Unknown;
            _message = _message ?? "";
        }

        protected override void ProcessRecord()
        {
            var buildMessage = new BuildMessage()
            {
                BuildId = _configuration.Id,
                MessageKind = _messageKindEnum,
                Message = _message,
                OccurredOn = DateTime.Now
            };

            WriteObject(buildMessage);
        }

        #endregion
    }
}
