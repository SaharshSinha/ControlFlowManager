using HumanBeing.Declarations;
using System;
using System.Threading;

namespace HumanBeing.Core.Definitions.DailyTasks
{
    public class TheDriveHome : TaskBase, IDailyTask
    {
        public override void Execute()
        {
            Console.WriteLine("There's higher than usual traffic on your way home. It's 25 mins by car");
            Thread.Sleep(1500);
        }
    }
}
