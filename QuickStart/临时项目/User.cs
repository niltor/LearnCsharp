using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace 临时项目
{
    /// <summary>
    /// 用户
    /// </summary>
    public class User : Model
    {
        /// <summary>
        /// 邮箱地址
        /// </summary>
        [MaxLength(128)]
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [DataType(DataType.Password)]
        public string Password { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [MaxLength(32)]
        public string Name { get; set; }

        public List<Blog> Blogs { get; set; }
    }
}
