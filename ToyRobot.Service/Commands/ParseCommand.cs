using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToyRobot.Service.Enum;

namespace ToyRobot.Service.Commands
{
    /// <summary>
    /// The 'Receiver' class
    /// </summary>
    public class ParseCommand
    {

        private List<ICommand> _parsers = new List<ICommand>()
        {
            new LeftCommand(),
            new MoveCommand(),
            new RightCommand(),
            new PlaceCommand(new ValidationRobot())
        };


        
        public ICommand Action(string commandLine)
        {
            if (string.IsNullOrEmpty(commandLine.Trim()))
            {
                throw new Exception("Invalid command");
            }

            var commandStrArray = commandLine.Split(Convert.ToChar(@" "));

            if (commandStrArray.Length < 1)
            {
                throw new Exception("Invalid command");
            }

            var parser = _parsers.FirstOrDefault(x => x.CommandName.Equals(commandStrArray[0].Trim(), StringComparison.InvariantCultureIgnoreCase));

            if (parser==null)
            {
                throw new Exception("Invalid command");
            }
            if (commandStrArray.Length>1 && !string.IsNullOrEmpty(commandStrArray[1]))
            {
                parser.CommandNameRecieved = commandStrArray[1]; //= commandStrArray[1].Split((new char[] { ',' }));
            }

            return parser;
        }
    }
}
