using System;

namespace SumLabbWPF
{
    public class LabDataVM
    {
        public LabDataVM(string icDG, string iaDG, string deltaIa, string iaIcAttitude)
        {
            IcDG = icDG;
            IaDG = iaDG;
            DeltaIa = deltaIa;
            IaIcAttitude = iaIcAttitude;
        }


        public string IcDG { get; set; }
        public string IaDG { get; set; }
        public string DeltaIa { get; set; }
        public string IaIcAttitude { get; set; }
    }
}
