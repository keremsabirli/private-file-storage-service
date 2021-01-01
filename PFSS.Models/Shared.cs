using System;
using System.Collections.Generic;
using System.Text;

namespace PFSS.Models
{
    public class Shared
    {
        public string Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
    }
}
