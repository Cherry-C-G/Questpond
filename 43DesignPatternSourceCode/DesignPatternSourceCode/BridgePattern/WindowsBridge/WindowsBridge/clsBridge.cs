using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsBridge
{
    public interface IEquipment
    {
        void Start();
        void Stop();
    }
    class clsRefrigerator : IEquipment
    {
        public  void Start()
        {
            Console.WriteLine("Start Compressor");
            Console.WriteLine("Start Ice Cooling");
        }
        public  void Stop()
        {
            Console.WriteLine("Stop Ice Cooling");
            Console.WriteLine("Stop Compressor");
        }
    }
    class clsBulb : IEquipment
    {
        public void Start()
        {
            Console.WriteLine("Warm up the bulb");
            Console.WriteLine("Glow the bulb");
        }
        public void Stop()
        {
            Console.WriteLine("Switch off the bulb");
        }
    }
    interface ISwitch
    {
        void On();
        void Off();
    }
    class Clsswitch : ISwitch
    {
        private IEquipment objEquipment;
        public void setEquipMent(IEquipment Equipment)
        {
            objEquipment = Equipment;
        }
        public void On()
        {
            objEquipment.Start();
            
        }
        public void Off()
        {
            objEquipment.Stop();
           
        }
    }
}
