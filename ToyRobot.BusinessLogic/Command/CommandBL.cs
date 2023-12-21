using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ToyRobot.BusinessLogic.Models;
using ToyRobot.BusinessLogic.Simulator;
using ToyRobot.BusinessLogic.TableSurface;

namespace ToyRobot.BusinessLogic.Command
{
    public class CommandBL : ICommandBL
    {
        private Lazy<ISimulatorBL> _simulatorLzy;
        private ISimulatorBL _simulatorBL => _simulatorLzy.Value;
        private bool Placed { get; set; }
        private string Message { get; set; } = string.Empty;
        private string[] Coordinates { get; set; } = null;
        private Direction direction { get; set; }
        private string ErrorInputs { get; set; } = "The input commands in the file are not correctly formatted.";

        public CommandBL(Lazy<ISimulatorBL> simulatorLzy)
        {
            _simulatorLzy = simulatorLzy;
        }

        public Direction FillObject(string[] coordinates)
        {
            int eastV;
            int northV;

            if (coordinates.Length == 4)
            {
                bool meastTest = Int32.TryParse(coordinates[1], out eastV);
                bool northTest = Int32.TryParse(coordinates[2], out northV);

                direction = new Direction
                {
                    east = eastV,
                    north = northV,
                    directionBL = coordinates[3].ToLower()
                };
            }

            return direction;
        }

        public string Start(List<string> commands)
        {
            try
            {
                foreach (string command in commands)
                {
                    if (Placed)
                    {
                        if (direction == null)
                        {
                            if (Coordinates.Length == 4)
                            {
                                direction = FillObject(Coordinates);
                            }
                            else
                            {
                                return "The input commands in the file are not correctly formatted.";
                            }
                        }

                        ProcessCommand(command, direction);

                    }
                    else if (Regex.IsMatch(command, "[PLACE]"))
                    {
                        Coordinates = command.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        Placed = true;
                    }
                    else
                    {
                        Message = ErrorInputs;
                    }

                    if (Message == ErrorInputs)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
           
            return Message;
        }

        public void ProcessCommand(string command, Direction dir)
        {
            if (command.Equals("MOVE") || command.Equals("RIGHT") || command.Equals("LEFT") || command.Equals("REPORT"))
            {
                Message = _simulatorBL.RobotMoves(command.ToLower(), dir);
            }
            else
            {
                Message = ErrorInputs;
            }
        }
    }
}
