using HumanBeing.Declarations;
using System;

namespace HumanBeing.Core.Definitions.DailyTasks
{
    public class TheCardioWorkout : TaskBase, IDailyTask
    {
        public override void Execute()
        {
            Console.WriteLine("Cardio!");
        }
    }
}
