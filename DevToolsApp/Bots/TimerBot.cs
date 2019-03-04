using Easybots.Apps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easybots.DevTools.Bots
{
    /// <summary>
    /// Bot that informs the Easybots platform when certain amount of time has passed.    
    /// </summary>
    internal class TimerBot : Easybot
    {
        private System.Timers.Timer oneSecondTimer = new System.Timers.Timer(1000);
        private System.Timers.Timer fiveSecondsTimer = new System.Timers.Timer(5000);
        private System.Timers.Timer tenSecondsTimer = new System.Timers.Timer(10000);
        
        public TimerBot() : base("Timer")
        {
            this.oneSecondTimer.Elapsed += (sender, e) => this.OneSecondElapsed();
            this.fiveSecondsTimer.Elapsed += (sender, e) => this.FiveSecondsElapsed();
            this.tenSecondsTimer.Elapsed += (sender, e) => this.TenSecondsElapsed();
            this.oneSecondTimer.Start();
            this.fiveSecondsTimer.Start();
            this.tenSecondsTimer.Start();
        }        

        [Trigger("Fired every second")]
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public void OneSecondElapsed()
        {
            this.TriggerInEasybotsPlatform();
        }

        [Trigger("Fired every 5 seconds")]
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public void FiveSecondsElapsed()
        {
            this.TriggerInEasybotsPlatform();
        }

        [Trigger("Fired every 10 seconds")]
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public void TenSecondsElapsed()
        {
            this.TriggerInEasybotsPlatform();
        }
    }
}
