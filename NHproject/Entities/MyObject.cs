using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NHproject.Entities
{
    public class MyObject
    {
        public MyObject()
        {
        }

        public virtual Guid Id { get; set; }

        public virtual string Code { get; set; }

        public virtual string Description { get; set; }

        public virtual byte[] Version { get; set; }
    }
}
