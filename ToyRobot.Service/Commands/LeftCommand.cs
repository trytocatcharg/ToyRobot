using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToyRobot.Service.Enum;
using ToyRobot.ViewModel;

namespace ToyRobot.Service.Commands
{
    public class LeftCommand : ICommand
    {
        public string CommandName => "LEFT";

        public string CommandNameRecieved { get; set ; }
        public IValidationRobot validation { get; set; }

        public ToyRobotDetailViewModel Execute(int axisX, int axisY, int[,] MatrixRobot, FacingOrientation currentOrientation)
        {
            var indexDirection = (int)currentOrientation;
            indexDirection = indexDirection - 1;

            if (indexDirection < 0) indexDirection = System.Enum.GetValues(typeof(FacingOrientation)).Cast<int>().Max();
            FacingOrientation newDirection = (FacingOrientation)indexDirection;

            return new ToyRobotDetailViewModel
            {
                AxisX = axisX,
                AxisY = axisY,
                Facing = newDirection.ToString()
            };
        }
    }
}
