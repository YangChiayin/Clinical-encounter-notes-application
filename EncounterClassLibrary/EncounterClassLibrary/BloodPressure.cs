using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncounterClassLibrary
{
    public class BloodPressure : Ivital
    {
        public int Systolic { get; set; }
        public int Diastolic { get; set; }
        public string Type => "BP";

        public string Unit => "mmHg";

        public string Value => $"{Systolic}/{Diastolic}";
        public string Status
        {
            get
            {
                if (Systolic < 90 && Diastolic < 60) return "(Low)";
                if (Systolic > 130 && Diastolic > 80) return "(High)";
                return "(Normal)";
            }
        }
        public BloodPressure() { }
        public BloodPressure(int systolic, int diastolic)
        {
            Systolic = systolic;
            Diastolic = diastolic;
        }

        public override string ToString()
        {
            return $"{Type}: {Value} {Unit} {Status}";
        }



    }
}
