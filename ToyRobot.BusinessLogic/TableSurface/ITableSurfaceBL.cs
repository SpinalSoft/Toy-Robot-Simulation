using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot.BusinessLogic.TableSurface
{
    public interface ITableSurfaceBL
    {
        bool IsValidPosition(int east, int north);
    }
}
