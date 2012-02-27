using System;
#if MICRO
namespace Robot.Micro.Core.Maths
#else
namespace Robot.Core.Maths
#endif
{
    public struct Matrix4
    {
        private readonly Double[][] _data;
        public Matrix4(Double[][] data)
        {
            _data = data;
        }
        public Double this[int i, int j]
        {
            get
            {
                if (i < 1 || i > 4 || j < 1 || j > 4)
                    throw new ArgumentOutOfRangeException();
                return _data[i - 1][j - 1];
            }
            set
            {
                if (i < 1 || i > 4 || j < 1 || j > 4)
                    throw new ArgumentOutOfRangeException();
                _data[i - 1][j - 1] = value;
            }
        }

        public Double X { get { return this[1, 4]; } set { this[1, 4] = value; } }
        public Double Y { get { return this[2, 4]; } set { this[2, 4] = value; } }
        public Double Z { get { return this[3, 4]; } set { this[3, 4] = value; } }


        public static Matrix4 Identity
        {
            get{
                return new Matrix4(new[]{
                new[]{ 1.0, 0.0, 0.0, 0.0 }, 
                new[]{ 0.0, 1.0, 0.0, 0.0 }, 
                new[]{ 0.0, 0.0, 1.0, 0.0 }, 
                new[]{ 0.0, 0.0, 0.0, 1.0 }
            });}
        }

        public double Mag()
        {
            return MathsHelper.Sqrt(MathsHelper.Pow(this[1, 4], 2.0) + MathsHelper.Pow(this[2, 4], 2.0) + MathsHelper.Pow(this[3, 4], 2.0));
        }

        public Matrix4 Add(Matrix4 matrix)
        {
            return new Matrix4(new[]{
                new[]{this[1,1] + matrix[1,1], this[1,2] + matrix[1,2], this[1,3] + matrix[1,3], this[1,4] + matrix[1,4]}, 
                new[]{this[2,1] + matrix[2,1], this[2,2] + matrix[2,2], this[2,3] + matrix[2,3], this[2,4] + matrix[2,4]}, 
                new[]{this[3,1] + matrix[3,1], this[3,2] + matrix[3,2], this[3,3] + matrix[3,3], this[3,4] + matrix[3,4]}, 
                new[]{this[4,1] + matrix[4,1], this[4,2] + matrix[4,2], this[4,3] + matrix[4,3], this[4,4] + matrix[4,4]}
            });
        }  

        public Matrix4 Add(Double scalar)
        {
            return new Matrix4(new[]{
                new[]{this[1,1] + scalar, this[1,2] + scalar, this[1,3] + scalar, this[1,4] + scalar}, 
                new[]{this[2,1] + scalar, this[2,2] + scalar, this[2,3] + scalar, this[2,4] + scalar}, 
                new[]{this[3,1] + scalar, this[3,2] + scalar, this[3,3] + scalar, this[3,4] + scalar}, 
                new[]{this[4,1] + scalar, this[4,2] + scalar, this[4,3] + scalar, this[4,4] + scalar}
            });
        }

        public Matrix4 Subtract(Matrix4 matrix)
        {
            return new Matrix4(new[]{
                new[]{this[1,1] - matrix[1,1], this[1,2] - matrix[1,2], this[1,3] - matrix[1,3], this[1,4] - matrix[1,4]}, 
                new[]{this[2,1] - matrix[2,1], this[2,2] - matrix[2,2], this[2,3] - matrix[2,3], this[2,4] - matrix[2,4]}, 
                new[]{this[3,1] - matrix[3,1], this[3,2] - matrix[3,2], this[3,3] - matrix[3,3], this[3,4] - matrix[3,4]}, 
                new[]{this[4,1] - matrix[4,1], this[4,2] - matrix[4,2], this[4,3] - matrix[4,3], this[4,4] - matrix[4,4]}
            });
        }

        public Matrix4 Subtract(Double scalar)
        {
            return new Matrix4(new[]{
                new[]{this[1,1] - scalar, this[1,2] - scalar, this[1,3] - scalar, this[1,4] - scalar}, 
                new[]{this[2,1] - scalar, this[2,2] - scalar, this[2,3] - scalar, this[2,4] - scalar}, 
                new[]{this[3,1] - scalar, this[3,2] - scalar, this[3,3] - scalar, this[3,4] - scalar}, 
                new[]{this[4,1] - scalar, this[4,2] - scalar, this[4,3] - scalar, this[4,4] - scalar}
            });
        }
        public Matrix4 Multiply(Matrix4 matrix)
        {
            return new Matrix4(new[] {
                new[]{this[1, 1] * matrix[1, 1] + this[1, 2] * matrix[2, 1] + this[1, 3] * matrix[3, 1] + this[1, 4] * matrix[4, 1],this[1, 1] * matrix[1, 2] + this[1, 2] * matrix[2, 2] + this[1, 3] * matrix[3, 2] + this[1, 4] * matrix[4, 2],this[1, 1] * matrix[1, 3] + this[1, 2] * matrix[2, 3] + this[1, 3] * matrix[3, 3] + this[1, 4] * matrix[4, 3],this[1, 1] * matrix[1, 4] + this[1, 2] * matrix[2, 4] + this[1, 3] * matrix[3, 4] + this[1, 4] * matrix[4, 4]},
                new[]{this[2, 1] * matrix[1, 1] + this[2, 2] * matrix[2, 1] + this[2, 3] * matrix[3, 1] + this[2, 4] * matrix[4, 1],this[2, 1] * matrix[1, 2] + this[2, 2] * matrix[2, 2] + this[2, 3] * matrix[3, 2] + this[2, 4] * matrix[4, 2],this[2, 1] * matrix[1, 3] + this[2, 2] * matrix[2, 3] + this[2, 3] * matrix[3, 3] + this[2, 4] * matrix[4, 3],this[2, 1] * matrix[1, 4] + this[2, 2] * matrix[2, 4] + this[2, 3] * matrix[3, 4] + this[2, 4] * matrix[4, 4]},
                new[]{this[3, 1] * matrix[1, 1] + this[3, 2] * matrix[2, 1] + this[3, 3] * matrix[3, 1] + this[3, 4] * matrix[4, 1],this[3, 1] * matrix[1, 2] + this[3, 2] * matrix[2, 2] + this[3, 3] * matrix[3, 2] + this[3, 4] * matrix[4, 2],this[3, 1] * matrix[1, 3] + this[3, 2] * matrix[2, 3] + this[3, 3] * matrix[3, 3] + this[3, 4] * matrix[4, 3],this[3, 1] * matrix[1, 4] + this[3, 2] * matrix[2, 4] + this[3, 3] * matrix[3, 4] + this[3, 4] * matrix[4, 4]},
                new[]{this[4, 1] * matrix[1, 1] + this[4, 2] * matrix[2, 1] + this[4, 3] * matrix[3, 1] + this[4, 4] * matrix[4, 1],this[4, 1] * matrix[1, 2] + this[4, 2] * matrix[2, 2] + this[4, 3] * matrix[3, 2] + this[4, 4] * matrix[4, 2],this[4, 1] * matrix[1, 3] + this[4, 2] * matrix[2, 3] + this[4, 3] * matrix[3, 3] + this[4, 4] * matrix[4, 3],this[4, 1] * matrix[1, 4] + this[4, 2] * matrix[2, 4] + this[4, 3] * matrix[3, 4] + this[4, 4] * matrix[4, 4]}
            });
        }

        public Matrix4 Multiply(Double scalar)
        {
            return new Matrix4(new []{
                new[]{ this[1, 1] * scalar, this[1, 2] * scalar, this[1, 3] * scalar, this[1, 4] * scalar }, 
                new[]{ this[2, 1] * scalar, this[2, 2] * scalar, this[2, 3] * scalar, this[2, 4] * scalar },
                new[]{ this[3, 1] * scalar, this[3, 2] * scalar, this[3, 3] * scalar, this[3, 4] * scalar },
                new[]{ this[4, 1] * scalar, this[4, 2] * scalar, this[4, 3] * scalar, this[4, 4] * scalar }
            });
        }

        public Matrix4 Divide(Double scalar)
        {
            return Multiply(1.0 / scalar);
        }

        public Matrix4 Transpose()
        {
            return new Matrix4(new []{
                new[]{ this[1, 1], this[2, 1], this[3, 1], this[4, 1] }, 
                new[]{ this[1, 2], this[2, 2], this[3, 2], this[4, 2] }, 
                new[]{ this[1, 3], this[2, 3], this[3, 3], this[4, 3] }, 
                new[]{ this[1, 4], this[2, 4], this[3, 4], this[4, 4] }
            });
        }

        public Matrix4 Cofactor()
        {
            throw Error.NotImplementedException();
        }

        public static Matrix4 Translate(Double x, Double y, Double z)
        {
            return new Matrix4(new []{
                new[]{ 1.0, 0.0, 0.0, x }, 
                new[]{ 0.0, 1.0, 0.0, y }, 
                new[]{ 0.0, 0.0, 1.0, z }, 
                new[]{ 0.0, 0.0, 0.0, 1.0 }
            });
        }

        


        public static Matrix4 Rotate(Axis axis, Angle theta)
        {
            switch (axis)
            {
                case Axis.X:
                    return RotateX(theta);
                case Axis.Y:
                    return RotateY(theta);
                case Axis.Z:
                    return RotateZ(theta);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static Matrix4 RotateX(Angle theta)
        {
            return new Matrix4(new[]{
                new[]{1.0, 0.0, 0.0, 0.0}, 
                new[]{0.0, MathsHelper.Cos(theta), -MathsHelper.Sin(theta), 0.0},
                new[]{0.0, MathsHelper.Sin(theta), MathsHelper.Cos(theta), 0.0}, 
                new[]{0.0, 0.0, 0.0, 1.0}
            });
        }

        public static Matrix4 RotateY(Angle theta)
        {
            return new Matrix4(new[]{
                new[]{MathsHelper.Cos(theta), 0.0, MathsHelper.Sin(theta), 0.0}, 
                new[]{0.0, 1.0, 0.0, 0.0},
                new[]{-MathsHelper.Sin(theta), 0.0, MathsHelper.Cos(theta), 0.0}, 
                new[]{0.0, 0.0, 0.0, 1.0}
            });
        }

        public static Matrix4 RotateZ(Angle theta)
        {
            return new Matrix4(new[]{
                new[]{MathsHelper.Cos(theta), -MathsHelper.Sin(theta), 0.0, 0.0},
                new[]{MathsHelper.Sin(theta), MathsHelper.Cos(theta), 0.0, 0.0},
                new[]{0.0, 0.0, 1.0, 0.0},
                new[]{0.0, 0.0, 0.0, 1.0}
            });
        }

        public override String ToString()
        {
            return "Matrix <4x4>:\n"
               + "|" + this[1, 1] + "," + this[1, 2] + "," + this[1, 3] + "," + this[1, 4] + "|\n"
               + "|" + this[2, 1] + "," + this[2, 2] + "," + this[2, 3] + "," + this[2, 4] + "|\n"
               + "|" + this[3, 1] + "," + this[3, 2] + "," + this[3, 3] + "," + this[3, 4] + "|\n"
               + "|" + this[4, 1] + "," + this[4, 2] + "," + this[4, 3] + "," + this[4, 4] + "|";
        }

        public static Matrix4 operator +(Matrix4 m1, Matrix4 m2)
        {
            return m1.Add(m2);
        }

        public static Matrix4 operator +(Matrix4 m, Double d)
        {
            return m.Add(d);
        }

        public static Matrix4 operator -(Matrix4 m1, Matrix4 m2)
        {
            return m1.Subtract(m2);
        }

        public static Matrix4 operator -(Matrix4 m, Double d)
        {
            return m.Subtract(d);
        }

        public static Matrix4 operator *(Matrix4 m1, Matrix4 m2)
        {
            return m1.Multiply(m2);
        }

        public static Matrix4 operator *(Matrix4 m, Double d)
        {
            return m.Multiply(d);
        }

        public static Matrix4 operator *(Double d, Matrix4 m)
        {
            return m.Multiply(d);
        }

        public static Matrix4 operator /(Matrix4 m, Double d)
        {
            return m.Divide(d);
        }

        public static bool operator ==(Matrix4 m1, Matrix4 m2)
        {
            return MathsHelper.NearlyEquals(m1[1, 1], m2[1, 1]) && MathsHelper.NearlyEquals(m1[1, 2], m2[1, 2]) && MathsHelper.NearlyEquals(m1[1, 3], m2[1, 3]) && MathsHelper.NearlyEquals(m1[1, 4], m2[1, 4]) &&
                   MathsHelper.NearlyEquals(m1[2, 1], m2[2, 1]) && MathsHelper.NearlyEquals(m1[2, 2], m2[2, 2]) && MathsHelper.NearlyEquals(m1[2, 3], m2[2, 3]) && MathsHelper.NearlyEquals(m1[2, 4], m2[2, 4]) &&
                   MathsHelper.NearlyEquals(m1[3, 1], m2[3, 1]) && MathsHelper.NearlyEquals(m1[3, 2], m2[3, 2]) && MathsHelper.NearlyEquals(m1[3, 3], m2[3, 3]) && MathsHelper.NearlyEquals(m1[3, 4], m2[3, 4]) &&
                   MathsHelper.NearlyEquals(m1[4, 1], m2[4, 1]) && MathsHelper.NearlyEquals(m1[4, 2], m2[4, 2]) && MathsHelper.NearlyEquals(m1[4, 3], m2[4, 3]) && MathsHelper.NearlyEquals(m1[4, 4], m2[4, 4]);
        }

        public static bool operator !=(Matrix4 m1, Matrix4 m2)
        {
            return !(m1 == m2);
        }

        public bool Equals(Matrix4 other)
        {
            return Equals(other._data, _data);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (obj.GetType() != typeof (Matrix4)) return false;
            return Equals((Matrix4) obj);
        }

        public override int GetHashCode()
        {
            return (_data != null ? _data.GetHashCode() : 0);
        }
    }
}
