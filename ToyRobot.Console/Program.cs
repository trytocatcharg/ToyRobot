using Ninject;
using System.Collections.Generic;
using System.Reflection;
using ToyRobot.Service;
using System;
using ToyRobot.Service.Commands;

namespace ToyRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string s = "";
            string command = "";
            List<string> result = new List<string> { };


            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            var serviceRobot = kernel.Get<IRobotService>();
            

            Console.WriteLine("Insert the command or EXIT to stop the program");

            s = Console.ReadLine();
            do
            {
                if (s == null || string.IsNullOrEmpty(s))
                {
                    continue;
                }
                if (s.Equals("EXIT", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
               
                if (s.ToUpper() == "REPORT")
                {
                    try
                    {
                        var resultServic = serviceRobot.Movement();
                        result = new List<string>();
                        Console.WriteLine($"{resultServic.AxisX},{resultServic.AxisY},{resultServic.Facing.ToString()}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("\n" + e.Message);
                    }
                s = Console.ReadLine();
                continue;
                }
                serviceRobot.Compute(s);


                s = Console.ReadLine();
            } while (true);
            

                    
            
            Console.Read();
        }
    }
}
