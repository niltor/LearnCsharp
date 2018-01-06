using System;
using System.Collections.Generic;
using System.Text;

namespace database
{
    public class Model
    {
        public Guid Id { get; set; }

        public DateTime CreatedTime { get; set; } = DateTime.Now;
    }
}
