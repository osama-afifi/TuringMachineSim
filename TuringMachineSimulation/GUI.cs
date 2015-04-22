using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        Pen blackPen, redPen, orangePen;
        int curStateId = -1, prevStateId = -1;
        Graphics g;
        List<Point> statePosition;
        int currentStateIndex;
        //all the states of the current run (until the input text is accepted or rejected)
        List<State> allStates;
        enum orientation{North, South, East, West};
        public GUI()
        {
            InitializeComponent();
            TM = new TuringMachine();
            refreshTape();
            statePosition = new List<Point>(9);
            //saving the nodes locations
            statePosition.Add(new Point(150, 106));
            statePosition.Add(new Point(392, 106));
            statePosition.Add(new Point(610, 106));
            statePosition.Add(new Point(630, 283));
            statePosition.Add(new Point(309, 332));
            statePosition.Add(new Point(626, 435));
            statePosition.Add(new Point(94, 336));
            statePosition.Add(new Point(800, 114));
            statePosition.Add(new Point(793, 435));
        }

        public void refreshTape()
        {
            TapeTextBox.Text = TM.tape.getTapeState();
            TapeTextBox.SelectionStart = TM.tape.getCurrentPosition();
            TapeTextBox.SelectionLength = 1;
            TapeTextBox.SelectionColor = Color.Red;
            TapeTextBox.SelectionBackColor = Color.Yellow;
        }


        private void GraphicalTMPanel_Paint(object sender, PaintEventArgs e)
        {
            blackPen = new Pen(Color.FromArgb(0, 0, 0));
            redPen = new Pen(Color.Red);
            orangePen = new Pen(Color.Orange);
            g = GraphicalTMPanel.CreateGraphics();


            blackPen.Width = 3F;
            redPen.Width = 5F;
            orangePen.Width = 5F;

            //drawing the states
            Point drawPosition;
            for (int i = 0; i < statePosition.Count; i++)
            {
                drawPosition = statePosition[i];
                drawPosition.X -= 25;
                drawPosition.Y -= 25;
                if (i == curStateId)
                    drawState(i, redPen);
                else if (i == prevStateId)
                    drawState(i, orangePen);
                else
                    drawState(i, blackPen);
            }

            //drawing the labels of the nodes
            for (int i = 0; i < statePosition.Count; i++)
            {
                Label lbl = new Label();
                lbl.Size = new Size(25, 15);
                lbl.Text = "Q" + i.ToString();
                Point lblPosition = statePosition[i];
                lblPosition.X -= 10;
                lblPosition.Y -= 5;
                lbl.Location = lblPosition;
                GraphicalTMPanel.Controls.Add(lbl);
            }

            //drawing the transitions
            int from, to;
            for (int i = 0; i < TM.states.Count; i++)
            {
                from = i;
                if (TM.states[i].transition.ContainsKey('0'))
                {
                    to = TM.states[i].transition['0'].Item3.id;
                    if (from == to)
                    {
                        drawSelfLoop(from, from == 3 ? orientation.East: orientation.North, blackPen);
                    }
                    else
                    {
                        drawTransition(from, to, blackPen);
                    }
                }
                if (TM.states[i].transition.ContainsKey('1'))
                {
                    to = TM.states[i].transition['1'].Item3.id;
                    if (from == to)
                    {
                        drawSelfLoop(from, from == 3 ? orientation.East : orientation.South, blackPen);
                    }
                    else
                    {
                        drawTransition(from, to, blackPen);
                    }
                }
                if (TM.states[i].transition.ContainsKey(' '))
                {
                    to = TM.states[i].transition[' '].Item3.id;
                    if (from == to)
                    {
                        drawSelfLoop(from, orientation.East, blackPen);
                    }
                    else
                    {
                        drawTransition(from, to, blackPen);
                    }
                }
            }

        }

        void drawTransition(int fromState, int toState, Pen pen)
        {
            Pen curPen = new Pen(Color.FromArgb(0, 0, 0), 10F);
            curPen.EndCap = LineCap.ArrowAnchor;
            Point startLocation = statePosition[fromState];
            Point endLocation = statePosition[toState];
            double dx = endLocation.X - startLocation.X;
            double dy = endLocation.Y - startLocation.Y;
            double dist = Math.Sqrt(dx * dx + dy * dy);
            startLocation.X += (int)(25 * (Math.Sin(dx / dist)));
            startLocation.Y += (int)(25 * (Math.Sin(dy / dist)));
            endLocation.X += (int)(25 * (Math.Sin(-dx / dist)));
            endLocation.Y += (int)(25 * (Math.Sin(-dy / dist)));
            g.DrawLine(curPen, startLocation, endLocation);
        }

        private void drawState(int stateID, Pen pen)
        {
            Point drawPosition = statePosition[stateID];
            drawPosition.X -= 25;
            drawPosition.Y -= 25;           
            g.DrawEllipse(pen, new Rectangle(drawPosition, new Size(50, 50)));
            //double line for final states
            drawPosition.X += 5;
            drawPosition.Y += 5;
            if(stateID >= 6)
                g.DrawEllipse(pen, new Rectangle(drawPosition, new Size(40, 40)));
        }

        private void drawSelfLoop(int state, orientation or, Pen pen)
        {
            pen.Width = 7F; 
            pen.EndCap = LineCap.ArrowAnchor;
            Point location = statePosition[state];
            switch (or)
            { 
                case orientation.North:
                    location.X -= 15;
                    location.Y -= 40;
                    g.DrawArc(pen, location.X, location.Y, 40F, 40F, 180F, 200F);
                    break;

                case orientation.South:
                    location.X -= 15;
                    //location.Y += 10;
                    g.DrawArc(pen, location.X, location.Y, 40F, 40F, 180F, -200F);
                    break;

                case orientation.East:
                    //location.X += 15;
                    location.Y -= 20;
                    g.DrawArc(pen, location.X, location.Y, 40F, 40F, 260F, 200F);
                    break;
                    
                case orientation.West:
                    break;
            }
        
        }

        private void GraphicalTMPanel_Clicked(object sender, MouseEventArgs e)
        {
            //xLabel.Text = e.X.ToString();
            //yLabel.Text = e.Y.ToString();
            //SolidBrush b = new SolidBrush(Color.FromArgb(0, 0, 0));
            //g.FillEllipse(b, e.X, e.Y, 20F, 20F);
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            //validating that the input is 0 and 1 only
            bool validText = true;
            for (int i = 0; i < inputTextBox.Text.Length; i++)
            {
                if (inputTextBox.Text[i] != '0' && inputTextBox.Text[i] != '1')
                {
                    MessageBox.Show("Input word may contain 0 and 1 only !!!");
                    validText = false;
                    inputTextBox.Text = "";
                    break;
                }
            }

            if (validText)
            {
                TM.tape = new Tape();
                TM.tape.setTapeState(inputTextBox.Text);
                refreshTape();
                allStates = TM.runTuringMachine(inputTextBox.Text);
                currentStateIndex = 0;
                curStateId = prevStateId = allStates[0].id;
                GraphicalTMPanel.Refresh();
            }
        }

        private void NextStepButton_Click(object sender, EventArgs e)
        {
            //currentStateIndex++;
            if(currentStateIndex < allStates.Count - 1)
            {
                Tuple<char, State.dir, State> currentTransition = allStates[currentStateIndex].transition[TapeTextBox.Text[TM.tape.getCurrentPosition()] == '$' ? ' ' : TapeTextBox.Text[TM.tape.getCurrentPosition()]];
                TM.tape.replaceCell(currentTransition.Item1 == ' '? '$' : currentTransition.Item1);
                if (currentTransition.Item2 == State.dir.L)
                    TM.tape.goLeft();
                else if (currentTransition.Item2 == State.dir.R)
                    TM.tape.goRight();
                refreshTape();
                drawState(prevStateId, blackPen);
                prevStateId = curStateId;
                curStateId = allStates[currentStateIndex + 1].id;
                drawState(prevStateId, orangePen);
                drawState(curStateId, redPen);
                currentStateIndex++;
                if (currentStateIndex == allStates.Count - 1)
                {
                    if (allStates[currentStateIndex].isFinal)
                    {
                        resultTextBox.ForeColor = Color.GreenYellow;
                        resultTextBox.BackColor = Color.Green;
                        resultTextBox.Text = "Accepted";
                    }
                    else
                    {
                        resultTextBox.ForeColor = Color.Pink;
                        resultTextBox.BackColor = Color.Red;
                        resultTextBox.Text = "Rejected";
                    }
                }
            }
            
        }



    }
}
