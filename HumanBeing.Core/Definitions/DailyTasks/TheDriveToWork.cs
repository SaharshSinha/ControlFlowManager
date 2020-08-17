using HumanBeing.Declarations;
using System;
using System.Threading;

namespace HumanBeing.Core.Definitions.DailyTasks
{
    public class TheDriveToWork : TaskBase, IDailyTask
    {
        public override void Execute()
        {
            Console.WriteLine("Traffic is light as usual. It's 15 mins by car");
            Thread.Sleep(1500);
        }
    }
}
