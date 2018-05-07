using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDay
{
    class Program
    {
        public static void Serialize(Stream s, object ob1)
        {
            var field = ob1.GetType();
            var fields1 = ob1.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            StreamWriter sw = new StreamWriter(s);
            sw.WriteLine(field);           
            foreach (var item in field.GetFields())
            {
                sw.WriteLine(item.Name);
                sw.WriteLine(item.GetValue(item));
            }
            foreach (var item in fields1)
            {
                sw.WriteLine(item.Name);
            }
            sw.Flush();
        }
        public static object DeSerialize(Stream s)
        {
            StreamReader sr = new StreamReader(s);
            string name = sr.ReadLine();
            var ob1 = Activator.CreateInstance(Type.GetType(name));
            var fields = ob1.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance |BindingFlags.NonPublic);
            foreach (var item in fields)
            {               
                if(item.FieldType == typeof(int))
                    item.SetValue(ob1,int.Parse( sr.ReadLine()));
                else if(item.FieldType == typeof(double))
                    item.SetValue(ob1, double.Parse(sr.ReadLine()));                         

            }
            return ob1;
            
        }
        static void Main(string[] args)
        {
            FileStream fs = new FileStream("test.txt", FileMode.Create);
            TestRe t = new TestRe();
            t.Data = 100500;
            
            Serialize(fs, t);
            fs.Position = 0;
            var ob2 = DeSerialize(fs) as TestRe;

            Console.WriteLine(ob2.Data);

            var cp = ob2.GetType();
            var info = cp.GetMethod("Plus", BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine(info.Invoke(ob2, new object[] { 1,2}));
        }
    }
}
