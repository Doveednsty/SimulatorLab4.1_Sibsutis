using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumLabbWPF
{
    public class LabDataVM
    {
        public LabDataVM(string iaDG, string icDG, string deltaIa, string iaIcAttitude)
        {
            IaDG = iaDG;
            IcDG = icDG;
            DeltaIa = deltaIa;
            IaIcAttitude = iaIcAttitude;
        }

        public string IaDG { get; set; }
        public string IcDG { get; set; }
        public string DeltaIa { get; set; }
        public string IaIcAttitude { get; set; }
    }
}
