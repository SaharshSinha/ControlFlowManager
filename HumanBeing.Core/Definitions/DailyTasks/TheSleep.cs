using HumanBeing.Declarations;
using System;

namespace HumanBeing.Core.Definitions.DailyTasks
{
    public class TheSleep : TaskBase, IDailyTask
    {
        public override void Execute()
        {
            Console.WriteLine("Falling Asleep");
        }
    }
}
