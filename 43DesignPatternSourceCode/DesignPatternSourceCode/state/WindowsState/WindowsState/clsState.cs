using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsState
{
    public class clsState
    {
        enum BulbState
        {
            On = 1,
            Off = 2
        }
        private BulbState currentBulbState = BulbState.Off;
        public string getStatus()
        {
            if (currentBulbState == BulbState.Off)
            {
                return "Bulb is on";
            }
            if (currentBulbState == BulbState.On)
            {
                return "Bulb is off";
            }
            return "";
        }

        public void PressSwitch()
        {
            if (currentBulbState == BulbState.Off)
            {
                currentBulbState = BulbState.On;
            }
            else if (currentBulbState == BulbState.On)
            {
                currentBulbState = BulbState.Off;
            }
        }
    }
}
