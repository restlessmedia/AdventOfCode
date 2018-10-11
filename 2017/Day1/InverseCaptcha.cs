using System.IO;
using System.Linq;

namespace Puzzle
{
  public class InverseCaptcha
  {
    internal static int WithReader(string input)
    {
      if (string.IsNullOrEmpty(input))
      {
        return 0;
      }

      // make input circular by adding first char onto end of string
      input = input + input[0];

      int total = 0;

      using (StringReader reader = new StringReader(input))
      {
        int current;

        while ((current = reader.Read()) != -1)
        {
          if (current == reader.Peek())
          {
            total = total + GetNumericValue((char)current);
          }
        }
      }

      return total;
    }

    internal static int WithLinq(string input)
    {
      if (string.IsNullOrEmpty(input))
      {
        return 0;
      }

      // make input circular by adding first char onto end of string
      input = input + input[0];

      // we filter the chars in the enumerable by checking the next character in the sequence and then pass this to the sum function
      // we use SingleOrDefault because in the enumerable, when we get to the last char there won't be another so the default will be 0 which is fine to carry through to the sum
      return input.Where((c, i) => input.Skip(i + 1).Take(1).SingleOrDefault().Equals(c)).Sum(GetNumericValue);
    }

    private static int GetNumericValue(char value)
    {
      return int.Parse(value.ToString());
    }
  }
}