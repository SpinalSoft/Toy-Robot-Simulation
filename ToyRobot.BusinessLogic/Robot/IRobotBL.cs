using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.BusinessLogic.Models;

namespace ToyRobot.BusinessLogic.Robot
{
    public interface IRobotBL
    {
        void Move(Direction dir);
        void TurnLeft(Direction dir);
        void TurnRight(Direction dir);
        string Report(Direction dir);
    }
}
