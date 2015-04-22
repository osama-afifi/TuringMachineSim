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
        private State curState;
        public TuringMachine()
        {
            tape = new Tape();
            states = new List<State>();
            for (int i = 0; i < 9; i++)
            {
                states.Add(new State(i, i >= 6));
            }

            states[0].addTransition('0', ' ', State.dir.R, states[1]);
            states[0].addTransition('1', ' ', State.dir.R, states[4]);
            states[0].addTransition(' ', ' ', State.dir.S, states[6]);
            states[1].addTransition('0', '0', State.dir.R, states[1]);
            states[1].addTransition('1', '1', State.dir.R, states[1]);
            states[1].addTransition(' ', ' ', State.dir.L, states[2]);
            states[2].addTransition(' ', ' ', State.dir.S, states[7]);
            states[2].addTransition('0', ' ', State.dir.L, states[3]);
            states[3].addTransition('0', '0', State.dir.L, states[3]);
            states[3].addTransition('1', '1', State.dir.L, states[3]);
            states[3].addTransition(' ', ' ', State.dir.R, states[0]);
            states[4].addTransition('0', '0', State.dir.R, states[4]);
            states[4].addTransition('1', '1', State.dir.R, states[4]);
            states[4].addTransition(' ', ' ', State.dir.L, states[5]);
            states[5].addTransition(' ', ' ', State.dir.S, states[8]);
            states[5].addTransition('1', ' ', State.dir.L, states[3]);
        }

        public List<State> runTuringMachine(string text)
        {
            string newText;
            curState = states[0];
            State nextState;
            int i = 1;
            List<State> ret;
            ret = new List<State>();
            text = text.Insert(0, " ");
            text = text + " ";
            while (!curState.isFinal)
            {
                ret.Add(curState);
                if (curState.transition.ContainsKey(text[i]))
                {
                    nextState = curState.transition[text[i]].Item3;
                    newText = text.Substring(0, i) + curState.transition[text[i]].Item1 + text.Substring(i + 1);
                    if (curState.transition[text[i]].Item2 == State.dir.L)
                    {
                        i--;
                    }
                    else if (curState.transition[text[i]].Item2 == State.dir.R)
                    {
                        i++;
                    }
                    text = newText;
                    curState = nextState;
                 }
                else
                {
                    break;
                }
            }
            if(curState.isFinal)
                ret.Add(curState);
            return ret;
        }
    }
}

