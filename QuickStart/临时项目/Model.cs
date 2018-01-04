using System;
using System.Collections.Generic;
using System.Text;

namespace 临时项目
{
    public class Model
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedTime { get; set; } = DateTime.Now;
    }
}
