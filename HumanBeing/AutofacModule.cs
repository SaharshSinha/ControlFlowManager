using Autofac;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace HumanBeing
{
    public class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            AssemblyName executingAssemblyName = Assembly.GetExecutingAssembly().GetName();
            string executingAssemblyPath = AppDomain.CurrentDomain.BaseDirectory;
            //Path.GetDirectoryName(executingAssemblyName.CodeBase);
            string coreAssemblyName = $"{executingAssemblyName.Name}.Core.Dll";

            string coreAssemblyPath = Path.Combine(executingAssemblyPath, coreAssemblyName); ;
            Assembly coreAssembly = Assembly.LoadFrom(coreAssemblyPath);

            builder
                .RegisterAssemblyTypes(coreAssembly)
                .AsImplementedInterfaces();
        }
    }
}
