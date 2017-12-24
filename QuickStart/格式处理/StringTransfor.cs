using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace 格式处理
{
    class StringTransfor : ICourseCode
    {
        public void Run()
        {

            //字符串转义文档: https://docs.microsoft.com/zh-cn/dotnet/csharp/programming-guide/strings/#string-escape-sequences
            string output = "hello NilTor,\nWelcome to Msdev.cc!\n\tThank you!";
            Console.WriteLine(output);
            output = "\"类\"的概念";
            Console.WriteLine(output);

            Console.WriteLine("我的名字是{0}", "NilTor");
            output = String.Format("你好,{0}", "NilTor");
            Console.WriteLine(output);

            //字符串当做字符数组使用
            output = "零一二三四五";
            for (int i = 0; i < output.Length; i++)
            {
                Console.WriteLine(string.Concat(i, ":", output[i]));
            }

            //更加灵活的字符串处理 StringBuilder
            // 文档链接:https://docs.microsoft.com/zh-cn/dotnet/csharp/programming-guide/strings/#using-stringbuilder-for-fast-string-creation
            var sb = new StringBuilder("MilTor");
            //output[0] = "佰";  //只读不可更改
            sb[0] = 'N';
            sb.Append(". Nice to meet you");
            sb.Insert(0, "Hello ");
            Console.WriteLine(sb.ToString());

            //正则匹配
            //文档链接:https://docs.microsoft.com/zh-cn/dotnet/standard/base-types/regular-expression-language-quick-reference
            //1 判断格式
            string phone = "13890902211";
            string pattern = @"\b\d{11}\b";

            if (Regex.IsMatch(phone, pattern))
            {
                Console.WriteLine($"{phone} 符合手机格式");
            }
            else
            {
                Console.WriteLine($"{phone} 格式错误");
            }

            //2 匹配特定内容
            string sites = "我们官方网站的网址是:https://msdev.cc,欢迎访问";
            // 分组匹配
            pattern = @"://(?<websites>\w+\.\w+),";
            // 匹配
            var match = Regex.Match(sites, pattern);
            // 输出匹配的内容
            Console.WriteLine(match.Groups["websites"].Value);

        }
    }
}
