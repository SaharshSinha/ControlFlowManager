using HumanBeing.Declarations;
using System;

namespace HumanBeing.Core.Definitions.DailyTasks
{
    public class TheAwesomeJobYouDo : TaskBase, IDailyTask
    {
        public override void Execute()
        {
            Console.WriteLine("This is awesome!");
        }
    }
}
