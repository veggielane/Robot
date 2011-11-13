using System;
#if MICRO
namespace Robot.Micro.Core.Maths
#else
namespace Robot.Core.Maths
#endif
{
    public class Quat
    {
        public double W { get; private set; }
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }

        public Vect3 XYZ
        {
            get
            {
                return new Vect3(X, Y, Z);
            }
        }

        public static Quat Identity = new Quat(0, 0, 0, 1);

        public Quat(double x, double y, double z, double w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
            Normalize();
        }

        public Quat(Vect3 xyz, double w):this(xyz.X,xyz.Y,xyz.Z,w)
        {

        }
        private void Normalize()
        {
            var mag = LengthSquared;
            if (MathsHelper.NearlyEquals(mag, 0.0) || MathsHelper.NearlyEquals(MathsHelper.Round(mag*MathsHelper.Pow(10, 6))/MathsHelper.Pow(10, 6), 1.0)) return;
            mag = 1.0 / MathsHelper.Sqrt(mag);
            X = X * mag;
            Y = Y * mag;
            Z = Z * mag;
            W = W * mag;
        }

        public double Length
        {
            get
            {
                return MathsHelper.Sqrt(LengthSquared);
            }
        }

        public double LengthSquared
        {
            get
            {
                return MathsHelper.Pow(W, 2) + MathsHelper.Pow(X, 2) + MathsHelper.Pow(Y, 2) + MathsHelper.Pow(Z, 2);
            }
        }

        #region Arithmetic Operations

        public static Quat operator +(Quat left, Quat right)
        {
            return new Quat(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);
        }

        public static Quat operator -(Quat left, Quat right)
        {
            return new Quat(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);
        }

        public static Quat operator *(Quat left, Quat right)
        {
            return new Quat(right.W * left.XYZ + left.W * right.XYZ + left.XYZ.CrossProduct(right.XYZ),
                left.W * right.W - left.XYZ.DotProduct(right.XYZ));
            /*
            return new Quat(
                left.W * right.X + left.X * right.W + left.Y * right.Z - left.Z * right.Y,
                left.W * right.Y + left.Y * right.W + left.Z * right.X - left.X * right.Z,
                left.W * right.Z + left.Z * right.W + left.X * right.Y - left.Y * right.X,
                left.W * right.W - left.X * right.X - left.Y * right.Y - left.Z * right.Z
                );
             * */
        }

        public static Quat operator *(Quat quat, double scalar)
        {
            return new Quat(quat.X * scalar, quat.Y * scalar, quat.Z * scalar, quat.W * scalar);
        }
        public static Quat operator *(double scalar, Quat quat)
        {
            return quat * scalar;
        }
        public static Quat operator /(Quat quat, double scalar)
        {
            return quat * (1/scalar);
        }

        public static bool operator ==(Quat q2, Quat q1)
        {
            return q2 != null && q2.Equals(q1);
        }
        public static bool operator !=(Quat q2, Quat q1)
        {
             return q2 != null && !q2.Equals(q1);
        }

        #endregion

        public Quat Inverse()
        {
            return new Quat(-X, -Y, -Z, W);
        }
        public Quat Conjugate()
        {
            return Inverse();   
        }
        
        /*
        public AxisAngle toAxisAngle()
        {
            double scale = MathsHelper.Sqrt(1.0 - MathsHelper.Pow(this.W,2));
            return new AxisAngle(new Vect3(this.X / scale, this.Y / scale, this.Z / scale), Angle.FromRadians(MathsHelper.Acos(this.W) * 2.0f));
        }

        public Euler toEuler()
        {
            return new Euler(
                Angle.FromRadians(MathsHelper.Atan2(2 * this.Y * this.W - 2 * this.X * this.Z, 1 - 2 * MathsHelper.Pow(this.Y, 2) - 2 * MathsHelper.Pow(this.Z, 2))),
                Angle.FromRadians(MathsHelper.Asin(2 * this.X * this.Y + 2 * this.Z * this.W)),
                Angle.FromRadians(MathsHelper.Atan2(2 * this.X * this.W - 2 * this.Y * this.Z, 1 - 2 * MathsHelper.Pow(this.X, 2) - 2 * MathsHelper.Pow(this.Z, 2)))
            );
        }

        public Mat4 toMat4()
        {
            throw new NotImplementedException();
        }
        */
        public Vect3 ToVect3()
        {
            return XYZ;
        }



        public override string ToString()
        {
#if MICRO
            return "Quat<"+X+","+Y+","+Z+","+W+">";
#else
            return String.Format("Quat<{0},{1},{2},{3}>", X, Y, Z, W);
#endif
            
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = W.GetHashCode();
                result = (result*397) ^ X.GetHashCode();
                result = (result*397) ^ Y.GetHashCode();
                result = (result*397) ^ Z.GetHashCode();
                return result;
            }
        }

        public bool Equals(Quat other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.W.Equals(W) && other.X.Equals(X) && other.Y.Equals(Y) && other.Z.Equals(Z);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Quat)) return false;
            return Equals((Quat) obj);
        }
    }
}
