using System;

[assembly: CLSCompliant(true)]
namespace SomeCommonLogic
{

    public class Class1
    {
        public int i = 0;
        public int I = 0;
       public string getCurrentDateandTime()
        {
            return DateTime.Now.ToString();
        }
    }
}
