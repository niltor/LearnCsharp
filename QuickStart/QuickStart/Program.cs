using System;
namespace QuickStart
{
    class Program
    {
        static void Main(string[] args)
        {
            //LearnStringOutput();
            //LearnString();
            //LearnNumber();
            LearnBranchesAndLoops();
            Console.ReadLine();
        }

        /// <summary>
        /// 1. 字符串输入输出
        /// </summary>
        static void LearnStringOutput()
        {
            //1 字符串输出
            Console.WriteLine("Hello World!");
            //定义字符串类型变量
            string name = "NilTor";
            //2 带变量输出
            Console.WriteLine($"My name is {name}");
            //3 带格式输出
            Console.WriteLine($@"
Hello, welcome to msdev.cc!
My name is {name}.
What's your name?");

            //输入字符串
            string yourName = Console.ReadLine();
            Console.WriteLine($"Hello {yourName},nice to meet you!");
        }


        /// <summary>
        /// 字符串的常用操作
        /// </summary>
        static void LearnString()
        {
            string url = "https://msdev.cc";
            // 判断是否包含
            if (url.Contains("https"))
            {
                Console.WriteLine("这是一个https链接");
            }
            //字符串替换
            url = url.Replace("https", "ftp");
            Console.WriteLine($"新网址:{url}");

            //判断是否以某字符开头
            if (url.StartsWith("ftp"))
            {
                Console.WriteLine("这是ftp链接:" + url);
            }
        }

        /// <summary>
        /// 数字类型的使用
        /// </summary>
        static void LearnNumber()
        {
            //整型计算
            int x = 4;
            int y = 17;
            int fx = 2 * (x + y);
            Console.WriteLine(fx);

            //除法
            Console.WriteLine($"{y} 除以 2 = {y / 2},余{y % 2}");
            double fy = y / 2.0;
            Console.WriteLine($"{y} 除以 2.0 = {fy}");

            double fa = Math.Sqrt(8);
            Console.WriteLine($"8的开方为：{fa}");

            //输入类型范围
            Console.WriteLine($"int(整型)最大值 :{int.MaxValue} , 最小值 :{int.MinValue}");
            Console.WriteLine($"double(整型)最大值 :{double.MaxValue} , 最小值 :{double.MinValue}");

            //计算圆的面积
            double r = 2.4;
            double area = Math.PI * r * r;

            Console.WriteLine($"半径为{r}的圆的面积为:{area},约为:{Math.Round(area, 3)}");
        }

        /// <summary>
        /// 分支与循环
        /// </summary>
        static void LearnBranchesAndLoops()
        {
            //条件语句if
            int a = 1;
            if (a > 0)
            {
                Console.WriteLine("a大于0");
            }
            else
            {
                Console.WriteLine("a小于0");
            }

            //switch分支语句
            switch (a)
            {
                case 0:
                    Console.WriteLine("a等于0");
                    break;
                case 1:
                    Console.WriteLine("a大于0");
                    break;
                default:
                    Console.WriteLine("a小于0");
                    break;
            }

            //for循环
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            //foreach循环
            int[] numbers = new int[4];
            numbers[0] = 1;
            numbers[1] = 2;
            numbers[2] = 3;
            numbers[3] = 4;
            //int[] numbers = new int[] { 1,2,3,4};

            foreach (int item in numbers)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine();

            //while循环
            int j = 10;
            while (j > 0)
            {
                Console.Write(j + " ");
                j--;//i=i-1;
            }


        }

        /// <summary>
        /// 列表与集合
        /// </summary>
        static void Collections()
        {

        }
    }
}