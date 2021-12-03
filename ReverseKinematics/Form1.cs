using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReverseKinematics
{
    public partial class Form1 : Form
    {
        Segment seg1;
        Segment seg2;
        Segment seg3;

        int dirX, dirY;
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Interval = 10;
            seg1 = new Segment(100, 100, 100, Vector2.DegToRad(180+45));
            seg2 = new Segment(seg1, 100, 20);
            seg3 = new Segment(505, 0203, 30, Vector2.DegToRad(82));
        }

        private void Paint_1(object sender, PaintEventArgs e)
        {
            seg1.show(e, 4);
            seg2.show(e, 5);
            seg3.show(e, 2);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            dirX = e.Location.X;
            dirY = e.Location.Y;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            seg1.follow(dirX, dirY, 3);
            seg2.follow();
            this.Invalidate();
            this.DoubleBuffered = true;
        }
    }
}
