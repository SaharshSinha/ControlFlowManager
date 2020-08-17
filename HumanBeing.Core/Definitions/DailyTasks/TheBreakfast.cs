using HumanBeing.Declarations;
using System;
using System.Threading;

namespace HumanBeing.Core.Definitions.DailyTasks
{
    public class TheBreakfast : TaskBase, IDailyTask
    {
        public override void Execute()
        {
            Console.WriteLine("Eating breakfast");
            Thread.Sleep(300);
        }
    }
}
