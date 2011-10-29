using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;

namespace NancyWithNServiceBus.SubscriberOne
{
    public class MessageEndPoint : IConfigureThisEndpoint, AsA_Server
    {
    }
}
