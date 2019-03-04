using Easybots.Apps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easybots.DevTools.Bots
{
    /// <summary>
    /// Bot with helper actions for the easybots' developer to test his solutions.
    /// </summary>
    internal class UtilitiesBot : Easybot
    {
        public UtilitiesBot() : base("Utilities")
        {
        }

        [Action("Sleeps the specified number of seconds")]
        public void Sleep(
            [ParameterDescription("seconds", "Number of seconds to sleep", typeof(int), AllowUserInput = true)]
            int second)
        {
            System.Threading.Thread.Sleep(second * 1000);
        }

        [Action("Throws InvalidOperationException for testing purposes")]
        public void ThrowException()
        {
            throw new InvalidOperationException(string.Format("Exception intentionally thrown by the action '{0}'", nameof(this.ThrowException)));
        }

        [Action("Returns an array of integers with the specified number of items. The items are integers counting up from 0 or from 1, depending on the specified '0-based' parameter")]
        public int[] GenerateIntArray(
            [ParameterDescription("number of items", "number of items in the array", typeof(int), AllowUserInput = true, Order = 0)]
            [ParameterDescription("0-based", "TRUE to start the items from 0, FALSE to start from 1", typeof(bool), AllowUserInput = false, Order = 1)]
            object[] inputs)
        {
            int numberOfItems = (int)inputs[0];
            bool isZeroBased = (bool)inputs[1];
            var list = new List<int>(numberOfItems);
            int adjustment = isZeroBased ? 0 : 1;
            for (int i = 0; i < numberOfItems; i++)
            {                
                list.Add(i + adjustment);
            }

            return list.ToArray();
        }

        [Action("Returns an array of random strings with the specified number of items.")]
        public string[] GenerateStringArray(
            [ParameterDescription("number of items", "number of items in the array", typeof(int), AllowUserInput = true, Order = 0)]
            int numberOfItems)
        {            
            var list = new List<string>(numberOfItems);
            Random r = new Random();
            for (int i = 0; i < numberOfItems; i++)
            {
                int length = r.Next(2, 21);                
                string randomString = GetRandomString(length);
                list.Add(randomString);
            }

            return list.ToArray();
        }

        private static string GetRandomString(int size)
        {
            char[] chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890   ".ToCharArray(); // three '[spaces]' to add more probability for space
            byte[] data = new byte[size];
            using (var crypto = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }

            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }

            return result.ToString();
        }
    }
}
