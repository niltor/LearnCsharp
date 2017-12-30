using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace 临时项目
{
    class Program
    {
        static void Main(string[] args)
        {
            // webclient 的简单使用
            using (var wc = new WebClient())
            {
                // 设置编码
                wc.Encoding = Encoding.UTF8;
                // 请求内容
                var result = wc.DownloadString("https://www.baidu.com");
                // 保存到文件
                File.WriteAllText("baidu.html", result);
            }

            // httpClient 请求

            using (var hc = new HttpClient())
            {
                // get请求
                hc.GetAsync("https://www.baidu.com");

                // post请求,构造不同类型的请求内容
                var data = new List<KeyValuePair<string, string>> {
                    new KeyValuePair<string, string>("",""),

                };
                var content = new FormUrlEncodedContent(data);
                hc.PostAsync("https://www.baidu.com", content);

            }

        }

    }
}
