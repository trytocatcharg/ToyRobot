using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.Service.Enum;
using ToyRobot.ViewModel;

namespace ToyRobot.Service.Commands
{
    public class MoveCommand : ICommand
    {
        public string CommandName => "MOVE";
        public string CommandNameRecieved { get; set; }
        public IValidationRobot validation { get; set; }
        public ToyRobotDetailViewModel Execute(int axisX, int axisY, int[,] MatrixRobot, FacingOrientation currentOrientation)
        {
            int indexToMove = 1;
            var newDirection = currentOrientation;
            int currentRow= axisY, currentColumn= axisX;
            if (currentOrientation == FacingOrientation.WEST
                 || currentOrientation == FacingOrientation.SOUTH)
                indexToMove = -1;

            //north and south --> move between rows
            if (newDirection == FacingOrientation.NORTH
                        || newDirection == FacingOrientation.SOUTH)
            {
                currentRow = axisY + indexToMove;
            }
            else
            {
                //west and east --> move between columns
                currentColumn = axisX + indexToMove;
            }

            return new ToyRobotDetailViewModel
            {
                AxisX = currentColumn,
                AxisY = currentRow,
                Facing = newDirection.ToString()
            };
        }
    }
}
