using GarphQL.tutorial.Models;

using HotChocolate;
using HotChocolate.Types;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarphQL.tutorial.GraphQL
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Platform OnPlatformAdded([EventMessage] Platform platforms)
        {
            return platforms;
        }
    }
}
