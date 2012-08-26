using System;
using System.IO.Ports;

namespace Robot.Core.Devices
{
    public class TextStar : SerialPort
    {
        public enum CursorStyle { None, SolidBlock, FlashingBlock, SolidLine, FlashingLine }
        public enum CursorControl { Left, Forward, Down, Up }

        public TextStar(string port)
            : base(port, 115200)
        {
            DataReceived += TextStarDataReceived;
        }

        public new void Open()
        {
            base.Open();
            Clear();
        }

        void TextStarDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            
        }

        public void Write(char c)
        {
            var bytes = BitConverter.GetBytes(c);
            Write(bytes, 0, bytes.Length);
        }

        public void Display(object o)
        {
            Clear();
            Write(o.ToString());
        }


        public void MoveCursor(CursorControl cursor)
        {
            switch (cursor)
            {
                case CursorControl.Left:
                    Write((char)8);
                    break;
                case CursorControl.Forward:
                    Write((char)9);
                    break;
                case CursorControl.Down:
                    Write((char)10);
                    break;
                case CursorControl.Up:
                    Write((char)11);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("cursor");
            }
        }

        public void SetCursorStyle(CursorStyle cursor)
        {
            int c;

            switch (cursor)
            {
                case CursorStyle.None:
                    c = (char)0;
                    break;
                case CursorStyle.SolidBlock:
                    c = (char)1;
                    break;
                case CursorStyle.FlashingBlock:
                    c = (char)2;
                    break;
                case CursorStyle.SolidLine:
                    c = (char)3;
                    break;
                case CursorStyle.FlashingLine:
                    c = (char)4;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("cursor");
            }

            Write(new byte[] { 254, 67, (byte)c }, 0, 3);
        }

        public void Clear()
        {
            Write((char)12);
        }
    }
}
