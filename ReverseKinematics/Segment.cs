using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ReverseKinematics
{
    internal class Segment
    {
        Vector2 start;
        Vector2 end;
        float angle;
        float length;
        Segment parent;

        public Segment(int x, int y, float len, float angle)
        {
            start = new Vector2(x, y);
            this.angle = angle;
            this.length = len;
            end = new Vector2(start,len,angle);
            parent = null;
        }

        public Segment(Segment parent, float len, float angle)
        {
            this.parent = parent;
            this.length = len;
            this.angle = angle;
            start = new Vector2(parent.End.X,parent.end.Y);
            end = new Vector2(start, len, angle);
        }

        private void calculateEnd()
        {
            end.X = (float)(Math.Cos(angle) * length);
            end.Y = (float)(Math.Sin(angle) * length);
        }

        public void show(PaintEventArgs e, int thickness)
        {
            e.Graphics.DrawLine(new Pen(Color.White, thickness), start.ToPoint(), end.ToPoint());
        }

        public void follow(float x, float y, float speed = 1f)
        {
            Vector2 target = new Vector2(x, y);
            target = Vector2.Subtract(target, start);

            Vector2 dir = new Vector2(target, length, target.Angle);
            dir.Magnitude(-1);
            angle = dir.Heading();
            if(parent != null)
            {
                return;
            }
            if (!target.inRange(new Vector2(0, 0), 10))
            {
                start = Vector2.Subtract(start, Vector2.Multiply(dir,speed));
                calculateEnd();
            }
        }
        public void follow()
        {
            if(parent != null)
            {
                follow(parent.End.X, parent.End.Y);
            }
        }
        public Vector2 End { get { return end; } }
        public Vector2 Start { get { return start; } }
    }
}
