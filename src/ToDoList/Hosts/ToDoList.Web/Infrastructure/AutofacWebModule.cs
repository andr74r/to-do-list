﻿using Autofac;
using AutoMapper;
using ToDoList.Issue.Core.Infrastructure;
using ToDoList.Issue.Data.Memory.Infrastructure;
using ToDoList.Security.Core.Infrastructure;
using ToDoList.Security.Data.Memory.Infrastructure;

namespace ToDoList.Web.Infrastructure
{
    public class AutofacWebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(ctx => MapperFactory.CreateMapper()).As<IMapper>();

            builder.RegisterModule(new AutofacIssueDataMemoryModule());

            builder.RegisterModule(new AutofacIssueModule());

            builder.RegisterModule(new AutofacSecurityCoreModule());

            builder.RegisterModule(new AutofacSecurityDataMemoryModule());
        }
    }
}
