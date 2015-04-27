using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachineSimulation
{
    class Tape
    {
        const int tapeLimit = 150;
        const int tapeStart = tapeLimit/6;
        int cur_pos;
        char[] _tape = new char[tapeLimit];
        public Tape()
        {
            for (int i = 0; i < tapeLimit; i++)
                _tape[i] = '$';
            cur_pos = tapeStart;
        }

        public string getTapeState()
        {
            return new string(_tape);        
        }

        public void setTapeState(string inputText)
        {
            for (int i = tapeStart; i < tapeStart + inputText.Length; i++)
                _tape[i] = inputText[i - tapeStart];
        }

        public int getCurrentPosition()
        {
            return cur_pos;
        }

        public void goLeft()
        {
            cur_pos--;
        }

        public void goRight()
        {
            cur_pos++;
        }

        public void replaceCell(char newChar)
        {
            _tape[cur_pos] = newChar; 
        }
     
    }
}
