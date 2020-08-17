using HumanBeing.Declarations;
using System;

namespace HumanBeing.Core.Definitions.DailyTasks
{
    public class TheActualWorkFromWork : TaskBase, IDailyTask
    {
        public override void Execute()
        {
            Console.WriteLine("Love the job!");
        }
    }
}
