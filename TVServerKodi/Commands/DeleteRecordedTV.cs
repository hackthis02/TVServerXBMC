using System;
using System.Collections.Generic;
using System.Text;

namespace TVServerKodi.Commands
{
    class DeleteRecordedTV : CommandHandler
    {
        public DeleteRecordedTV(ConnectionHandler connection)
            : base(connection)
        {

        }

        public override void handleCommand(string command, string[] arguments, ref TvControl.IUser me)
        {
            if (arguments == null)
            {
                getConnection().WriteLine("[ERROR]: Expected format: " + getCommandToHandle() + ":RecordingId");
                return;
            }

            int recId = int.Parse(arguments[0]);

            bool result = TVServerConnection.DeleteRecordedTV(recId);
            Console.WriteLine("DeleteRecordedTV result : " + result.ToString());
            writer.write(result.ToString());
        }

        public override string getCommandToHandle()
        {
            return "DeleteRecordedTV";
        }
    }
}
