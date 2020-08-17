using ControlFlowManager.Declarations;
using HumanBeing.Core.Definitions.DailyTasks;
using HumanBeing.Declarations;

namespace HumanBeing.Core.Definitions.Life
{
    public class TeenageLife : ILife
    {
        private readonly IControlFlowScheduler<IDailyTask> _dailySchedule;
        public TeenageLife(IControlFlowScheduler<IDailyTask> dailyTaskSchedule)
        {
            _dailySchedule = dailyTaskSchedule;
        }
        public void LiveIt()
        {
            _dailySchedule.Initialize()

                .Then()
                    .Do<TheWakeUp>()
                .Then()
                    .Do<TheBreakfast>()
                .Then()
                    .Do<TheSchool>()
                    .Do<TheFriendships>()
                .Then()
                    .Do<TheDinner>()
                .Then()
                    .Do<TheSleep>();

            _dailySchedule.Execute();
        }
    }
}
