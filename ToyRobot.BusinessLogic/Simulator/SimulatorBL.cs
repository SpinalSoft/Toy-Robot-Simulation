using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.BusinessLogic.Models;
using ToyRobot.BusinessLogic.Robot;
using ToyRobot.BusinessLogic.TableSurface;

namespace ToyRobot.BusinessLogic.Simulator
{
    public class SimulatorBL : ISimulatorBL
    {
        private Lazy<ITableSurfaceBL> _tableLzy;
        private Lazy<IRobotBL> _robotLzy;

        private ITableSurfaceBL _tableBL => _tableLzy.Value;
        private IRobotBL _robotBL => _robotLzy.Value;

        public SimulatorBL(Lazy<ITableSurfaceBL> tableLzy, Lazy<IRobotBL> robotLzy)
        {
            _tableLzy = tableLzy;
            _robotLzy = robotLzy;
        }

        public string RobotMoves(string movement, Direction direction)
        {
            var message = string.Empty;
            if (movement == "move")
            {
                if (_tableBL.IsValidPosition(direction.east + 1, direction.north + 1)
                       && _tableBL.IsValidPosition(direction.east - 1, direction.north - 1))
                {
                    _robotBL.Move(direction);
                }
            }
            else if (movement == "right")
            {
                _robotBL.TurnRight(direction);
            }
            else if (movement == "left")
            {
                _robotBL.TurnLeft(direction);
            }
            else if (movement == "report")
            {
                message = _robotBL.Report(direction);
            }

            return message;
        }
    }
}
