using System;
using System.Collections.Generic;
using System.Text;
using GrlC3ApiLib;

namespace C3API_Scripts
{
    public class RxCoil
    {
        GrlC3Controller grlQilib = null;
        public RxCoil()
        {
            grlQilib = new GrlC3Controller();
            grlQilib.SetAPIMode(true);
            grlQilib.Initialize();
        }
        public void coil()
        {

            //RxCoilModel coil = new RxCoilModel();
            //coil.CoilVolatge = 5;
            //coil.ThresholdVolatge = 7;
            //coil.CoilType = CoilType.TPR_1A.ToString();


            ValidatorCoilType Coil = ValidatorCoilType.TPR_1A;
            grlQilib.SetCoilType(Coil);
        }
    }
}
