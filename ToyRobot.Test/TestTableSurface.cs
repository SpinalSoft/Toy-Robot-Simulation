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
    public class TestTableSurface
    {
        [Fact]
        public void TestMethod1()
        {
            TableSurfaceBL tableSRF = new TableSurfaceBL(5, 5);

            Assert.IsTrue(tableSRF.IsValidPosition(0, 0), "(0, 0) is False");
            Assert.IsTrue(tableSRF.IsValidPosition(4, 4), "(4, 4) is False");
            Assert.IsFalse(tableSRF.IsValidPosition(5, 5), "(5, 5) is True");
            Assert.IsFalse(tableSRF.IsValidPosition(-1, -1), "(-1, -1) is True");
        }
    }
}
