using System;

namespace ApiGraph.Entities
{
    public class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id {get; private set;}

        
    }
}