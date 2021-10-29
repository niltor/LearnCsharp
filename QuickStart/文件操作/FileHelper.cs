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


        public async Task InsertInformationAsync(string original, string content, int offset)
        {
            var file = new FileInfo(original);
            var outputFile = file.Name + "_sec" + file.Extension;
            var bytes = await File.ReadAllBytesAsync(original);
            var insertBytes = Encoding.UTF8.GetBytes(content);

            var outputBytes = bytes.ToList();
            outputBytes.InsertRange(bytes.Length - offset, insertBytes);
            File.WriteAllBytes(outputFile, outputBytes.ToArray());
        }


    }
}
