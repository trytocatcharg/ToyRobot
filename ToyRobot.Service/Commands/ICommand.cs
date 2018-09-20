using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.Service.Enum;

namespace ToyRobot.Service.Commands
{
    ///// The 'Command' interface
    public interface ICommand
    {
        string CommandName { get; }
        string CommandNameRecieved { get; set; }
        IValidationRobot validation { get; set; }

        ViewModel.ToyRobotDetailViewModel Execute(int axisX, int axisY, int[,] MatrixRobot, FacingOrientation currentOrientation);

    }
}
