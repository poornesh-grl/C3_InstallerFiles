using System;
using GrlC3ApiLib;

namespace C3API_Scripts
{
    class Program
    {
        static void Main(string[] args)
        {
            //SetLoad load = new SetLoad();
            //RectVoltage rectVoltage = new RectVoltage();
            PacketSequence packetssend = new PacketSequence();
            //DigitalPing digitalPing = new DigitalPing();
            //RunTime runTimeseq = new RunTime();
            //ProfileSelection profileSelection = new ProfileSelection();
            //FODStreamer fODStreamer = new FODStreamer();

            //Disable below comments to send API's related to them
            //Set the values by going to Individual classes

            //load.Run();
            //rectVoltage.Run();
            packetssend.Run();
            //profileSelection.Run();
            //runTimeseq.Run();
            //digitalPing.SetDigitalPing();
            
            //fODStreamer.StartStremer();
            //fODStreamer.StopStremer();
        }
    }
}
