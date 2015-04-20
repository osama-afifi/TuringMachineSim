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
        Pen myPen;
        Graphics g;
        List<Point> statePosition;
        public GUI()
        {
            InitializeComponent();
            TM = new TuringMachine();
            refreshTape();
            statePosition = new List<Point>(9);
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
            // g.DrawArc(myPen,0F, 0F, 30F, 30F, 0F, 270F);
            //Random X = new Random();
            //g.DrawEllipse(myPen, new Rectangle(X.Next() % 100, X.Next() % 100, 20, 20));
            //for (int i = 0; i < GraphicalTMPanel.Height; i += (GraphicalTMPanel.Height) / 12)
            //{
            //    g.DrawLine(myPen, new Point(0, i), new Point(GraphicalTMPanel.Width, i));
            //}

            //for (int i = 0; i < GraphicalTMPanel.Width; i += (GraphicalTMPanel.Width) / 14)
            //{
            //    g.DrawLine(myPen, new Point(i, 0), new Point(i, GraphicalTMPanel.Height));
            //}

            myPen.Width = 2F;
            for (int i = 0; i < statePosition.Count; i++)
            {
                g.DrawEllipse(myPen, new Rectangle(statePosition[i], new Size(50, 50)));
                Label lbl = new Label();
                TextBox tb = new TextBox();
                lbl.Size = new Size(28, 20);
                lbl.Text = "Q" + i.ToString();
                Point lblPosition = statePosition[i];
                lblPosition.X += 15;
                lblPosition.Y += 20;
                lbl.Location = lblPosition;
                //lb.Location = statePosition[i];
                GraphicalTMPanel.Controls.Add(lbl);
            }
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
