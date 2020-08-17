using HumanBeing.Declarations;
using System;
using System.Threading;

namespace HumanBeing.Core.Definitions.DailyTasks
{
    public class TheDishwasher : TaskBase, IDailyTask
    {
        public override void Execute()
        {
            Console.WriteLine("Dishwasher is running");
            Thread.Sleep(100);
        }
    }
}
