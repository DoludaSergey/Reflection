using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyLibrary;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Type t;

            int i = 5;
            object o = i;

            t = o.GetType();
            byte[] tempB = {5, 8, 8, 4};
            string[] tempS = {"kjhgjgjg", "ljjlj"};

            SomeClass someClass = new SomeClass("sjjghgdf",5354,787,tempB,tempS);

            Visualisator vis=new Visualisator(someClass);

            vis.ShowProperties();

            //Console.WriteLine(t.SomeString);
            Console.ReadLine();


        }
    }
}
