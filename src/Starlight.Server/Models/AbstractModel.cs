using System;

namespace Starlight.Server.Models
{
    public abstract class AbstractModel
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset ModifiedAt { get; set; }
    }
}
