using HumanBeing.Declarations;
using System;
using System.Threading;

namespace HumanBeing.Core.Definitions.DailyTasks
{
    public class TheFriendships : TaskBase, IDailyTask
    {
        public override void Execute()
        {
            Console.WriteLine("Friends are the best!");
            Thread.Sleep(200);
        }
    }
}
