using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using GrlC3ApiLib;

namespace C3API_Scripts
{
    public class SetLoad
    {
        GrlC3Controller grlQilib = null;
        public SetLoad()
        {
            //Initilize API libary
            grlQilib = new GrlC3Controller();

            //Set API library mode, this reflect main application only API mode
            grlQilib.SetAPIMode(true);

            //Initilize C3 controller
            ConnectionSetupInfo status = grlQilib.Initialize();

        }
        public void Run()
        {
            //Select Tester [PRx] Connected Coil type before start capture
            ValidatorCoilType Coil = ValidatorCoilType.TPR_1A;
            grlQilib.SetCoilType(Coil);

            //Start the Capture to see changes in Plot
            grlQilib.StartCapture();

            //Send Load values in terms of Ohms, Eg: if we have to send 100mA and selected coil is TPR#1A, then (Coil Target voltage)/0.100) i.e 4.2V/0.1A = 42 Ohms
            double Load = 8;//values in Ohms
            grlQilib.SetLoad(Load);

            //Read Rectified voltage/current and power
            RxCoilRectifiedReadingsModel readvoltge = grlQilib.GetRectifiedReadings();

            Thread.Sleep(100 * 1000);
            //Stop Capture the waveform will be saved in "C:\GRL\GRL-C3_Browser_App\SampleFiles"
            grlQilib.StopCapture();

            //Disable API mode, this reflect main application after this browser Application can use in CTS mode
            grlQilib.SetAPIMode(false);
        }
    }
}
