using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GrlC3ApiLib;

namespace C3API_Scripts
{
    public class PacketSequence
    {
        GrlC3Controller grlQilib = null;
        public PacketSequence()
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
            grlQilib.SetToCustomMode();
            //Select Tester [PRx] Connected Coil type before start capture
            ValidatorCoilType Coil = ValidatorCoilType.TPR_1A;
            grlQilib.SetCoilType(Coil);

            //Start the Capture to see changes in Plot
            grlQilib.StartCapture();

            //Add Sequence of packets
            List<QiPacketInfoModel> qimsgLst = new List<QiPacketInfoModel>();


            // Formation of signal strength packet
            QiPacketInfoModel SS_pkt = new QiPacketInfoModel();
            SS_pkt.PacketStrength = "(0x01)";                    //Signal Strength packet header
            SS_pkt.PayLoad = "";                                 //Signal Strength packet raw paylaod data in string Eg: 55, Min:0, Max:255
            SS_pkt.PreambleCount = 11;                           //Signal Strength packet preamble count Min:11, Max:24
            SS_pkt.T_Wake = 40;                                  //Signal Strength packet twake time
            SS_pkt.repetmsgindex = 0;                            //Signal Strength packet repeat count Eg: set 1, then repeat one more time
            SS_pkt.CorruptCheckSum = false;                   //Set true to currupt checksum
            SS_pkt.Checksum_Value = 0;                           //If Checksum is currupted set the value 
            SS_pkt.phasetype = PhaseType.IDandConfigurationPhase;//Set Phase Type 
            SS_pkt.PacketCount = 0;                              //Set packet index if incase same packet send one more time update as packetcount=1

            // Formation of Identification packet
            //id 
            QiPacketInfoModel ID_pkt = new QiPacketInfoModel();
            ID_pkt.PacketStrength = "(0x71)";                    //Send Identification Packet Header
            ID_pkt.T_Start = 15;                                 //Send Identification Packet T_Start time, i.e from the end of previous packet to start header of Identification packet
            ID_pkt.PayLoad = "01020304050607";                   //Send 7 bytes of packet raw payload Data i.e B0 - B6
            ID_pkt.PreambleCount = 11;                           //Identification packet preamble count Min:11, Max:24
            ID_pkt.T_Silent = 9.5;                               //Send Identification Packet T_Silent time, i.e from the end of previous packet to start of Identification packet
            ID_pkt.repetmsgindex = 0;                            //Identification packet repeat count Eg: set 1, then repeat one more time
            ID_pkt.CorruptCheckSum = false;                   //Set true to currupt checksum
            ID_pkt.Checksum_Value = 50;                          //If Checksum is currupted set the value 
            ID_pkt.phasetype = PhaseType.IDandConfigurationPhase;//Set Phase Type 
            ID_pkt.PacketCount = 0;                              //Set packet index if incase same packet send one more time update as packetcount=1


            //Formation of Configuration packet
            //Configuration
            QiPacketInfoModel CFG_pkt = new QiPacketInfoModel();
            CFG_pkt.PacketStrength = "(0x51)";                      //Send Configuration Packet Header
            CFG_pkt.T_Start = 15;                                   //Send Configuration Packet T_Start time, i.e from the end of previous packet to start header of Configuration packet
            CFG_pkt.PayLoad = "0A00000000";                         //Send 5 bytes of packet raw payload Data i.e B0 - B4
            CFG_pkt.PreambleCount = 11;                             //Configuration packet preamble count Min:11, Max:24
            CFG_pkt.T_Silent = 0;                                   //Send Configuration Packet T_Silent time, i.e from the end of previous packet to start of Configuration packet
            CFG_pkt.repetmsgindex = 0;                              //Configuration packet repeat count Eg: set 1, then repeat one more time
            CFG_pkt.CorruptCheckSum = false;                     //Set true to currupt checksum
            CFG_pkt.Checksum_Value = 50;//random                    //If Checksum is currupted set the value 
            CFG_pkt.phasetype = PhaseType.IDandConfigurationPhase;  //Set Phase Type 
            CFG_pkt.PacketCount = 0;                                //Set packet index if incase same packet send one more time update as packetcount=1


            ////Formation of Control Error packet
            //ControlError
            QiPacketInfoModel CE_pkt = new QiPacketInfoModel();
            CE_pkt.PacketStrength = "(0x03)";                   //Send Control Error Packet Header
            CE_pkt.T_Interval = 250;                            //Send Control Error Packet T_Interval time, i.e the time interval in between two Control Error packets
            CE_pkt.PayLoad = "0";                              //Send 1 byte of packet raw payload Data i.e B0
            CE_pkt.PreambleCount = 11;                          //Control Error packet preamble count Min:11, Max:24
            CE_pkt.repetmsgindex = 0;                           //Control Error packet repeat count Eg: set 1, then repeat one more time                                                    
            CE_pkt.CorruptCheckSum = false;                  //Set true to currupt checksum
            CE_pkt.Checksum_Value = 50;//random                 //If Checksum is currupted set the value 
            CE_pkt.phasetype = PhaseType.PowerTransferPhase;    //Set Phase Type 
            CE_pkt.PacketCount = 0;                             //Set packet index if incase same packet send one more time update as packetcount=1

            //Adding packet to list
            qimsgLst.Add(SS_pkt);
            qimsgLst.Add(ID_pkt);
            qimsgLst.Add(CFG_pkt);
            qimsgLst.Add(CE_pkt);

            //Send Messages to Controller
            grlQilib.SendMessages(qimsgLst);

            Thread.Sleep(100 * 1000);//100 Sec
            //Stop Capture the waveform will be saved in "C:\GRL\GRL-C3_Browser_App\SampleFiles"
            grlQilib.StopCapture();
            grlQilib.SetToNormalMode();

            //Disable API mode, this reflect main application after this browser Application can use in CTS mode
            grlQilib.SetAPIMode(false);

        }
    }
}
