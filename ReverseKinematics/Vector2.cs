using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ReverseKinematics
{
    internal class Vector2
    {
        private float x;
        private float y;
        private float angle;
        private float length;

        //CONSTRUCTORS:
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
            length = calcLength();
            angle = calcAngle();
        }

        public Vector2(Vector2 v, float length, float angle)
        {
            this.length = length;
            this.angle = angle;
            x = v.X + calcX();
            y = v.Y + calcY();
        }

        //FUNCTIONS:
        //privates:
        private float calcLength()
        {
            return (float)Math.Sqrt(x * x + y * y);
        }
        private float calcAngle()
        {
            if (x == 0)
                return (float)(Math.PI / 2) * (y < 0 ? -1 : 1);
            else if (x > 0)
                return (float)Math.Atan(y / x);
            else
                return (float)Math.Atan(y / x) + Vector2.DegToRad(180);
        }

        private float calcX()
        {
            return (float)(Math.Cos(this.angle) * this.length);
        }
        private float calcY()
        {
            return (float)(Math.Sin(this.angle) * this.length);
        }

        //publics:
        public Point ToPoint()
        {
            Point p = new Point();
            p.X = (int)Math.Round(x);
            p.Y = (int)Math.Round(y);
            return p;
        }

        public bool inRange(Vector2 v, float range)
        {
            range = Math.Abs(range);
            if (this.x + range > v.X && this.X - range < v.X)
                if (this.y + range > v.Y && this.y - range < v.Y)
                    return true;
            return false;
        }



        public void Magnitude(float length)
        {
            this.length = length;
            x = calcX();
            y = calcY();
        }

        public float Heading()
        {
            return calcAngle();
        }

        //STATIC FUNCTIONS:
        public static float RadToDeg(float rad)
        {
            return (float)(rad * 180 / Math.PI);
        }

        public static float DegToRad(float deg)
        {
            return (float)(deg * Math.PI / 180);
        }

        public static Vector2 Add(Vector2 v1, Vector2 v2) 
        {
            return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
        }
        public static Vector2 Subtract(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X - v2.X, v1.Y - v2.Y);
        }

        public static Vector2 Multiply(Vector2 v, float num)
        {
            return new Vector2(v.X * num, v.Y * num);
        }

        public string ToString(string input)
        {
            if (input != "deg")
                return
                    "{x: " + x.ToString("#.##") +
                    ", y: " + y.ToString("#.##") +
                    ", len: " + length.ToString("#.##") +
                    ", angle: " + angle.ToString("#.##") + " rad}";
            else return 
                    "{x: " + x.ToString("#.##") +
                    ", y: " + y.ToString("#.##") +
                    ", len: " + length.ToString("#.##") +
                    ", angle: " + Vector2.RadToDeg(angle).ToString("#.##") + " deg}";
        }

        public string ToString()
        {
            return ToString("");
        }

        //GETTERS, SETTERS:
        public float X 
        {
            get { return x; }
            set { x = value; }
        }
        public float Y 
        { 
            get { return y; }
            set { x = value; }

        }
        public float Angle { get { return angle; } }
        public float Length { get { return length; } }
    }
}
