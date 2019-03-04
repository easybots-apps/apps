using Easybots.Apps;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Easybots.DevTools.Bots
{
    /// <summary>
    /// Bot that represents a TextBox in the UI of this app.
    /// <para />
    /// This bot can send the text from the TextBox to the Easybots platform, 
    /// and other bots can change the text of the text box when they
    /// call the <see cref="TextBoxBot.DisplayText(string)"/> action through the Easybots platform.
    /// </summary>
    internal class TextBoxBot : Easybot
    {
        /// <summary>
        /// Dev Note: this is 'public' - to showcase usage of anonymous delegates in easybots'a actions.
        /// If this member would be private, there would be an exception in Easybots saying that "the member 'textBox' could not be found.."
        /// </summary>
        public System.Windows.Controls.TextBox textBox;

        public TextBoxBot(System.Windows.Controls.TextBox textBox)
            : base("Text Box")
        {
            if (textBox == null)
                throw new ArgumentNullException(nameof(textBox));

            this.textBox = textBox;
        }

        [Trigger]
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public string SendText()
        {
            string content = this.textBox.Text;
            this.TriggerInEasybotsPlatform(content);
            return content;
        }

        [Action("Displays the given text in the TextBox.")]        
        public void DisplayText(
             [ParameterDescription("Text", "The text to be displayed in the TextBox.", typeof(string), AllowUserInput = true)]
            string text)
        {
            this.textBox.Parent.Dispatcher.Invoke(delegate ()
            {
                this.textBox.Text = text;
            });            
        }

        [Action("Displays the items from the collection in the TextBox. Each item is displayed in new line.")]
        public void DisplayItemsAsText(
             [ParameterDescription("items", "The items to be displayed as text in the TextBox.", typeof(IEnumerable), AllowUserInput = true)]
            IEnumerable collection)
        {
            var textFromTheItems = new List<string>(); 
            foreach (var item in collection)
            {
                textFromTheItems.Add(item.ToString());
            }

            string text = string.Join(Environment.NewLine, textFromTheItems);
            this.textBox.Dispatcher.Invoke(delegate ()
            {
                this.textBox.Text = text;
            });
        }
    }   
}

