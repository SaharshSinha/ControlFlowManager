using ControlFlowManager.Declarations;
using HumanBeing.Core.Definitions.DailyTasks;
using HumanBeing.Declarations;
using System;

namespace HumanBeing.Core.Definitions.Life
{
    public class YoungAdultLife : ILife
    {
        private readonly IControlFlowScheduler<IDailyTask> _dailySchedule;
        public YoungAdultLife(IControlFlowScheduler<IDailyTask> dailyTaskSchedule)
        {
            _dailySchedule = dailyTaskSchedule;
        }
        public void LiveIt()
        {
            Console.WriteLine("Livin' it");
            _dailySchedule.Initialize()

                .Then()
                    .Do<TheWakeUp>()
                .Then()
                    .Do<TheCardioWorkout>()
                    .Do<TheCatchingUpWithNews>()
                .Then()
                    .Do<TheBreakfast>()
                .Then()
                    .Do<TheDressUpForWork>()
                .Then()
                    .Do<TheDriveToWork>()
                    .Do<TheListeningToTheRadio>()
                .Then()
                    .Do<TheAwesomeJobYouDo>()
                .Then()
                    .Do<TheDriveHome>()
                .Then()
                    .Do<TheDinner>()
                .Then()
                    .Do<TheSleep>();

            _dailySchedule.Execute();

            Console.WriteLine("Lived it");
        }
    }
}
