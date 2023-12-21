using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.BusinessLogic.Models;

namespace ToyRobot.BusinessLogic.Simulator
{
    public interface ISimulatorBL
    {
        string RobotMoves(string movement, Direction _dir);
    }
}
