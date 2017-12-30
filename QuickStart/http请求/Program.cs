using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace http请求
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
                string result = "";
                var httpResponse = new HttpResponseMessage();

                // get请求
                httpResponse = hc.GetAsync("https://www.baidu.com").Result;
                result = httpResponse.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);

                // post请求,构造不同类型的请求内容
                var data = new List<KeyValuePair<string, string>> {
                    new KeyValuePair<string, string>("from","msdev.cc"),
                };
                // 封闭成请求结构体
                var content = new FormUrlEncodedContent(data);
                // 进行请求,获取返回数据
                httpResponse = hc.PostAsync("https://msdev.cc", content).Result;
                // 将返回数据作为字符串
                result = httpResponse.Content.ReadAsStringAsync().Result;

                File.WriteAllText("post.html", result);
            }

            // 自定义请求及结果处理
            using (var hc = new HttpClient())
            {
                string result = "";
                var httpRequest = new HttpRequestMessage();
                var httpResponse = new HttpResponseMessage();
                // 请求方法
                httpRequest.Method = HttpMethod.Put;
                // 请求地址
                httpRequest.RequestUri = new Uri("https://msdev.cc");
                // 请求内容
                httpRequest.Content = new StringContent("request content");
                // 设置请求头内容
                httpRequest.Headers.TryAddWithoutValidation("", "");
                // 设置超时
                hc.Timeout = TimeSpan.FromSeconds(5);
                // 获取请求结果 
                httpResponse = hc.SendAsync(httpRequest).Result;
                // 判断请求结果
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    result = httpResponse.Content.ReadAsStringAsync().Result;
                    File.WriteAllText("custom.html", result);
                }
                else
                {
                    Console.WriteLine(httpResponse.StatusCode + httpResponse.RequestMessage.ToString());
                }
            }
        }
    }
}
