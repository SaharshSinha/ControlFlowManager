using HumanBeing.Declarations;
using System;

namespace HumanBeing.Core.Definitions.SchoolTasks
{
    public class TheScienceClass : TaskBase, ISchoolTask
    {
        public override void Execute()
        {
            Console.WriteLine($"{GetType().Name} \t If we knew what we were doing, it wouldn't be called research");
        }
    }
}
