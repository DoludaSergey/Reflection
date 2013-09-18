using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Reflection;

namespace MyLibrary
{
    public class SomeClass
    {

        public string SomeString { get; set; }
        public long SomeLongNumber { get; set; }
        public double SomeDoubleNumber { get; set; }
        public byte[] SomeBytes { get; set; }
        public string [] Strings { get; set; }
        //public bitmap Bitmap { get; set; }

        public SomeClass(string name,long lng,double dbl,byte[] bytes,string[] strings)
        {
            SomeString = name;
            SomeLongNumber = lng;
            SomeDoubleNumber = dbl;
            SomeBytes = bytes;
            Strings = strings;
        }

        private void SomePrivateMethod()
        {
            Console.WriteLine("Working private method!!!!");
        }
    }
}
