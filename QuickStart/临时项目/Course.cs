using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace 临时项目
{
    /// <summary>
    /// 课程类
    /// </summary>
    [DataContract]
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
