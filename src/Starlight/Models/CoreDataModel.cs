using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Models
{
    public class CoreDataModel : CoreModel
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset ModifiedAt { get; set; }
    }
}
