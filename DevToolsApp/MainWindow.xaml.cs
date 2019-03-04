using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.IO;
using Easybots.Apps;
using System.Diagnostics;
using Easybots.DevTools.Bots;

[assembly: Easybots.Apps.EasybotsApp("Dev Tools (GitHub)")]

namespace Easybots.DevTools
{    
    public partial class MainWindow : Window
    {   
        private ButtonBot buttonBot1;
        private ButtonBot buttonBot2;
        private ButtonBot buttonBot3;
        private ImageBoxBot imageBot;
        private TextBoxBot textboxBot;        
        private TimerBot timerBot;
        private UtilitiesBot utilsBot;        

        public MainWindow()
        {
            InitializeComponent();
            try
            {                
                // A link to the Easybots platform must be created before instantiating any bots
                EasybotsLink.CreateLink();                
                this.buttonBot1 = new ButtonBot("Button 1", this.button1);
                this.buttonBot2 = new ButtonBot("Button 2", this.button2);
                this.buttonBot3 = new ButtonBot("Button 3", this.button3);
                this.timerBot = new TimerBot();
                this.imageBot = new ImageBoxBot(this.image1);
                this.textboxBot = new TextBoxBot(this.textBox1);
                this.utilsBot = new UtilitiesBot();
            }
            catch (Exception exception)
            {
                // In case of exception, show the exception in Easybots Studio
                EasybotsLink.Instance.LogError(exception.ToString());

                // Show the Message Box only if the user is interactive. 
                // This is recommended approach, since the apps can be started in non-UI session through Easybots Studio
                if (Environment.UserInteractive)
                    MessageBox.Show(this, exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);                
            }
        }

        private void Button1_Clicked(object sender, RoutedEventArgs e)
        {
            this.buttonBot1.Clicked();            
        }

        private void Button2_Clicked(object sender, RoutedEventArgs e)
        {
            this.buttonBot2.Clicked();
        }

        private void Button3_Clicked(object sender, RoutedEventArgs e)
        {
            this.buttonBot3.Clicked();
        }

        private void SendText(object sender, RoutedEventArgs e)
        {
            this.textboxBot.SendText();
        }
    }
}