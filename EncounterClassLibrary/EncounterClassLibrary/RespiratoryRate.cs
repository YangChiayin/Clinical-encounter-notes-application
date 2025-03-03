using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncounterClassLibrary
{
    internal class RespiratoryRate : Ivital
    {
        public int RespiraBpm {  get; set; }
        public string Type => "RR";

        public string Unit => "bpm";

        public string Value => RespiraBpm.ToString();
        public string Status
        {
            get
            {
                if (RespiraBpm < 12) return "(Low)";
                if (RespiraBpm > 16) return "(High)";
                return "(Normal)";
            }
        }

        public override string ToString()
        {
            return $"{Type}: {Value} {Unit} {Status}";
        }



    }
}
