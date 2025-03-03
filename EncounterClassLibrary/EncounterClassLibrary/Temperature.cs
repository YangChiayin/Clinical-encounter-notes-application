using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncounterClassLibrary
{
    internal class Temperature : Ivital
    {
        public double Tcelsius {  get; set; }
        public string Type => "T";

        public string Unit => "";

        public string Value => Tcelsius.ToString("F1");
        public string Status
        {
            get
            {
                if (Tcelsius < 36.5) return "(Low)";
                if (Tcelsius > 37.2) return "(High)";
                return "(Normal)";
            }
        }

        public override string ToString()
        {
            return $"{Type}: {Value} {Unit} {Status}";
        }



    }
}
