using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrlC3ApiLib;

namespace C3API_Scripts
{
    public class ProfileSelection
    {
        GrlC3Controller grlQilib = null;
        public ProfileSelection()
        {
            grlQilib = new GrlC3Controller();
            grlQilib.Initialize();
        }
        public void Run()
        {

            TxCoilModel txCoilModel = new TxCoilModel();
            txCoilModel.BppSelected = true;
            grlQilib.SetDUTPowerProfile(txCoilModel.BppSelected);
        }
    }
}
