using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace database
{
    class Program
    {
        static MyDatabase _context = MyDatabase.GetInstance();

        static void Main(string[] args)
        {

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.None,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            };


            Select();
            Console.WriteLine("完成");
        }

        /// <summary>
        /// 添加
        /// </summary>
        static void Add()
        {
            // 创建用户
            var user = new User
            {
                Name = "NilTor",
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
                .Include(m => m.Blog)
                .ToList();

            File.WriteAllText("output.json", JsonConvert.SerializeObject(data));
        }

    }
}
