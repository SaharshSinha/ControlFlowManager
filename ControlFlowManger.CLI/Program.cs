using Autofac;
using ControlFlowManager.Core.Definitions;
using ControlFlowManager.Declarations;
using HumanBeing.Core.Definitions.DailyTasks;
using HumanBeing.Core.Definitions.SchoolTasks;
using HumanBeing.Declarations;
using System;
using System.Reflection;

namespace ControlFlowManger.CLI
{
    class Program
    {
        static IControlFlowScheduler<IDailyTask> _dailyTaskSchedule;
        
        static void Main(string[] args)
        {

            var builder = new Autofac.ContainerBuilder();
            Initialize(builder);
            Autofac.IContainer container = builder.Build();
            _dailyTaskSchedule = container.Resolve<IControlFlowScheduler<IDailyTask>>();

            BeAnInfant(_dailyTaskSchedule);

            Console.ReadLine();
        }

        private static void BeAnInfant(IControlFlowScheduler<IDailyTask> dailyTaskSchedule)
        {
            dailyTaskSchedule.Initialize()
                .Then()
                    .Do<TheWakeUp>()
                .Then()
                    .Do<TheBreakfast>()
                .Then()
                    .Do<TheSleep>();

            dailyTaskSchedule.Execute();
        }

        public static void Initialize(ContainerBuilder builder)
        {
            RegisterDailyTasks(builder);
            RegisterSchoolTasks(builder);

            builder
                .RegisterType<ControlFlowScheduler<IDailyTask>>()
                .As<IControlFlowScheduler<IDailyTask>>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<ControlFlowThener<IDailyTask>>()
                .As<IControlFlowStepThener<IDailyTask>>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<ControlFlowDoer<IDailyTask>>()
                .As<IControlFlowDoer<IDailyTask>>()
                .InstancePerLifetimeScope();



            builder
                .RegisterType<ControlFlowScheduler<ISchoolTask>>()
                .As<IControlFlowScheduler<ISchoolTask>>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<ControlFlowThener<ISchoolTask>>()
                .As<IControlFlowStepThener<ISchoolTask>>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<ControlFlowDoer<ISchoolTask>>()
                .As<IControlFlowDoer<ISchoolTask>>()
                .InstancePerLifetimeScope();
        }

        private static void RegisterSchoolTasks(ContainerBuilder builder)
        {
            builder.RegisterType<TheBusRideToHome>().As<ISchoolTask>();
            builder.RegisterType<TheBusRideToSchool>().As<ISchoolTask>();
            builder.RegisterType<TheLunchBreak>().As<ISchoolTask>();
            builder.RegisterType<TheMathClass>().As<ISchoolTask>();
            builder.RegisterType<TheMusicClass>().As<ISchoolTask>();
            builder.RegisterType<TheScienceClass>().As<ISchoolTask>();
        }

        private static void RegisterDailyTasks(ContainerBuilder builder)
        {
            builder.RegisterType<TheActualWorkFromWork>().As<IDailyTask>();
            builder.RegisterType<TheBreakfast>().As<IDailyTask>();
            builder.RegisterType<TheCardioWorkout>().As<IDailyTask>();
            builder.RegisterType<TheDressUpForWork>().As<IDailyTask>();
            builder.RegisterType<TheDriveToWork>().As<IDailyTask>();
            builder.RegisterType<TheFriendships>().As<IDailyTask>();
            builder.RegisterType<TheHIITWorkout>().As<IDailyTask>();
            builder.RegisterType<TheListeningToTheRadio>().As<IDailyTask>();
            builder.RegisterType<TheSchool>().As<IDailyTask>();
            builder.RegisterType<TheSleep>().As<IDailyTask>();
            builder.RegisterType<TheWakeUp>().As<IDailyTask>();

        }

        public static void TestInfantRoutine()
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
    }
}
