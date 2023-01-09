using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using GrlC3ApiLib;

namespace C3API_Scripts
{
    class FODStreamer
    {
        GrlC3Controller grlQilib = null;
        public FODStreamer()
        {
            grlQilib = new GrlC3Controller();
            grlQilib.SetAPIMode(true);
            grlQilib.Initialize();
        }

        public void StartStremer()
        {
            List<MeasurementChannels> channels = new List<MeasurementChannels> {MeasurementChannels.Coil_Voltage, MeasurementChannels.Coil_Current,MeasurementChannels.Rectified_Voltage_UP,
                                                                                MeasurementChannels.Rectified_Current_UP, MeasurementChannels.Temperature_Channel1, MeasurementChannels.Temperature_Channel2};
            grlQilib.StartCapture(channels);
            Thread.Sleep(100 * 1000);
        }
        public void StopStremer()
        {
            grlQilib.StopCapture();
            grlQilib.SetAPIMode(false);
        }
    }
}
