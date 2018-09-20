using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Service;

namespace ToyRobot.ConsoleApp
{
    public class Bindings: NinjectModule
    {
        public override void Load()
        {
            Bind<Service.IRobotService>().To<RobotService>();
            Bind<Service.IValidationRobot>().To<ValidationRobot>();
            
        }
    }
}
