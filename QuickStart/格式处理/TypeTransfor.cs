using System;
using System.Collections.Generic;
using System.Text;

namespace 格式处理
{
    public class TypeTransfor : ICourseCode
    {
        public void Run()
        {
            double b = 13.5 ;

            //显示转化
            var b1 = (int)b;
            //判断类型
            if (b1 is int)
            {
                Console.WriteLine("(int)b的类型为:" + b1.GetType().Name + ",值为:" + b1);
            }
            else
            {
                Console.WriteLine($"{b}=>{b1}");
            }

            //字符串转数字 
            Console.WriteLine(int.Parse("14"));
            Console.WriteLine(double.Parse("13.5"));

            //使用Convert类
            Console.WriteLine(Convert.ToInt32("14"));
            Console.WriteLine(Convert.ToInt32(b));
            Console.WriteLine(Convert.ToDouble("13.5"));

        }
    }
}
