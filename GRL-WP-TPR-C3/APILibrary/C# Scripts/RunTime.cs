using System;
using System.Collections.Generic;
using System.Text;
using GrlC3ApiLib;

namespace C3API_Scripts
{
    public class RunTime
    {
        GrlC3Controller grlQilib = null;
        public RunTime()
        {
            grlQilib = new GrlC3Controller();
            grlQilib.Initialize();
        }
        public void Run()
        {
            List<QiPacketInfoModel> qimsgLst = new List<QiPacketInfoModel>();
            // signal strength
            QiPacketInfoModel SS_pkt = new QiPacketInfoModel();
            SS_pkt.PacketStrength = "(0x01)";
            SS_pkt.T_Start = 0;
            SS_pkt.PayLoad = "99";
            SS_pkt.PreambleCount = 11;
            SS_pkt.T_Interval = 0;
            SS_pkt.T_Silent = 0;
            SS_pkt.T_Wake = 40;
            SS_pkt.PacketCount = 0;
            SS_pkt.Id = 0;
            SS_pkt.repetmsgindex = 0;
            SS_pkt.CorruptCheckSum = false;
            SS_pkt.Checksum_Value = 50;//random
            SS_pkt.phasetype = PhaseType.Runtimemessage;
            //
            qimsgLst.Add(SS_pkt);
            grlQilib.SendRuntimeMessages(qimsgLst);
        }
    }
}
