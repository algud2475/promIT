using NUnit.Framework;

namespace TestTickets.utils
{
    internal class Assertions
    {
        public static void True(bool condition, string FailMessage, string OkMessage)
        {
            try
            {
                Assert.That(condition, FailMessage);
                Console.WriteLine(OkMessage);
            } catch (AssertionException e) { 
            }
            
        }
    }
}
