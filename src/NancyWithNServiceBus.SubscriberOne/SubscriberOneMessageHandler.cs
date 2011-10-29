using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;
using NancyWithNServiceBus.Messages;

namespace NancyWithNServiceBus.SubscriberOne
{
    public class SubscriberOneMessageHandler : IMessageHandler<Customer>
    {
        public IBus Bus { get; set; }


        public void Handle(Customer message)
        {
            Console.Out.WriteLine("Processed Message for Customer -- Id: {0} -- Name: {1} -- Guid: {2}",
                message.Id, message.Name, message.Guid);
        }
    }
}
