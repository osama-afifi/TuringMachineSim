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
        Pen myPen;
        Graphics g;
        List<Point> statePosition;
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
            statePosition.Add(new Point(94 , 336));
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
            myPen = new Pen(Color.FromArgb(0, 0, 0));
            g = GraphicalTMPanel.CreateGraphics();
        

            myPen.Width = 3F;
            //drawing the states
            Point drawPosition;
            for (int i = 0; i < statePosition.Count; i++)
            {
                drawPosition = statePosition[i];
                drawPosition.X -= 25;
                drawPosition.Y -= 25;
                g.DrawEllipse(myPen, new Rectangle(drawPosition, new Size(50, 50)));
            }

            //drawing the labels of the nodes
            for (int i = 0; i < statePosition.Count; i++)
            {
                Label lbl = new Label();
                lbl.Size = new Size(28, 20);
                lbl.Text = "Q" + i.ToString();
                Point lblPosition = statePosition[i];
                lblPosition.X -= 10;
                lblPosition.Y -= 5;
                lbl.Location = lblPosition;
                GraphicalTMPanel.Controls.Add(lbl);
            }

            //drawing the transitions
            for (int i = 0; i < TM.states.Count; i++)
            {
                if (TM.states[i].transition.ContainsKey('0'))
                {
                    drawTransition(i, TM.states[i].transition['0'].Item3.id, '0', TM.states[i].transition['0'].Item1);
                }
                if (TM.states[i].transition.ContainsKey('1'))
                {
                    drawTransition(i, TM.states[i].transition['1'].Item3.id, '1', TM.states[i].transition['1'].Item1);
                }
                if (TM.states[i].transition.ContainsKey(' '))
                {
                    drawTransition(i, TM.states[i].transition[' '].Item3.id, ' ', TM.states[i].transition[' '].Item1);
                }
            }
            
            //drawTransition(0, 1, 'x', 'y');
        }

        void drawTransition(int fromState, int toState, char readChar, char writtenChar)
        {
            if (fromState == toState)
                return;
            Pen curPen = new Pen(Color.FromArgb(0, 0, 0), 10F);
            //curPen.StartCap = LineCap.RoundAnchor;
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
            //endLocation.X -= 25;
            g.DrawLine(curPen, startLocation, endLocation);
        }

        private void GraphicalTMPanel_Clicked(object sender, MouseEventArgs e)
        {
            //xLabel.Text = e.X.ToString();
            //yLabel.Text = e.Y.ToString();
            //SolidBrush b = new SolidBrush(Color.FromArgb(0, 0, 0));
            //g.FillEllipse(b, e.X, e.Y, 20F, 20F);
        }



    }
}
