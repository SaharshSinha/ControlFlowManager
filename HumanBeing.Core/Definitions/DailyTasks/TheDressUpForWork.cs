using HumanBeing.Declarations;
using System;
using System.Threading;

namespace HumanBeing.Core.Definitions.DailyTasks
{
    public class TheDressUpForWork : TaskBase, IDailyTask
    {
        public override void Execute()
        {
            Console.WriteLine("Getting ready for work");
            Thread.Sleep(100);
        }
    }
}
