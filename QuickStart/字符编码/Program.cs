using System;
using System.IO;
using System.Text;

namespace 字符编码
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建文件，设置编码保存
            string content = "编码";
            string path = @"e:\output.txt";
            // 更多的编码支持，需要先注册
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            //定义编码
            var utf8 = Encoding.UTF8;
            var gbk = Encoding.GetEncoding("GBK");

            Console.OutputEncoding = utf8;
            //以GBK编码保存文件
            File.WriteAllText(path, content, gbk);
            //读取文件内容
            string readContent = File.ReadAllText(path, gbk);

            // 不同编码的bytes输出
            // 1 源字符转字节
            var gbkBytes = gbk.GetBytes(readContent);
            Console.WriteLine("源文件字节");
            Print(gbkBytes);// 177 224 194 235
            // 2 编码转换，转换字节到新编码形式
            var utf8Bytes = Encoding.Convert(gbk, utf8, gbkBytes);
            // 3 将新字节还原到目标编码
            var utfContent = Encoding.UTF8.GetString(utf8Bytes);
            Console.WriteLine("utf8的字节:");
            Print(Encoding.UTF8.GetBytes(utfContent));// 231 188 150 231 160 129

            // 直接读字节
            var binary = File.ReadAllBytes(path);
            Print(binary);
        }



        /// <summary>
        /// 输出字节形式
        /// </summary>
        /// <param name="bytes"></param>
        static void Print(byte[] bytes)
        {
            foreach (var item in bytes)
            {
                Console.Write(item);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}
