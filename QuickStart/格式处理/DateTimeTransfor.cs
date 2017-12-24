using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace 格式处理
{
    class DateTimeTransfor : ICourseCode
    {
        public void Run()
        {
            //日期格式处理
            //创建时间
            var dateTime = DateTime.Now;//当前日期
            Console.WriteLine("当前时间:" + dateTime.ToString());

            //字符串转化到日期
            //标准格式的转化
            string date = "2017/11/12";
            Console.WriteLine(DateTime.Parse(date).ToString());

            date = "2017-12-12 13:22:20";
            Console.WriteLine(DateTime.Parse(date).ToString());

            //自定义格式转化
            //链接：https://docs.microsoft.com/zh-cn/dotnet/standard/base-types/custom-date-and-time-format-strings
            date = "12月20号,下午3点";
            Console.WriteLine(DateTime.ParseExact(date, "MM月dd号,tth点", CultureInfo.CreateSpecificCulture("zh-cn")));

            //日期计算
            //三年前的今天是星期几？
            dateTime = dateTime.AddYears(-3);
            Console.WriteLine("三年前的今天是：" + dateTime.DayOfWeek);
            //ddd:周几  dddd:星期几
            Console.WriteLine("三年前的今天是:" + dateTime.ToString("dddd"));
        }
    }
}
