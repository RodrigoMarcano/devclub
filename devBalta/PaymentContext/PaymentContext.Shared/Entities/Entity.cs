using System;

namespace PaymentContext.Shared.Entities
{
    public abstract class Entity
    {
        protected Entity()
        {
            ID = Guid.NewGuid();
        }

        public Guid ID { get; private set; }
    }
}