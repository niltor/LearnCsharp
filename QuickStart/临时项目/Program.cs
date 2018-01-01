using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace 临时项目
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Console.WriteLine("程序运行");
            //DoSomethings(); //异步执行
            //await DoSomethings(); //同步，等待完成
            //Console.WriteLine("用户操作");
            //Console.ReadLine();

            // 先获取图片链接
            var links = GetImageLinks();
            // 记录用时
            var watch = new Stopwatch();

            var tasks = new List<Task>();
            // 计时开始
            watch.Start();
            // 下载图片
            foreach (var link in links)
            {
                tasks.Add(DownloadImageAsync(link));
            }
            // 等待所有任务执行完毕
            Task.WaitAll(tasks.ToArray());
            watch.Stop();
            Console.WriteLine("总共用时:" + watch.ElapsedMilliseconds / 1000.0 + "秒");
            Console.ReadLine();
        }

        /// <summary>
        /// 获取图片地址
        /// </summary>
        /// <returns></returns>
        static List<string> GetImageLinks()
        {
            var imageLinks = new List<string>();
            // 下载多个页面内容
            for (int page = 0; page < 5; page++)
            {
                using (var wc = new WebClient())
                {
                    // 获取网页内容
                    var xmlStr = wc.DownloadString("https://bing.ioliu.cn/?p=" + page);
                    // 解析html
                    var doc = new HtmlDocument();
                    doc.LoadHtml(xmlStr);

                    // 使用linq获取图片地址
                    var Links = doc.DocumentNode
                       .Descendants("div")
                       .Where(d => d.Attributes["class"].Value == "card progressive")
                       .Select(s =>
                       {
                           var link = s.Element("img").Attributes["src"].Value;
                           return link.Replace("400x240", "1920x1080");
                       })
                       // 去重
                       .Distinct()
                       .ToList();
                    imageLinks.AddRange(Links);
                }
            }

            return imageLinks.Distinct().ToList();
        }

        /// <summary>
        /// 下载图片
        /// </summary>
        /// <param name="link"></param>
        static async Task DownloadImageAsync(string link)
        {
            // 构造文件名称和路径
            string fileName = link.Substring(link.LastIndexOf("/") + 1);
            string fullPath = Path.Combine(@"e:\images", fileName);

            using (var wc = new WebClient())
            {
                try
                {
                    // 下载图片
                    await wc.DownloadFileTaskAsync(new Uri(link), fullPath);
                    Console.WriteLine("下载" + fileName + "完成");
                }
                catch (Exception)
                {
                    Console.WriteLine("保存出错：" + fullPath);
                }
            }
        }

        static async Task<string> DoSomethings()
        {
            Console.WriteLine("开始获取数据...");
            // 进行网络请求，通常是费时操作
            using (var wc = new WebClient())
            {
                var result = await wc.DownloadStringTaskAsync("https://www.baidu.com");
                Console.WriteLine("获取成功");
                return "";
            }
        }
    }
}
