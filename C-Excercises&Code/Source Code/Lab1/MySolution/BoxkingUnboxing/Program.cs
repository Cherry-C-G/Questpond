using System;
using System.Runtime.InteropServices;

namespace BoxkingUnboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            int i=10;
            int y = i;
            object o = y;
            int z = (int)o;
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
}
