using GarphQL.tutorial.Data;
using GarphQL.tutorial.Models;

using HotChocolate;
using HotChocolate.Data;

using System.Linq;

namespace GarphQL.tutorial.GraphQL
{
    public class QueryTest
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context)
        {
            return context.TPlatforms;
        }
        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        public IQueryable<Command> GetCommand([ScopedService] AppDbContext context)
        {
            return context.TCommands;
        }

    }
}
