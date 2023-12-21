using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot.BusinessLogic.TableSurface
{
    public class TableSurfaceBL : ITableSurfaceBL
    {
        private int width { get; set; }
        private int length { get; set; }

        public TableSurfaceBL(int width, int length)
        {
            this.width = width;
            this.length = length;
        }

        public bool IsValidPosition(int east, int north) => east >= 0 && east < width && north >= 0 && north < length;
    }
}
