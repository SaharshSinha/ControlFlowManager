using HumanBeing.Declarations;
using System;

namespace HumanBeing.Core.Definitions.DailyTasks
{
    public class TheListeningToTheRadio : TaskBase, IDailyTask
    {
        public override void Execute()
        {
            Console.WriteLine("Listening to a favorite radio station");
        }
    }
}
