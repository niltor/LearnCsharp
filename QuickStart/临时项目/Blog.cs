using System.Xml.Serialization;

namespace 临时项目
{
    /// <summary>
    /// 博文
    /// </summary>
    public class Blog
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        //[XmlIgnore]
        public string Content { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        [XmlAttribute(AttributeName = "author")]
        public string Author { get; set; } = "NilTor";
    }
}