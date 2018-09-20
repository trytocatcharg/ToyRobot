using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.Service.Enum;
using ToyRobot.ViewModel;

namespace ToyRobot.Service
{
    public interface IRobotService
    {

        void Compute(string commandLine);
        ToyRobotDetailViewModel Movement();
    }
}
