using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot.Tests.Service
{
   public static class Utils
    {

        public static string ReturnCommand(List<string> commandParam)
        {
            string command = string.Empty;
            for (int i = 0; i < commandParam.Count; i++)
            {
                if ((commandParam.Count - 1) == i)
                {
                    command = command + commandParam[i];
                }
                else
                {
                    command = command + commandParam[i] + "\n";
                }

            }
            return command;
        }
    }
}
