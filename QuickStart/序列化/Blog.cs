using System.Xml.Serialization;

namespace 序列化
{
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