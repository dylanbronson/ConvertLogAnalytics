using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace ConvertLogAnalytics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");
            string text = System.IO.File.ReadAllText(args[0]);
            Console.WriteLine("Got text");
            dynamic stuff = JsonConvert.DeserializeObject(text);
            Console.WriteLine("Got JSON. Going through now...");
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(args[1]))
            {
                foreach (var s in stuff)
                {
                    file.WriteLine(s.timestamp + " " + s.text);
                }
            }
        }
    }
}
