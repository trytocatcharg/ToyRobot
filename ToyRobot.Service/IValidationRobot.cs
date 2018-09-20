using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot.Service
{
    public interface IValidationRobot
    {
        string Errors { get; }
        bool ValidNumber(string numberString);
        bool ValidPosition(int axisX, int axisY, int[,] MatrixRobot);
        bool ValidateInitialCommand(string command);
        bool ValidateCommandFacing(string command);
        bool ValidateCommandMovment(string command);



    }
}
