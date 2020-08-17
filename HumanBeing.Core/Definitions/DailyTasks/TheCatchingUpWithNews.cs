using HumanBeing.Declarations;
using System;

namespace HumanBeing.Core.Definitions.DailyTasks
{
    public class TheCatchingUpWithNews : TaskBase, IDailyTask
    {
        public override void Execute()
        {
            Console.WriteLine("Today's news: Non carbon based life found on europa - check out their daily routines");
        }
    }
}
