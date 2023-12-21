using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.BusinessLogic.Command;
using ToyRobot.BusinessLogic.Robot;
using ToyRobot.BusinessLogic.Simulator;
using ToyRobot.BusinessLogic.TableSurface;
using ToyRobot.BusinessLogic.Models;
using Microsoft.Extensions.Options;

namespace ToyRobot.BusinessLogic.BusinessWrapper
{
    public class BusinessWrapper : IBusinessWrapper
    {
        private int width = 0;
        private int height = 0;
        private readonly Lazy<ITableSurfaceBL> _tableBL;
        private readonly Lazy<IRobotBL> _robotBL;
        private readonly Lazy<ISimulatorBL> _simulatorBL;
        private readonly Lazy<ICommandBL> _commmandBL;
        private readonly AppSettingsDTO _appsettings;

        public BusinessWrapper(IOptions<AppSettingsDTO> appSettings)
        {
            this._appsettings = appSettings.Value;
            width = this._appsettings.Width;
            height = this._appsettings.Length;

            _tableBL = new(() => new TableSurfaceBL(width, height));
            _robotBL = new(() => new RobotBL());
            _simulatorBL = new(() => new SimulatorBL(_tableBL, _robotBL));
            _commmandBL = new(() => new CommandBL(_simulatorBL));
        }

        public ITableSurfaceBL tableBL => _tableBL.Value;

        public IRobotBL robotBL => _robotBL.Value;

        public ISimulatorBL simulatorBL => _simulatorBL.Value;

        public ICommandBL commandBL => _commmandBL.Value;
    }
}
