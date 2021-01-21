using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Linq示例
{
    class Program
    {
        static void Main(string[] args)
        {
            CitySample();
            Console.ReadLine();
        }


        static void CitySample()
        {
            // 读取文件
            var json = File.ReadAllText("./citys.json");
            var provinces = JsonSerializer.Deserialize<List<Province>>(json);

            // 查询一共有多少个市区
            var count = provinces.Select(p => p.City.Count()).Sum();
            Console.WriteLine("地市共有:" + count);
            count = provinces.SelectMany(p => p.City.Select(c => c.Area.Count())).Sum();
            Console.WriteLine("区县共有:" + count);

            // 根据市数量排序

            // 分组 区/市/县
        }

        static void Sample()
        {
            #region 对象实例Linq
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
            var topClass = students.GroupBy(s => s.Class)
                .Select(s =>
                {
                    return new
                    {
                        Class = s.Key,
                        Average = s.Average(a => a.Score.Chinese + a.Score.Math + a.Score.English)
                    };
                }).OrderByDescending(m => m.Average)
                .First();
            Console.WriteLine("最高班级:" + topClass.Class + ";平均分:" + topClass.Average);


            // 筛选出有分数小于80分的学生，按班分组
            var hardStudents = students.Where(m => needImprove(m.Score))
             .GroupBy(m => m.Class)
             .ToList();

            // 输出每班内小于80分的同学
            foreach (var group in hardStudents)
            {
                Console.WriteLine(group.Key + "有低于80分学生" + group.Count() + "名:");
                foreach (var item in group)
                {
                    Console.Write(item.Name + " ");
                }
                Console.WriteLine();
            }

            // 内部方法，判断是否有小于80分的学科
            bool needImprove(Score score)
            {
                if (score.English < 80 || score.Chinese < 80 || score.Math < 80)
                    return true;
                return false;
            }
            #endregion
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <returns></returns>
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


        /// <summary>
        /// 输出数组
        /// </summary>
        /// <param name="obj"></param>
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
