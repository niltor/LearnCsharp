using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace 临时项目
{
    class Program
    {
        static MyContext _context = MyContext.GetContext();

        static void Main(string[] args)
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.None,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            };

            //Add();
            Select();
            Console.WriteLine("完成");
            Console.ReadLine();
        }

        /// <summary>
        /// 添加
        /// </summary>
        static void Add()
        {
            // 创建用户
            var user = new User
            {
                Email = "abc@outlook.com",
                Name = "NilTor",
                Password = "123123"
            };
            // 添加数据
            var blogs = new List<Blog>()
            {
                new Blog
                {
                    Author = user,
                    Title = "博客",
                    Content = "内容"
                },
                new Blog
                {
                    Author = user,
                    Title = "标题2",
                    Content = "博客内容2"
                }
            };

            _context.Add(user);
            _context.AddRange(blogs);
            var re = _context.SaveChanges();
            Console.WriteLine(re);
        }

        /// <summary>
        /// 查询
        /// </summary>
        static void Select()
        {
            var data = _context.User
                .Include(m => m.Blogs)
                .ToList();

            Console.WriteLine(JsonConvert.SerializeObject(data));
        }
    }
}
