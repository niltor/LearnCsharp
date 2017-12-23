using System;
using System.Collections.Generic;
using System.Text;

namespace QuickStart
{
    /// <summary>
    /// 动物类
    /// </summary>
    class Animal
    {

        public string Name { get; set; }
        public Animal()
        {

        }
        public Animal(string name)
        {
            Name = name;
        }

        public virtual void Eat(string sth = "食物")
        {
            Console.WriteLine($"{Name}吃{sth}");
        }

    }

}
