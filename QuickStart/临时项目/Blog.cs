using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace 临时项目
{

    /// <summary>
    /// 博客对象
    /// </summary>
    public class Blog : Model
    {
        /// <summary>
        /// 标题
        /// </summary>
        [MaxLength(32)]
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [MaxLength(2000)]
        public string Content { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public User Author { get; set; }
    }
}
