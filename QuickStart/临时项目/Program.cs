using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace 临时项目
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 简单数组示例
            var numbers = new int[] { 1, 31, 22, 4, 229, 84, 8, 23 };
            Console.WriteLine("原数组：");
            WriteArray(numbers);

            // 取最大值 
            int max = numbers.Max();
            Console.WriteLine("最大值为:" + max);

            // 取第三大的值
            int thirdMax = numbers.OrderByDescending(m => m)
                .Skip(2)
                .First();
            Console.WriteLine("第三大的数是" + thirdMax);

            // 取总和
            int sum = numbers.Sum();
            Console.WriteLine("总和为:" + sum);

            // 条件筛选，取所有奇数，并按从小到大排列
            var result = numbers.Where(n => n % 2 == 1)
                .OrderBy(m => m)
                .ToArray();

            Console.WriteLine("处理后的结果为:");
            WriteArray(result);

            #endregion

            #region 对象类型示例
            // 初始化数据
            var students = InitData();

            // 找出总分最高的学生
            var student = students.Select(s =>
            {
                return new
                {
                    Sum = s.Score.Chinese + s.Score.English + s.Score.Math,
                    s.Name
                };
            }).OrderByDescending(s => s.Sum)
            .First();
            Console.WriteLine("总分最高的学生是:" + student.Name + ";总分为:" + student.Sum);

            // 找出平均分最高的班级
            var re = students.GroupBy(s => s.Class)
                .Select(s =>
                {
                    return new
                    {
                        Average = s.Sum(m => m.Score.Chinese + m.Score.English + m.Score.Math) / s.Count(),
                        Class = s.Key
                    };
                })
                .OrderByDescending(m => m.Average);

            Console.WriteLine("最高班级:" + re.First().Class + ";平均分:" + re.First().Average);
            //单科成绩最高的人
            #endregion

        }


        static List<Student> InitData()
        {
            string[] names = { "张三", "王五", "李四", "赵二", "丁一", "李明", "韩梅", "梦琪", "忆柳", "之桃", "慕青", "问兰", "尔岚", "元香", "初夏" };
            var random = new Random();

            var students = new List<Student>();
            // 创建学生对象
            foreach (var name in names)
            {
                var student = new Student
                {
                    Name = name,
                    Class = random.Next(1, 4) + "班"
                };
                students.Add(student);
            }
            // 模拟学生考试成绩
            foreach (var student in students)
            {
                var score = new Score
                {
                    Chinese = random.Next(60, 101),
                    English = random.Next(60, 101),
                    Math = random.Next(60, 101)
                };
                student.Score = score;

                Console.WriteLine($"{student.Class}[{student.Name}]的成绩为:" +
                    $"数学:{score.Math};语文:{score.Chinese};英语:{score.English}" +
                    $"总分为:{score.Math + score.Chinese + score.English}");
            }

            return students;
        }

        private static object List<T>()
        {
            throw new NotImplementedException();
        }

        static void WriteArray(IEnumerable obj)
        {
            foreach (var item in obj)
            {
                Console.Write(item.ToString() + " ");
            }
            Console.WriteLine();
        }
    }
}
