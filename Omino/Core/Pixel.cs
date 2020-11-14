using System;

namespace Omino.Core
{
    public struct Pixel
    {
        public int X, Y;

        public Pixel(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }

        public bool IsNeighbor(Pixel p2)
        {
            if (X == p2.X && Math.Abs(Y - p2.Y) == 1) return true;
            if (Y == p2.Y && Math.Abs(X - p2.X) == 1) return true;
            return false;
        }

        public static bool operator ==(Pixel p1, Pixel p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(Pixel p1, Pixel p2)
        {
            return !(p1 == p2);
        }

        public override bool Equals(object obj)
        {
            if (obj is null || !(obj is Pixel)) return false;
            var p2 = (Pixel)obj;
            if (this.X == p2.X && this.Y == p2.Y) return true;
            return false;
        }
        
        public bool Equals(Pixel other)
        {
            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }
    
    public struct Cut
    {

        public Pixel P1, P2;

        public Cut(Pixel p1, Pixel p2)
        {
            P1 = p1;
            P2 = p2;
        }
        
        public static bool operator ==(Cut p1, Cut p2)
        {
            return p1.Equals(p2);
        }
        
        public static bool operator !=(Cut p1, Cut p2)
        {
            return !(p1 == p2);
        }
        
        public override bool Equals(object obj)
        {
            if (obj is null || !(obj is Cut)) return false;
            var c2 = (Cut)obj;
            return c2.P1 == P1 && c2.P2 == P2 || c2.P1 == P2 && c2.P2 == P1;
        }
        
        public bool Equals(Cut other)
        {
            return P1.Equals(other.P1) && P2.Equals(other.P2);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (P1.GetHashCode() * 397) ^ P2.GetHashCode();
            }
        }
    }
    
}