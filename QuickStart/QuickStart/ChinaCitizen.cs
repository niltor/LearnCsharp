using System;
using System.Collections.Generic;
using System.Text;

namespace QuickStart
{
    /// <summary>
    /// 中国公民
    /// </summary>
    public class ChinaCitizen : IChina
    {
        public void VisitChinaInternet()
        {
            Console.WriteLine("访问国内互联网，无法访问google!");
        }

        public void VisitInternet()
        {
            Console.WriteLine("访问国际互联网");
        }
    }
}
