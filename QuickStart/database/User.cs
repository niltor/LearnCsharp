using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace database
{
    public class User : Model
    {
        [MaxLength(32)]
        public string Name { get; set; }

        public List<Blog> Blog { get; set; }
    }
}
