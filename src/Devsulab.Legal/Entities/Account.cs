using Devsulab.Common;

namespace Devsulab.Legal.Entities
{
    public class Account : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string BillingState { get; set; }

    }
}

