using System;

namespace Puzzle
{
  class Program
  {
    static void Main(string[] args)
    {
      if (args.Length == 0)
      {
        Console.WriteLine("No arguments passed.");
      }
      else
      {
        string input = args[0];
        RunTest(input, "WithReader", InverseCaptcha.WithReader);
        RunTest(input, "WithLinq", InverseCaptcha.WithLinq);
      }
      
      Console.Read();
    }

    private static void RunTest(string input, string title, Func<string, int> captcha)
    {
      int result = 0;
      long elapsed = Profiler.Profile(() => result = captcha(input));
      Console.WriteLine($"{title} returned {result} and took {elapsed} ticks");
    }
  }
}
