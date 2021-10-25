using GarphQL.tutorial.Data;
using GarphQL.tutorial.Models;

using HotChocolate;
using HotChocolate.Types;

using System.Linq;

namespace GarphQL.tutorial.GraphQL.Platforms
{

    public class PlatformType : ObjectType<Platform>
    {
        protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
        {
            descriptor.Description("Represents any software or service that has a command line interface.");
            descriptor
                 .Field(p => p.LicenseKey).Ignore();

            descriptor
                .Field(p => p.Commands)
                .ResolveWith<Resolvers>(p => p.GetCommands(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("This is the list of availabe commands for this platform");
        }
        private class Resolvers
        {
            public IQueryable<Command> GetCommands(Platform platform, [ScopedService] AppDbContext context)
            {
                return context.TCommands.Where(p => p.PlatformId == platform.Id);
            }
        }
    }

}
