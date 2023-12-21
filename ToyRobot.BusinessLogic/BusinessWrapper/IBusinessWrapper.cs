using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.BusinessLogic.Command;
using ToyRobot.BusinessLogic.Robot;
using ToyRobot.BusinessLogic.Simulator;
using ToyRobot.BusinessLogic.TableSurface;

namespace ToyRobot.BusinessLogic.BusinessWrapper
{
    public interface IBusinessWrapper
    {
        ITableSurfaceBL tableBL { get; }
        IRobotBL robotBL { get; }
        ISimulatorBL simulatorBL { get; }
        ICommandBL commandBL { get; }
    }
}
