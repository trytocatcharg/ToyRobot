using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.Service.Enum;

namespace ToyRobot.Service
{
    public class ValidationRobot : IValidationRobot
    {
        private string errors;
        public string Errors
        {
            get { return errors; }
        }


        public bool ValidNumber(string numberString)
        {
            int j;
            if (Int32.TryParse(numberString, out j))
                return true;
            else
            {
                errors = "Invalid number";
                return false;
            }
        }

        public bool ValidPosition(int axisX, int axisY, int[,] MatrixRobot)
        {
            try
            {
                MatrixRobot[axisX, axisY] = 1;
            }
            catch (Exception)
            {
                errors = "Invalid position";
                return false;
            }
            MatrixRobot[axisX, axisY] = 0;
            return true;
        }

        public bool ValidateInitialCommand(string command)
        {
            if (!command.ToUpper().StartsWith("PLACE"))
            {
                errors="The command must start with PLACE command";
                return false;
            }
            return true;
        }
    
        public bool ValidateCommandFacing(string command)
        {
            try
            {
                var enumResult=(FacingOrientation)System.Enum.Parse(typeof(FacingOrientation), command);
            }
            catch (Exception)
            {
                errors = "The facing command is invalid";
                return false;
            }
            return true;
        }

        public bool ValidateCommandMovment(string command)
        {
            try
            {
                var enumResult = (FacingDirection)System.Enum.Parse(typeof(FacingDirection), command);
            }
            catch (Exception)
            {
                errors = "The move command is invalid";
                return false;
            }
            return true;

        }


    }
}
