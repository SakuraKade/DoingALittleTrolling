namespace DoingABitOfTrolling.Structs
{
    internal struct Position : IEquatable<Position>, IComparable<Position>, IEquatable<Point>, IComparable<Point>
    {
        public Position()
        {
            X = 0;
            Y = 0;
        }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X;
        public int Y;
        public int Magnitude { get => (int)MathF.Sqrt(X ^ 2 + Y ^ 2); }

        public static Position Lerp(Position a, Position b, float t)
        {
            return new Position(Lerp(a.X, b.X, t), Lerp(a.Y, b.Y, t));
        }

        private static int Lerp(int a, int b, float by)
        {
            return (int)(a * (1 - by) + b * by);
        }

        public static bool operator ==(Position a, Position b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Position a, Position b)
        {
            return !a.Equals(b);
        }

        public static Position operator +(Position a, Position b)
        {
            return new Position(a.X + b.X, a.Y + b.Y);
        }

        public static Position operator -(Position a, Position b)
        {
            return new Position(a.X - b.X, a.Y - b.Y);
        }

        public static Position FromPoint(Point point)
        {
            return new Position(point.X, point.Y);
        }

        public static int Distance(Position a, Position b)
        {
            return a.X - b.X + a.Y - b.Y;
        }

        public Point ToPoint()
        {
            return new Point(X, Y);
        }

        public int CompareTo(Position other)
        {
            if (this.Magnitude > other.Magnitude) return -1; // this one is bigger
            if (this.Magnitude < other.Magnitude) return 1; // other one is bigger
            return 0; // they are the same
        }

        public int CompareTo(Point other)
        {
            int otherMagnitude = (int)MathF.Sqrt(other.X ^ 2 + other.Y ^ 2);
            if (this.Magnitude > otherMagnitude) return -1;
            if (this.Magnitude < otherMagnitude) return 1;
            return 0;
        }

        public bool Equals(Position other)
        {
            if (other.X != X) return false;
            if (other.Y != Y) return false;
            return true;
        }

        public bool Equals(Point other)
        {
            if (other.X != X) return false;
            if (other.Y != Y) return false;
            return true;
        }

        internal static Position MoveTowards(Position a, Position b, int by)
        {
            int deltaX = a.X - b.X;
            int deltaY = a.Y - b.Y;

            Position position = a;

            if (deltaX < 0)
            {
                if (Math.Abs(deltaX) < by)
                {
                    position.X = b.X;
                }
                else
                {
                    position.X += by;
                }
            }
            else
            {
                if (Math.Abs(deltaX) < by)
                {
                    position.X = b.X;
                }
                else
                {
                    position.X -= by;
                }
            }

            if (deltaY < 0)
            {
                if (Math.Abs(deltaY) < by)
                {
                    position.Y = b.Y;
                }
                else
                {
                    position.Y += by;
                }
            }
            else
            {
                if (Math.Abs(deltaY) < by)
                {
                    position.Y = b.Y;
                }
                else
                {
                    position.Y -= by;
                }
            }

            return position;
        }
    }
}
