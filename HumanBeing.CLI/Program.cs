using Autofac;
using ControlFlowManager.Core.Definitions;
using ControlFlowManager.Declarations;
using HumanBeing.Core.Definitions.DailyTasks;
using HumanBeing.Core.Definitions.Life;
using HumanBeing.Core.Definitions.SchoolTasks;
using HumanBeing.Declarations;
using System;

namespace HumanBeing.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            Initialize(builder);
            IContainer container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var life = scope.Resolve<ILife>();
                life.LiveIt();
            }
            Console.WriteLine("Press enter");
            Console.ReadLine();
        }

        public static void Initialize(ContainerBuilder builder)
        {
            builder
                .RegisterType<YoungAdultLife>()
                .As<ILife>()
                .InstancePerLifetimeScope();

            RegisterDailyTasks(builder);
            RegisterSchoolTasks(builder);

            builder
                .RegisterType<ControlFlowScheduler<IDailyTask>>()
                .As<IControlFlowScheduler<IDailyTask>>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<ControlFlowThenDoer<IDailyTask>>()
                .As<IControlFlowStepThenDoer<IDailyTask>>()
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
                .RegisterType<ControlFlowThenDoer<ISchoolTask>>()
                .As<IControlFlowStepThenDoer<ISchoolTask>>()
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


            builder.RegisterType<TheCatchingUpWithNews>().As<IDailyTask>();
            builder.RegisterType<TheAwesomeJobYouDo>().As<IDailyTask>();
            builder.RegisterType<TheDriveHome>().As<IDailyTask>();
            builder.RegisterType<TheDinner>().As<IDailyTask>();


        }
    }
}
