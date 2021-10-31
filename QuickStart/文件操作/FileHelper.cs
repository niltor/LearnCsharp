using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 文件操作
{
    public class FileHelper
    {
        public FileHelper()
        {
        }

        public async Task ReadFileAsync(string filePath)
        {
            var bytes = await File.ReadAllBytesAsync(filePath);
            bytes.ToList().ForEach(x =>
            {
                Console.Write($"{x:X2}" + " ");
            });
            Console.WriteLine("EOF");
        }

        public async Task ReadBytes(string filePath)
        {
            var bytes = await File.ReadAllBytesAsync(filePath);

            foreach (var item in bytes)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("EOF");
        }


        /// <summary>
        /// 向文件中插入字节
        /// </summary>
        /// <param name="original"></param>
        /// <param name="content"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public async Task InsertInformationAsync(string original, string content, int offset)
        {
            // 获取源文件信息，构造输出文件名
            var file = new FileInfo(original);
            var outputFile = file.Name + "_sec" + file.Extension;

            // 读取文件字节
            var bytes = await File.ReadAllBytesAsync(original);
            // 以utf8编码读取字节
            var insertBytes = Encoding.UTF8.GetBytes(content);

            var outputBytes = bytes.ToList();
            outputBytes.InsertRange(offset, insertBytes);

            File.WriteAllBytes(outputFile, outputBytes.ToArray());
        }


    }
}
