using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.Service.Enum;
using ToyRobot.ViewModel;

namespace ToyRobot.Service.Commands
{
    public class PlaceCommand : ICommand
    {
        public string CommandName => "PLACE";
        public string CommandNameRecieved { get; set; }
        public IValidationRobot validation { get; set; }
        public PlaceCommand(IValidationRobot validationRobot)
        {
            this.validation = validationRobot;
        }

        public ToyRobotDetailViewModel Execute(int axisX, int axisY, int[,] MatrixRobot, FacingOrientation currentOrientation)
        {
            var firtCommandCoord = CommandNameRecieved.Split((new char[] { ',' }));
            
            if (!validation.ValidNumber(firtCommandCoord[0])) throw new Exception(validation.Errors);
            if (!validation.ValidNumber(firtCommandCoord[1])) throw new Exception(validation.Errors);

            if (!validation.ValidPosition(Convert.ToInt32(firtCommandCoord[0]), Convert.ToInt32(firtCommandCoord[1]), MatrixRobot)) throw new Exception(validation.Errors);


            return new ToyRobotDetailViewModel
            {
                Facing = firtCommandCoord[2].ToString(),
                AxisX = Convert.ToInt32(firtCommandCoord[0]),
                AxisY = Convert.ToInt32(firtCommandCoord[1])
            };
        }
    }
}
