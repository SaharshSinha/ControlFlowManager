using HumanBeing.Declarations;
using System;

namespace HumanBeing.Core.Definitions.SchoolTasks
{
    public class TheMusicClass : TaskBase, ISchoolTask
    {
        public override void Execute()
        {
            Console.WriteLine($"{GetType().Name} \t Talking about music is like dancing about architecture.");
        }
    }
}
