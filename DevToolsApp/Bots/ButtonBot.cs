using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Easybots.Apps;

namespace Easybots.DevTools.Bots
{   
    internal class ButtonBot : Easybot
    {
        private System.Windows.Controls.Button uiButton;
        private System.Windows.Media.Brush highlighthedBrush = System.Windows.Media.Brushes.GreenYellow;
        private System.Windows.Media.Brush originalBrush;

        public ButtonBot(string name, System.Windows.Controls.Button uiButtonParam)
            : base(name, registerNow: true)
        {
            this.uiButton = uiButtonParam;
            this.originalBrush = this.uiButton.Background;
        }

        [Action]
        public void ChangeColor()
        {
            this.uiButton.Dispatcher.Invoke(new Action(() =>
                {
                    if (this.uiButton.Background == this.originalBrush)
                        this.uiButton.Background = this.highlighthedBrush;
                    else
                        this.uiButton.Background = this.originalBrush;                    
                }));
        }
        
        [Trigger("Triggered when the button is clicked in the UI")]
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        [return: ParameterDescription("clickedTime", "The DateTime when this button was clicked", typeof(DateTime))]
        public DateTime Clicked()
        {
            DateTime now = DateTime.Now;
            this.TriggerInEasybotsPlatform(now);
            return now;
        }
    }
}
