using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncounterClassLibrary
{
    public class HearRate : Ivital
    {
        public int Bpm {  get; set; }
        public string Type => "HR";

        public string Unit => "bpm";

        public string Value => Bpm.ToString();
        public string Status
        {
            get
            {
                if (Bpm  < 60) return "(Low)";
                if (Bpm > 100) return "(High)";
                return "(Normal)";
            }
        }
        public HearRate() { }
        public HearRate(int bpm)
        {
            Bpm = bpm;
        }

        public override string ToString()
        {
            return $"{Type}: {Value} {Unit} {Status}";
        }



    }
}
