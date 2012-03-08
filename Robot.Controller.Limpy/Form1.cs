using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Robot.Core.Messaging;
using Robot.Micro.Core.Timing;

namespace Robot.Controller.Limpy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var robot = new Limpy(new MessageBus(), new AsyncObservableTimer()))
            {
                robot.Run();
            }
        }
    }
}
