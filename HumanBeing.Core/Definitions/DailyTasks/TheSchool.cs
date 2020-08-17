using ControlFlowManager.Declarations;
using HumanBeing.Core.Definitions.SchoolTasks;
using HumanBeing.Declarations;
using System;
using System.Threading;

namespace HumanBeing.Core.Definitions.DailyTasks
{
    public class TheSchool : TaskBase, IDailyTask
    {
        private readonly IControlFlowScheduler<ISchoolTask> _schoolTasksScheduler;
        public TheSchool(IControlFlowScheduler<ISchoolTask> schoolTasksScheduler)
        {
            _schoolTasksScheduler = schoolTasksScheduler;
        }
        public override void Execute()
        {
            Console.WriteLine("We're in a cool school!");

            _schoolTasksScheduler.Initialize()

                .Then()
                    .Do<TheBusRideToSchool>()
                .Then()
                    .Do<TheMathClass>()
                .Then()
                    .Do<TheScienceClass>()
                .Then()
                    .Do<TheLunchBreak>()
                .Then()
                    .Do<TheMusicClass>()
                .Then()
                    .Do<TheBusRideToHome>();

            _schoolTasksScheduler.Execute();

            Thread.Sleep(100);
        }
    }
}
