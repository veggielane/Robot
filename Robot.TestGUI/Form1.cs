using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Robot.Core;
using Robot.Core.Kinematics;
using Robot.Core.Messaging;
using Robot.Core.Timing;

namespace Robot.TestGUI
{
    public partial class Form1 : Form
    {
        private Stompy robot;
        public Form1()
        {
            InitializeComponent();
            robot = new Stompy(new MessageBus(), new AsyncObservableTimer());
            robot.Bus.Subscribe((m) => Debug.Write(m.ToString()));
            robot.Run();
        }

 

        private void PictureBox1Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var center = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            using (var gfx = pictureBox1.CreateGraphics())
            {
                gfx.Clear(Color.White);
                DrawDot(gfx, Brushes.Gray, center, 14);

                var body = new Point(center.X + (int)robot.Body.Position.X, center.Y + (int)robot.Body.Position.Y);
                DrawDot(gfx, Brushes.Blue, body, 10);
                DrawLeg(gfx, robot._legLeftFront);
                DrawLeg(gfx, robot._legLeftMiddle);
                DrawLeg(gfx, robot._legLeftRear);
                DrawLeg(gfx, robot._legRightFront);
                DrawLeg(gfx, robot._legRightMiddle);
                DrawLeg(gfx, robot._legRightRear);

            }
        }

        private void DrawDot(Graphics gfx, Brush b, Point center, int i)
        {
            gfx.FillEllipse(b, center.X - i / 2, center.Y - i / 2, i,i);
        }

        private void DrawLeg(Graphics gfx, ILeg leg)
        {
            var center = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);

            DrawDot(gfx, Brushes.Red, new Point(center.X + (int)leg.BasePosition.X, center.Y + (int)leg.BasePosition.Y), 10);
            DrawDot(gfx, Brushes.Red, new Point(center.X + (int)leg.FootPosition.X, center.Y + (int)leg.FootPosition.Y), 10);
        }
    }
}
