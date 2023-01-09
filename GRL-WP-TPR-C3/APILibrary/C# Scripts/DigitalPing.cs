using System;
using System.Collections.Generic;
using System.Text;
using GrlC3ApiLib;

namespace C3API_Scripts
{
    public class DigitalPing
    {
        GrlC3Controller grlQilib = null;
        public DigitalPing()
        {
            grlQilib = new GrlC3Controller();
            grlQilib.Initialize();
        }

        public void SetDigitalPing()
        {
            bool Enable_Digital_Ping = true;
            grlQilib.SetDigitalPing(Enable_Digital_Ping);
        }
    }
}
