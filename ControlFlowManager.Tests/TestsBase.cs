using Autofac;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ControlFlowManager.Tests
{
    public class TestsBase
    {
        public void Initialize(ContainerBuilder builder)
        {
            var dataAccess = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(dataAccess)
                .AsImplementedInterfaces();
        }
    }
}
