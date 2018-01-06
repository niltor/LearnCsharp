using System;
using System.Collections.Generic;
using System.Text;

namespace 序列化
{
    /// <summary>
    /// 课程类
    /// </summary>
    public class Course
    {
        /// <summary>
        /// 课程名称
        /// </summary>
        public string Name { get; set; }

        //[XmlElement(ElementName="Blog")]
        //[XmlArray("BlogList")]
        public Blog[] Blogs { get; set; }
    }

}