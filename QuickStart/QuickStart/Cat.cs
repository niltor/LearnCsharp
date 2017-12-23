using System;
using System.Collections.Generic;
using System.Text;

namespace QuickStart
{
    class Cat : Animal
    {

        public string Eye { get; set; }

        public Cat()
        {
            Name = "猫";
        }

        public void Sleep()
        {
            Console.WriteLine($"{Name}在睡觉");
        }

        /// <summary>
        /// 改写父类的Eat方法
        /// </summary>
        /// <param name="sth"></param>
        public override void Eat(string sth="食物")
        {
            if (sth== "甜食")
            {
                Console.WriteLine($"喵星不吃甜食");
            }
            else
            {
                base.Eat(sth);
            }
        }
    }
}
