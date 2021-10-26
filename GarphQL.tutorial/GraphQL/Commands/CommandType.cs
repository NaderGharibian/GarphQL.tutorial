using GarphQL.tutorial.Data;
using GarphQL.tutorial.Models;

using HotChocolate;
using HotChocolate.Types;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarphQL.tutorial.GraphQL.Commands
{
    public class CommandType:ObjectType<Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor.Description("Respresents any executable command");
            descriptor
                    .Field(c => c.Platform)
                    .ResolveWith<Resolvers>(c => c.GetPlatform(default!, default!))
                    .UseDbContext<AppDbContext>()
                    .Description("This is the platform to which the command belongs");

        }
        private class Resolvers
        {
            public Platform GetPlatform([Parent]Command command,[ScopedService] AppDbContext context)
            {
                return context.TPlatforms.FirstOrDefault(p => p.Id == command.PlatformId);
            }
        }
    }
}
