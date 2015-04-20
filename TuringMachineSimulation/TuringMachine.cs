using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachineSimulation
{
    class TuringMachine
    {
        public Tape tape;
        public List<State> states;
        public TuringMachine()
        {
            tape = new Tape();
        }
    }
}
