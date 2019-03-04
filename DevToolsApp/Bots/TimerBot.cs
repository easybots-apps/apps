using Easybots.Apps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easybots.DevTools.Bots
{
    internal class TimerBot : Easybot
    {
        private System.Timers.Timer oneSecondTimer = new System.Timers.Timer(1000);
        private System.Timers.Timer fiveSecondsTimer = new System.Timers.Timer(5000);
        private System.Timers.Timer tenSecondsTimer = new System.Timers.Timer(10000);
        
        public TimerBot() : base("Timer") // dev note: 'Timer' is hardcoded in the tutorial values in the web project
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
        public void OneSecondElapsed() // dev note: 'OneSecondElapsed' is hardcoded in the tutorial values in the web project
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
