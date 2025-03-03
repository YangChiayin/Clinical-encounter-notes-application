using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncounterClassLibrary
{
    public interface Ivital
    {
        string Type {  get; }
        string Unit { get; }
        string Value { get; }
        string Status { get; }

    }
}
