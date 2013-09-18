using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;


namespace Reflection
{
    class Visualisator : UserControl
    {
        private object _someClass;
        private Type typeSomeClass;
        private int countArByte = 0;
        private int countArStr = 0;

        public Visualisator(object o)
        {
            this._someClass = o;
        }

        public void ShowProperties()
        {
            typeSomeClass = _someClass.GetType();

            Console.WriteLine("On input of constructer came Class {0}\n", typeSomeClass.Name);
            Console.WriteLine("It has such public properties");

            PropertyInfo[] properties = typeSomeClass.GetProperties();
            Console.WriteLine("|{0,17} | {1,15} | {2,30}|", "Properties Name", "Properties Type", "Properties Value");
            foreach (var propertyInfo in properties)
            {
                Console.WriteLine("|{0,17} | {1,15} | {2,30}|",
                                  propertyInfo.Name,
                                  propertyInfo.PropertyType,
                                  (!propertyInfo.PropertyType.IsArray)
                                      ? propertyInfo.GetValue(_someClass, null)
                                      : ValueInArray(((object) propertyInfo.GetValue(_someClass, null))));
            }

            Console.WriteLine("\nSurprise!!!");
            MethodInfo mi = typeSomeClass.GetMethod(
                "SomePrivateMethod",
                BindingFlags.Instance |
                BindingFlags.NonPublic);
            mi.Invoke(_someClass, null);

            Console.WriteLine("Now we change value on properties!!!\n");

            foreach (var propertyInfo in properties)
            {
                Console.WriteLine("|{0,17} | {1,15} | {2,30}|",
                                  propertyInfo.Name,
                                  propertyInfo.PropertyType,
                                  (!propertyInfo.PropertyType.IsArray)
                                      ? propertyInfo.GetValue(_someClass, null)
                                      : ValueInArray(((object) propertyInfo.GetValue(_someClass, null))));

                Console.WriteLine("Are You wont change this property?(If yes-enter Y) ");
                char c;
                char.TryParse(Console.ReadLine().ToUpper(), out c);

                if (c == 'Y')
                {
                    string s;

                    if (!propertyInfo.PropertyType.IsArray)
                    {
                        Console.WriteLine("Enter new value of {0} type", propertyInfo.PropertyType);

                        s = Console.ReadLine();

                        if (propertyInfo.PropertyType == Type.GetType("System.String"))
                        {
                            propertyInfo.SetValue(_someClass, s, null);
                        }
                        //Console.WriteLine(propertyInfo.GetValue(_someClass, null));
                        if (propertyInfo.PropertyType == Type.GetType("System.Int64"))
                        {
                            long temp;
                            long.TryParse(s, out temp);
                            propertyInfo.SetValue(_someClass, temp, null);
                        }
                        if (propertyInfo.PropertyType == Type.GetType("System.Double"))
                        {
                            double temp1;
                            double.TryParse(s, out temp1);
                            propertyInfo.SetValue(_someClass, temp1, null);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter new value of {0} type", propertyInfo.PropertyType);

                        if (propertyInfo.PropertyType == Type.GetType("System.Byte[]"))
                        {
                            Console.WriteLine("Enter new value of {0} type", propertyInfo.PropertyType);

                            byte[] param = new byte[countArByte];

                            for (int j = 0; j < countArByte; j++)
                            {
                                Console.WriteLine("Enter {0} el of array (For end input- n) ", j);
                                s = Console.ReadLine();

                                byte temp2;
                                byte.TryParse(s, out temp2);

                                param.SetValue(temp2, j);
                            }

                            propertyInfo.SetValue(_someClass, param, null);
                        }

                        if (propertyInfo.PropertyType == Type.GetType("System.String[]"))
                        {
                            Console.WriteLine("Enter new value of {0} type", propertyInfo.PropertyType);

                            string[] param = new string[countArStr];

                            for (int i = 0; i < countArStr;i++ )
                            {
                                Console.WriteLine("Enter {0} el of array (For end input- n) ",i);
                                s = Console.ReadLine();
                                param[i] = s;
                            } 

                            propertyInfo.SetValue(_someClass, param, null);
                        }
                    }
                }
            }
            Console.WriteLine("Now we have new value on properties!!!\n");

            foreach (var propertyInfo in properties)
            {
                Console.WriteLine("|{0,17} | {1,15} | {2,30}|",
                                  propertyInfo.Name,
                                  propertyInfo.PropertyType,
                                  (!propertyInfo.PropertyType.IsArray)
                                      ? propertyInfo.GetValue(_someClass, null)
                                      : ValueInArray(((object) propertyInfo.GetValue(_someClass, null))));
            }
        }


        private string ValueInArray(object  o)
        {
            
            string tempStr = "";

            if(o is byte[])
            {
                countArByte = 0;
                var mas = (byte[]) o;

                foreach (var ma in mas)
                {
                    tempStr += ma.ToString() + " ";
                    countArByte++;
                }
            }

            if(o is string[])
            {
                countArStr = 0;
                var mas = (string[])o;
                foreach (var ma in mas)
                {
                    tempStr += ma + " ";
                    countArStr++;
                }
            }
            return tempStr;
        }
    }
}
