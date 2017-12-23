using System;
using System.Collections.Generic;
using System.Text;

namespace QuickStart
{
    /// <summary>
    /// 世界公民
    /// </summary>
    class EarthCitizen : IWorld
    {
        public void VisitInternet()
        {
            Console.WriteLine("访问国际互联网");
        }
    }
}
