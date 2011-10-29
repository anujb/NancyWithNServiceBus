using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.ModelBinding;
using NancyWithNServiceBus.Messages;
using ServiceStack.Text;

namespace NancyWithNServiceBus.Web.Modules
{
    public class CustomerModule : NancyModule
    {
        public CustomerModule()
            : base("/customers")
        {
            Get["/"] = parameters => {
                var customers = GetCustomers();
                return Response.AsJson<IEnumerable<Customer>>(customers);
            };

            Post["/"] = parameters => {

                using (var body = this.Request.Body) {
                    var customers = JsonSerializer.DeserializeFromStream<Customer[]>(body);

                    if (customers.Any()) {
                        MvcApplication.Bus.Send(customers);
                    }
                }

                return HttpStatusCode.OK;
            };

        }

        private IEnumerable<Customer> GetCustomers()
        {
            var random = new Random(2309);
            return new string[] { "Executive Paradigm Design", "Internet Innovation Design", "Ace Information Guild", "Superior Computation Group", "Visual Innovation Megacorp", "Adept Automation Studios", "External Concepts Corporation", "Macro Server Advertising", "Corporate Outsourcing Business", "Canadian Trade Unlimited, Inc", "Advanced Computer Firm" }
                .Select(name => new Customer {
                    Id = random.Next(1, 10),
                    Guid = Guid.NewGuid(),
                    Name = name,
                    Active = DateTime.Now.AddDays(-random.Next(1, 300)).AddSeconds(-random.Next(1, 60)),
                });
        }
    }
}