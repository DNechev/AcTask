using System;

namespace AssecorTask.Domain
{
    public class BaseEntity
    {
        public DateTime CreationDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public Type InstanceType => GetType();
    }
}
