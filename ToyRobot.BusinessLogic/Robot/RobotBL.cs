using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.BusinessLogic.Models;

namespace ToyRobot.BusinessLogic.Robot
{
    public class RobotBL : IRobotBL
    {
        public void Move(Direction dir)
        {
            switch (dir.directionBL)
            {
                case "east":
                    dir.east += 1;
                    break;
                case "west":
                    dir.east -= 1;
                    break;
                case "north":
                    dir.north += 1;
                    break;
                case "south":
                    dir.north -= 1;
                    break;
            }
        }

        public void TurnLeft(Direction dir)
        {
            switch (dir.directionBL)
            {
                case "east":
                    dir.directionBL = "north";
                    break;
                case "west":
                    dir.directionBL = "south";
                    break;
                case "north":
                    dir.directionBL = "west";
                    break;
                case "south":
                    dir.directionBL = "east";
                    break;
            }
        }

        public void TurnRight(Direction dir)
        {
            switch (dir.directionBL)
            {
                case "east":
                    dir.directionBL = "south";
                    break;
                case "west":
                    dir.directionBL = "north";
                    break;
                case "north":
                    dir.directionBL = "east";
                    break;
                case "south":
                    dir.directionBL = "west";
                    break;
            }
        }

        public string Report(Direction dir)
        {
            var responseMsg = "<b>Current Postion</b> : <br/>x = " + dir.east + "<br/> y = " + dir.north + "<br/> direction = " + dir.directionBL.ToUpper();

            return responseMsg;
        }
    }
}
