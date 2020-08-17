using HumanBeing.Declarations;
using System;

namespace HumanBeing.Core.Definitions.DailyTasks
{
    public class TheHIITWorkout : TaskBase, IDailyTask
    {
        public override void Execute()
        {
            Console.WriteLine("My heart beats like a drum every other minute");
        }
    }
}
