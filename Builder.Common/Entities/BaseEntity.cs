using System;
using System.Collections.Generic;
using System.Text;

namespace Builder.Common.Entities
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }

    }
}
