using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;

namespace WindowService
{
    public partial class Service1 : ServiceBase
    {
        private Timer timer = null;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer = new Timer();

            timer.Interval = 60000;

            timer.Elapsed += TimerTick;

            timer.Enabled = true;

            Utilities.WriteLogError("Test for fisrt run Window service!!!");
        }

        private void TimerTick(Object sender, ElapsedEventArgs args)
        {
            Utilities.WriteLogError("Timer has ticked!!!");
        }

        protected override void OnStop()
        {
            timer.Enabled = true;
            Utilities.WriteLogError("Window serivce has been stop!!!")
        }
    }
}
