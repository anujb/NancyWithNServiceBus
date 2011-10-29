using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;

namespace NancyWithNServiceBus.Messages
{
    [Serializable]
    public class Customer : IMessage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid Guid { get; set; }
        public DateTime? Active { get; set; }

        public Customer()
        {

        }
    }

    [Serializable]
    public class Customers : List<Customer>
    {
        public Customers()
        {
        }
    }
}
