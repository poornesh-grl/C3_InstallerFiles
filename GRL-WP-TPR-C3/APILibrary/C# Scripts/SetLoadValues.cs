using System;
using System.Collections.Generic;
using System.Text;
using GrlC3ApiLib;

namespace C3API_Scripts
{
    public class SetLoadValues
    {
        GrlC3Controller grlQilib = null;
        public SetLoadValues()
        {
            //Initilize API libary
            grlQilib = new GrlC3Controller();

            //Set API library mode, this reflect main application only API mode
            grlQilib.SetAPIMode(true);
            Console.WriteLine("Enabled API Mode...");

            //Initilize C3 controller
            ConnectionSetupInfo status = grlQilib.Initialize();

            Console.WriteLine("Controller initilization Success...");
            Console.WriteLine("    Controller Status: " + status.TesterStatus + Environment.NewLine + "    Version No: " +
                status.FirmwareVersion + Environment.NewLine + "    Controller SerialNo." + status.SerialNumber);

        }
        public void Run()
        {
            string strdata = "";
            while (true)
            {
                strdata = GetConsoleOutPut();

                if (strdata.ToLower().Contains("stop"))
                {
                    StopCapture();
                    break;
                }
                else if (strdata.ToLower().Contains("start"))
                {
                    StartCapture();
                }
                else if (strdata.ToLower().Contains("read"))
                {
                    ReadValues();
                }
                else if (strdata.ToLower().Contains("set:"))
                {
                    try
                    {
                        int itemp = strdata.IndexOf(':');
                        string strtemp = strdata.Substring(itemp + 1);
                        double.TryParse(strtemp, out double dload);
                        SetLoadVal(dload);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid Operation...");
                    }
                }
                else
                    Console.WriteLine("Invalid Operation...");
            }
        }

        public string GetConsoleOutPut()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Type below Options and Click Enter");
            Console.WriteLine("     start       --- To Start Set Load Script");
            Console.WriteLine("     Set:32.5    --- To Set 32.5 Ohms Load");
            Console.WriteLine("     Read        --- To Read Recitifed voltage Values");
            Console.WriteLine("     stop        --- To Stop Set Load Script");
            Console.WriteLine("\n");
            return Console.ReadLine();
        }
        public void StartCapture()
        {
            if (grlQilib.GetConnectionStatus() == 0)
            {
                //Select Tester [PRx] Connected Coil type before start capture
                ValidatorCoilType Coil = ValidatorCoilType.TPR_1A;
                grlQilib.SetCoilType(Coil);

                Console.WriteLine("Started Capture...");
                //Start the Capture to see changes in Plot
                grlQilib.StartCapture();
            }
            else
                Console.WriteLine("Controller Connection Error!!, retry again");
        }
        public void ReadValues()
        {
            //Read Rectified voltage/current and power
            RxCoilRectifiedReadingsModel readvoltge = grlQilib.GetRectifiedReadings();
            Console.WriteLine("     Rectified Voltage(V) : " + readvoltge.RectifiedVoltage.ToString() + "V");
            Console.WriteLine("     Rectified Current(A) : " + readvoltge.RectifiedCurrent.ToString() + "A");
            Console.WriteLine("     Rectified Power(W)   : " + readvoltge.RxPower.ToString() + "w");
            Console.WriteLine("\n");
        }
        public void SetLoadVal(double Dload)
        {
            if (grlQilib.GetConnectionStatus() == 0)
            {
                //Send Load values in terms of Ohms, Eg: if we have to send 100mA and selected coil is TPR#1A, then (Coil Target voltage)/0.100) i.e 4.2V/0.1A = 42 Ohms
                grlQilib.SetLoad(Dload);
                Console.WriteLine("     Set Load value:" + Dload);
                Console.WriteLine("\n");
            }
            else
                Console.WriteLine("Controller Connection Error!!, retry again");
        }
        public void StopCapture()
        {
            if (grlQilib.GetConnectionStatus() == 0)
            {
                //Stop Capture the waveform will be saved in "C:\GRL\GRL-C3_Browser_App\SampleFiles"
                grlQilib.StopCapture();
                Console.WriteLine("Stop Capture!!...");
                //Disable API mode, this reflect main application after this browser Application can use in CTS mode
                grlQilib.SetAPIMode(false);
                Console.WriteLine("Disable API Mode!!...");
            }
            else
                Console.WriteLine("Controller Connection Error!!, retry again");
        }
    }
}
