using System;

namespace EFproject.Entities
{
    public partial class MyObject
    {
        public Guid Id { get; set; }
        public byte[] Version { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
