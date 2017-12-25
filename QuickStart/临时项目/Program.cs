using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;
using System;
using System.IO;

namespace 临时项目
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 获取目录下所有文件信息
            var dirs = new DirectoryInfo(@"e:\images");//原目录
            var outDirs = Directory.CreateDirectory(@"e:\images\output");//输出目录
            var files = dirs.GetFiles("*.*");

            var outputInfo = "";//记录转化内容

            //2 遍历文件，压缩转化输出 
            int i = 1;
            foreach (var file in files)
            {
                //读入图片文件
                using (var img = Image.Load(file.FullName))
                {
                    //设置输出选项
                    Configuration.Default.SetEncoder(ImageFormats.Jpeg, new JpegEncoder()
                    {
                        Quality = 85,
                        IgnoreMetadata = true,
                    });
                    var newImg = img.Clone(ctx => ctx.Resize(new ResizeOptions
                    {
                        Size = new Size((int)(img.Width / 1.5), (int)(img.Height / 1.5)),
                        Mode = ResizeMode.BoxPad
                    }));

                    //构造新文件名称
                    var fileName = Path.Combine(outDirs.FullName, DateTime.Now.ToString("MMdd") + $"-myphotos{i}.jpg");
                    //保存副本到新文件
                    newImg.Save(fileName);
                    i++;
                    outputInfo += $"原文件:{file.FullName} => 新文件:{fileName}\r\n";
                    Console.WriteLine(outputInfo);
                }
            }
            //生成操作记录
            File.WriteAllText(@"e:\images\output.txt", outputInfo);
            Console.WriteLine("完成任务");
        }
    }
}
