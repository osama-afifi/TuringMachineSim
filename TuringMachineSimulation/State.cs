using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachineSimulation
{
    public class State
    {
        public enum dir { L, R, S };
        public int id;
        public Dictionary<char, Tuple<char, dir, State>> transition;
        public State(int id)
        {
            this.id = id;
            transition = new Dictionary<char, Tuple<char, dir, State>>();
        }

        public void addTransition(char ReadCharacter, char writtenCharacter, dir direction, State nextState)
        {
            transition[ReadCharacter] = new Tuple<char, dir, State>(writtenCharacter, direction, nextState);
        }
    }
}
