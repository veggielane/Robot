﻿using System;
namespace Robot.Core.Maths
{
    public class Quat : IEquatable<Quat>
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
            if (mag != 0.0 && (Math.Round(mag * Math.Pow(10, 6)) / Math.Pow(10, 6) != 1.0))
            {
                mag = 1.0 / Math.Sqrt(mag);
                X = X * mag;
                Y = Y * mag;
                Z = Z * mag;
                W = W * mag;
            }
        }

        public double Length
        {
            get
            {
                return Math.Sqrt(LengthSquared);
            }
        }

        public double LengthSquared
        {
            get
            {
                return Math.Pow(W, 2) + Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2);
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
            return q2.Equals(q1);
        }
        public static bool operator !=(Quat q2, Quat q1)
        {
             return !q2.Equals(q1);
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
            double scale = Math.Sqrt(1.0 - Math.Pow(this.W,2));
            return new AxisAngle(new Vect3(this.X / scale, this.Y / scale, this.Z / scale), Angle.FromRadians(Math.Acos(this.W) * 2.0f));
        }

        public Euler toEuler()
        {
            return new Euler(
                Angle.FromRadians(Math.Atan2(2 * this.Y * this.W - 2 * this.X * this.Z, 1 - 2 * Math.Pow(this.Y, 2) - 2 * Math.Pow(this.Z, 2))),
                Angle.FromRadians(Math.Asin(2 * this.X * this.Y + 2 * this.Z * this.W)),
                Angle.FromRadians(Math.Atan2(2 * this.X * this.W - 2 * this.Y * this.Z, 1 - 2 * Math.Pow(this.X, 2) - 2 * Math.Pow(this.Z, 2)))
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

        public bool Equals(Quat other)
        {
           return X == other.X && Y == other.Y && Z == other.Z && W == other.W;
        }
        public override bool Equals(object other)
        {
            if (other is Quat)
            {
                var otherQuat = (Quat)other;
                return otherQuat == this;
            }
            return false;
        }

        public override string ToString()
        {
            return String.Format("Quat({0},{1},{2},{3})",X, Y, Z, W);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode() ^ W.GetHashCode();
        }
    }
}
