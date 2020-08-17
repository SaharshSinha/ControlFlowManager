using HumanBeing.Declarations;
using System;
using System.Threading;

namespace HumanBeing.Core.Definitions.DailyTasks
{
    public class TheDinner : TaskBase, IDailyTask
    {
        public override void Execute()
        {
            Console.WriteLine("Eating dinner");
            Thread.Sleep(300);
        }
    }
}
