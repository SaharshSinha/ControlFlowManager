using Autofac;
using ControlFlowManager.Declarations;
using HumanBeing.Core.Definitions.DailyTasks;
using HumanBeing.Declarations;
using Xunit;

namespace ControlFlowManager.Tests
{
    public class DailyRoutineTests : TestsBase
    {


        public DailyRoutineTests()
        {
            var builder = new Autofac.ContainerBuilder();
            Initialize(builder);
            Autofac.IContainer container = builder.Build();
            _dailyTaskSchedule = container.Resolve<IControlFlowScheduler<IDailyTask>>();
        }

        IControlFlowScheduler<IDailyTask> _dailyTaskSchedule;

        [Fact(DisplayName = "Infant Routine")]
        public void TestInfantRoutine()
        {


            _dailyTaskSchedule.Initialize()

                .Then()
                    .Do<TheWakeUp>()
                .Then()
                    .Do<TheBreakfast>()
                .Then()
                    .Do<TheSleep>();

            _dailyTaskSchedule.Execute();
        
        
        }

        [Fact(DisplayName = "Teenager Routine")]
        public void TestTeenagerRoutine()
        {


            _dailyTaskSchedule.Initialize()

                .Then()
                    .Do<TheWakeUp>()
                .Then()
                    .Do<TheBreakfast>()
                .Then()
                    .Do<TheSchool>()
                    .Do<TheFriendships>()
                .Then()
                    .Do<TheSleep>();

            _dailyTaskSchedule.Execute();


        }

        [Fact(DisplayName = "The Responsible Adult Routine")]
        public void TestResponsibleAdultRoutine()
        {
            _dailyTaskSchedule.Initialize()

                .Then()
                    .Do<TheWakeUp>()
                .Then()
                    .Do<TheBreakfast>()
                .Then()
                    .Do<TheDressUpForWork>()
                .Then()
                    .Do<TheSleep>();

            _dailyTaskSchedule.Execute();
        }
    }
}
