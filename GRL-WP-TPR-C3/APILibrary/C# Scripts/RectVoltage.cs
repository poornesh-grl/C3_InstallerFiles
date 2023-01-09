using System;
using System.Collections.Generic;
using System.Text;
using GrlC3ApiLib;

namespace C3API_Scripts
{
    public class RectVoltage
    {
        GrlC3Controller grlQilib = null;
        public RectVoltage()
        {
            //Initilize API libary
            grlQilib = new GrlC3Controller();
            
            //Set API library mode, this reflect main application only API mode
            grlQilib.SetAPIMode(true);
            
            //Initilize C3 controller
            grlQilib.Initialize();
        }
        public void Run()
        {
            //Select Tester [PRx] Connected Coil type before start capture
            ValidatorCoilType Coil = ValidatorCoilType.TPR_1A;
            grlQilib.SetCoilType(Coil);

            //Start the Capture to see changes in Plot
            grlQilib.StartCapture();

            //Read Rectified voltage/current and power
            RxCoilRectifiedReadingsModel readvoltge = grlQilib.GetRectifiedReadings();

            //Send rectified Voltage values in volts, after sending this API Rectified voltage will change. Note: Rectified voltage change occures only when BSUT is 
            // in Power Transfer phase
            double Rectified_Voltage = 6;
            grlQilib.SetRectifiedVoltage(Rectified_Voltage);

            //Read Rectified voltage/current and power again
            readvoltge = grlQilib.GetRectifiedReadings();

            //Stop Capture the waveform will be saved in "C:\GRL\GRL-C3_Browser_App\SampleFiles"
            grlQilib.StopCapture();

            //Disable API mode, this reflect main application after this browser Application can use in CTS mode
            grlQilib.SetAPIMode(false);
        }
    }
}
