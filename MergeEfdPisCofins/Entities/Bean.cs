using System;

namespace MergeEfdPisCofins.Entities
{
    public class Bean
    {
        public Bean() 
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
