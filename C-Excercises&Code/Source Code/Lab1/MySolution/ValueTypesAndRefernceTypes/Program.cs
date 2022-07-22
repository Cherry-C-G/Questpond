using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace ValueTypesAndRefernceTypes
{
    public struct coordinates
    {
         public int x;
         public int y;
         public int z;
        public void Moveby10()
        {
            x = x + 10;
            y = y + 10;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            coordinates xyz = new coordinates();
            xyz.x = 10;
            xyz.y = 20;
            xyz.z = 30;
            coordinates x1y1z1 = xyz; // copy by value
            x1y1z1.x = 100;

            // value types and reference types
            int i = 10; // Primitive data types
            int y1 = i; // fresh memory address for y and copies i value
            y1 = 30;
            bool b = true;
            MyClass o = new MyClass();  // non primitive custom data types
            o.var1 = "Shiv";
            MyClass o1 = new MyClass();
            o1 = o; // by reference
            o1.var1 = "Shiva";
            Console.WriteLine("Hello World!");
        }
        
        
        public static IntPtr Get(object a)
        {
            GCHandle handle = GCHandle.Alloc(a, GCHandleType.Weak);
            try
            {
                IntPtr pointer = GCHandle.ToIntPtr(handle);
                return pointer;
            }
            finally
            {
                handle.Free();
            }
        }

    }
    class MyClass
    {
        public string var1 = "";
        public int var2 =0;
        public Double var3 = 0;
        public string var4 = "";
    }
   
}
