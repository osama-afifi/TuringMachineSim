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
        List<Point> transitionLabelsPositions;
        List<string> transitionLabelsText;
        int currentStateIndex;
        //all the states of the current run (until the input text is accepted or rejected)
        List<State> allStates;
        enum orientation{North, South, East, West};
        public GUI()
        {
            InitializeComponent();
            TM = new TuringMachine();
            refreshTape();
            //saving the nodes locations
            initStatePositions();
            initTransitionLabelsPositions();
            initTranisitionsText();
        }

        private void initStatePositions()
        {
            statePosition = new List<Point>(9);
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

        private void initTransitionLabelsPositions()
        {
            transitionLabelsPositions = new List<Point>(16);
            transitionLabelsPositions.Add(new Point(256, 86));
            transitionLabelsPositions.Add(new Point(385, 45));
            transitionLabelsPositions.Add(new Point(380, 155));
            transitionLabelsPositions.Add(new Point(497, 86));
            transitionLabelsPositions.Add(new Point(642, 189));
            transitionLabelsPositions.Add(new Point(706, 88));
            transitionLabelsPositions.Add(new Point(700, 265));
            transitionLabelsPositions.Add(new Point(700, 290));
            transitionLabelsPositions.Add(new Point(373, 220));
            transitionLabelsPositions.Add(new Point(242, 200));
            transitionLabelsPositions.Add(new Point(303, 272));
            transitionLabelsPositions.Add(new Point(299, 384));
            transitionLabelsPositions.Add(new Point(421, 400));
            transitionLabelsPositions.Add(new Point(650, 364));
            transitionLabelsPositions.Add(new Point(672, 405));
            transitionLabelsPositions.Add(new Point(60, 180));
        }

        private void initTranisitionsText()
        {
            transitionLabelsText = new List<string>(16);
            transitionLabelsText.Add("0/$ , R");
            transitionLabelsText.Add("0/0 , R");
            transitionLabelsText.Add("1/1 , R");
            transitionLabelsText.Add("$/$ , L");
            transitionLabelsText.Add("0/$ , L");
            transitionLabelsText.Add("$/$ , S");
            transitionLabelsText.Add("1/1 , L");
            transitionLabelsText.Add("0/0 , L");
            transitionLabelsText.Add("$/$ , R");
            transitionLabelsText.Add("1/$ , R");
            transitionLabelsText.Add("0/0 , R");
            transitionLabelsText.Add("1/1 , R");
            transitionLabelsText.Add("$/$ , R");
            transitionLabelsText.Add("1/$ , L");
            transitionLabelsText.Add("$/$ , S");
            transitionLabelsText.Add("$/$ , S");
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

            //drawing the text above each transition
            for (int i = 0; i < transitionLabelsPositions.Count; i++)
            {
                drawText(transitionLabelsPositions[i], transitionLabelsText[i]);
            }
            //drawText(new Point(256, 86), "0/$ , R");
            //drawText(new Point(385, 45), "0/0 , R");
            //drawText(new Point(380, 155), "1/1 , R");
            //drawText(new Point(497, 86), "$/$ , L");
            //drawText(new Point(642, 189), "0/$ , L");
            //drawText(new Point(706, 88), "$/$ , S");
            //drawText(new Point(700, 265), "1/1 , L");
            //drawText(new Point(700, 290), "0/0 , L");
            //drawText(new Point(373, 220), "$/$ , R");
            //drawText(new Point(242, 200), "1/$ , R");
            //drawText(new Point(303, 272), "0/0 , R");
            //drawText(new Point(299, 384), "1/1 , R");
            //drawText(new Point(421, 400), "$/$ , R");
            //drawText(new Point(650, 364), "1/$ , L");
            //drawText(new Point(672, 405), "$/$ , S");
            //drawText(new Point(60, 180), "$/$ , S");
            /*
             * 0 1  256 86
1 1 385, 45
1 1 396, 161
1 2 497, 86
2 3 642, 189
2 7 706, 88
3 3 700, 265
3 3 700, 296 
0 4 260, 227
4 4 303, 272
4 4 299, 384
4 5 421, 392
5 3 650, 364
5 8 672, 405
0 9 27 ,194
             */




        }

        void drawText(Point position, string text)
        {
            Label label = new Label();
            label.Size = new Size(70, 20);
            Point lblPosition = position;
            Font font = new Font("Comic Sans MS Bold", 13);
            label.Text = text;
            lblPosition.X -= 10;
            lblPosition.Y -= 5;
            label.Location = lblPosition;
            label.Font = font;
            GraphicalTMPanel.Controls.Add(label);
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
            if (stateID >= 6)
            {
                drawPosition.X += 5;
                drawPosition.Y += 5;
                pen = new Pen(pen.Color, 3);
                g.DrawEllipse(pen, new Rectangle(drawPosition, new Size(40, 40)));
            }
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

        private void CompleteButton_Click(object sender, EventArgs e)
        {
            while (currentStateIndex < allStates.Count - 1)
            {
                NextStepButton_Click(sender, e);
                GraphicalTMPanel.Refresh();
                TapeTextBox.Refresh();
                System.Threading.Thread.Sleep(1000);
            }
        }



    }
}
