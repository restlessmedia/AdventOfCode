using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Puzzle
{
  public class Profiler
  {
    public static long Profile(Action action)
    {
      Stopwatch stopwatch = Stopwatch.StartNew();
      action();
      stopwatch.Stop();
      return stopwatch.ElapsedTicks;
    }
  }
}