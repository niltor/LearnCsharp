using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using System;
using System.IO;
using System.Threading.Tasks;

namespace 文件操作
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // 读取文件信息
            var helper = new FileHelper();
            await helper.ReadFileAsync(Path.Combine("./asserts", "utf8.ccc"));
            await helper.ReadFileAsync(Path.Combine("./asserts", "BG2312.ccc"));

            await helper.ReadFileAsync(Path.Combine("./asserts", "black.png"));
            await helper.ReadFileAsync(Path.Combine("./asserts", "blackdot.png"));

            //await helper.ReadFileAsync(Path.Combine("./asserts", "black.jpg"));
            //await helper.ReadFileAsync(Path.Combine("./asserts", "blackdot.jpg"));


            await helper.InsertInformationAsync(Path.Combine("./asserts", "black.png"), "自由", 20);

        }
        static void Example()
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

                }
            }
            //生成操作记录
            File.WriteAllText(@"e:\images\output.txt", outputInfo);
            Console.WriteLine("完成任务");
        }
    }
}
