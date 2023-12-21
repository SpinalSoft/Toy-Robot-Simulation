using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.BusinessLogic.Robot;
using ToyRobot.BusinessLogic.Command;
using ToyRobot.BusinessLogic.Models;
using ToyRobot.BusinessLogic.Simulator;
using ToyRobot.BusinessLogic.TableSurface;
using Xunit;

namespace ToyRobot.Test
{
    public class TestDirection
    {
        [Fact]
        public void TestMethood1()
        {
            Direction obj = new Direction { directionBL = "east" };
            IRobotBL robotBL = new RobotBL();

            robotBL.Move(obj);

            Assert.AreEqual(3, obj.east);
        }

        [Fact]
        public void TestMethood2()
        {
            Direction obj = new Direction { directionBL = "west" };
            IRobotBL robotBL = new RobotBL();

            robotBL.Move(obj);

            Assert.AreEqual(4, obj.east);
        }

        [Fact]
        public void TestMethood3()
        {
            Direction obj = new Direction { directionBL = "east" };
            IRobotBL robotBL = new RobotBL();

            robotBL.Move(obj);

            Assert.AreEqual(-3, obj.east);
        }

        [Fact]
        public void TestMethood4()
        {
            Direction obj = new Direction { directionBL = "east" };
            IRobotBL robotBL = new RobotBL();

            robotBL.TurnLeft(obj);

            Assert.AreEqual("west", obj.directionBL);
        }

        [Fact]
        public void TestMethood5()
        {
            Direction obj = new Direction { directionBL = "east" };
            IRobotBL robotBL = new RobotBL();

            robotBL.TurnRight(obj);

            Assert.AreEqual("west", obj.directionBL);
        }
    }
}
