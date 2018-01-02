using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace 临时项目
{
    class Program
    {
        static void Main(string[] args)
        {
            // 创建对象
            var course = new Course()
            {
                Name = "C#快速入门",
                Blogs = new Blog[]
                {
                    new Blog
                    {
                        Title= "序列化",
                        Content = "C#序列化内容"
                    },
                    new Blog
                    {
                        Title="Linq",
                        Content= "如何使用Linq"
                    }
                }
            };


            // 序列化,object->xml
            var ser = new XmlSerializer(typeof(Course));
            var writer = new StringWriter();
            ser.Serialize(writer, course);
            File.WriteAllText("course.xml", writer.ToString(), Encoding.Unicode);

            // 反序列化，xml->object
            var fileStream = new FileStream("course.xml", FileMode.Open);
            var course1 = ser.Deserialize(fileStream);

            // 序列化,object->json
            var json = JsonConvert.SerializeObject(course);
            Console.WriteLine(json);

            // 反序列化,json->object
            var course2 = JsonConvert.DeserializeObject<Course>(json);
            Console.ReadLine();
        }
    }
}
