using System;
using System.Collections.Generic;
using System.Text;
// Entity objects are always different even if the values are same
//Customer obj = new Customer();
//obj.name = "Shiv";

//Customer obj1 = new Customer();
//obj1.name = "Shiv";
//Console.WriteLine(obj == obj1);
//Console.WriteLine(obj.Equals(obj1));
//Console.ReadLine();

// Value objecst client code
// Value object should be immitable or else you have aliasing bugs
//Year y = new Year();
//y.Value = "12";
//            Year y1 = new Year();
//y1.Value = "dec";

//            Console.WriteLine(y.Equals(y1));
//            Console.WriteLine(y==y1);
            
namespace DDDClasses
{
    public class Customer
    {
        public string name { get; set; }
        public string address { get; set; }
        public Year year { get; set; }
    }
    public class Year
    {
        private  readonly string _value;

        public string Value
        {
            get { return _value; }
        }

        public Year(string _val)
        {
            _value = _val;
        }
        // Equal
        // ==
        // !==
        // gethashcode
        public override int GetHashCode()
        {
            // dec 
            // 12
            if (this.Value == "12"  || this.Value == "dec")
            {
                return "12".GetHashCode() + "year".GetHashCode(); // same hashcode
            }
            else
            {
                return base.GetHashCode();
            }
        }
        public override bool Equals(object obj)
        {
            var temp = (Year)obj;
            if((this.Value=="12" && temp.Value == "dec"  )||
               (this.Value == "dec" && temp.Value == "12"))
                {
                return true;
            }
            return false;
                
        }
        public static bool operator ==(Year y1, Year y2)
        {
            if ((y1.Value == "12" && y2.Value == "dec") ||
                   (y1.Value == "dec" && y2.Value == "12"))
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Year y1, Year y2)
        {
            if ((y1.Value == "12" && y2.Value == "dec") ||
                    (y1.Value == "dec" && y2.Value == "12"))
            {
                return false;
            }
            return true;
        }

     }
    //public static class Utility{
    //    public static bool Check(Year y1 , Year y2)
    //    {

    //        return true;
    //    }
    //}

}
