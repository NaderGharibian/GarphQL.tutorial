using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarphQL.tutorial.GraphQL.Commands
{
    public record AddCommandInput(string HowTo,string CommandLine, int PlatformId);
}
