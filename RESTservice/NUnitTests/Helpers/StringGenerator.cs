using System;
using System.Linq;

namespace NUnitTests.Helpers
{
    public class StringGenerator
    {
        private Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public string RandomStringGenerator(int item)
        {
            return new string(
                Enumerable.Repeat(chars, item)
                .Select(s => s[random.Next(s.Length)])
                .ToArray()
                );
        }
    }
}
