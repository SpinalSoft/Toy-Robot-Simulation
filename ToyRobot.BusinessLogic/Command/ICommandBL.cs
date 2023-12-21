using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.BusinessLogic.Models;

namespace ToyRobot.BusinessLogic.Command
{
    public interface ICommandBL
    {
        string Start(List<string> commands);
        void ProcessCommand(string command, Direction direction);
    }
}
