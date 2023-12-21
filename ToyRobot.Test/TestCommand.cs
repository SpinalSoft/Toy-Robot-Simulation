using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.BusinessLogic.Command;
using ToyRobot.BusinessLogic.Models;
using ToyRobot.BusinessLogic.Robot;
using ToyRobot.BusinessLogic.Simulator;
using ToyRobot.BusinessLogic.TableSurface;
using Xunit;

namespace ToyRobot.Test
{
    public class TestCommand
    {

        private Lazy<ISimulatorBL> _simulatorLzy;
        private ISimulatorBL _simulatorBL => _simulatorLzy.Value;
        private string ErrorInputs { get; set; } = "The input commands in the file are not correctly formatted.";

        List<string> Coordinate;

        public TestCommand(Lazy<ISimulatorBL> simulatorLzy)
        {
            _simulatorLzy = simulatorLzy;
        }

        [Fact]
        public void TestMethod1()
        {
            Direction expected = new Direction { east = 2, north = 3, directionBL = "east" };

            CommandBL testSetup = new CommandBL(_simulatorLzy);
            TableSurfaceBL table = new TableSurfaceBL(5, 5);
            testSetup.ProcessCommand("PLACE 2,3,EAST", expected);
            Coordinate.Add("PLACE 2,3,EAST");

            Assert.AreSame(ErrorInputs, testSetup.Start(Coordinate));
        }

        [Fact]
        public void TestMethod2()
        {
            Direction expected = new Direction { east = 3, north = 3, directionBL = "east" };

            CommandBL testSetup = new CommandBL(_simulatorLzy);
            TableSurfaceBL table = new TableSurfaceBL(5, 5);
            testSetup.ProcessCommand("PLACE 1,3,EAST", expected);
            testSetup.ProcessCommand("MOVE", null);          

            Assert.AreEqual(ErrorInputs, testSetup.Start(Coordinate));
        }

        [Fact]
        public void TestMethod3()
        {
            Direction expected = new Direction { east = 4, north = 4, directionBL = "east" };

            CommandBL testSetup = new CommandBL(_simulatorLzy);
            TableSurfaceBL table = new TableSurfaceBL(5, 5);
            testSetup.ProcessCommand("PLACE 4,4,EAST", null);
            testSetup.ProcessCommand("MOVE", null);            

            Assert.AreEqual(ErrorInputs, testSetup.Start(Coordinate));
        }



    }
}
