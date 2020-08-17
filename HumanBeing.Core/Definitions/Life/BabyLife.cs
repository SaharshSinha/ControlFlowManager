using ControlFlowManager.Declarations;
using HumanBeing.Core.Definitions.DailyTasks;
using HumanBeing.Declarations;

namespace HumanBeing.Core.Definitions.Life
{
    public class BabyLife : ILife
    {
        private readonly IControlFlowScheduler<IDailyTask> _dailySchedule;
        public BabyLife(IControlFlowScheduler<IDailyTask> dailyTaskSchedule)
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
                    .Do<TheSleep>();

            _dailySchedule.Execute();
        }
    }
}
