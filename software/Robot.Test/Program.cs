using System;
using System.Drawing;
using System.IO;
using System.Net.Mime;
using RaspberryCam;
using RaspberryCam.Clients;
using Robot.Core;

namespace Robot.Test
{
    class Program
    {
        static void Main(string[] args)
        {
           // var robot = new BaseRobot();
           // robot.Bus.Messages.Subscribe(Console.WriteLine);
            //var videoClient = new TcpVideoClient("robopi", 8080);
            //videoClient.StartVideoStreaming(new PictureSize(10,10)); //Open hardware
            //var data = videoClient.GetVideoFrame(10); //data contains a simple jpeg frame
            //using (var ms = new MemoryStream(data))
            //{
            //    Image.FromStream(ms).Save("Test.jpg");
            //}

            Console.ReadLine();
        }
    }
}
