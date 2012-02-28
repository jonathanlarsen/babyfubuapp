using System;

namespace BabyFubuApp.Domain
{
    public class DomainEntity
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
    }
}