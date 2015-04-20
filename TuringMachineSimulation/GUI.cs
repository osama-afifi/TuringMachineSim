using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace TuringMachineSimulation
{
    public partial class GUI : Form
    {
        TuringMachine TM;
        public GUI()
        {
            InitializeComponent();
            TM = new TuringMachine();
            refreshTape();
        }

        public void refreshTape()
        {
            TapeTextBox.Text = TM.tape.getTapeState();
            TapeTextBox.SelectionStart = TM.tape.getCurrentPosition();
            TapeTextBox.SelectionLength = 1;
            TapeTextBox.SelectionColor = Color.Red;
            TapeTextBox.SelectionBackColor = Color.Yellow;        
        }




    }
}
