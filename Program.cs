using System;
using System.Linq;
using MyExt;
using System.Collections.Generic;
using System.IO;

namespace Adv2
{
  public delegate int Calculate(int a, int b);
  class Program
  {
    static void Main(string[] args)
    {
      // built-in delegates
      Action<int, int> action1 = (a, b) => File.AppendAllText("./data/out.csv", $"{a},{b}\n");
      Action<int, int> action2 = (a, b) => File.AppendAllText("./data/out.csv", $"{a * a},{b / 2}\n");
      Action<int, int> action3 = (a, b) => File.AppendAllText("./data/out.csv", $"{a * a * a},{b / 3}\n");

      var tuples = new[] { (3, 4), (5, 6), (7, 8) };
      var delegates = new[] { action1, action2, action3 };

      tuples.Zip(delegates).ToList().ForEach(zipped => zipped.Second(zipped.First.Item1, zipped.First.Item2));

      // custom delegate
      Calculate product = (a, b) => a * b;
      Console.WriteLine($"the result of 3 * 4 : {product(3, 4)}");

      // or just use func
      Func<int, int, double> division = (a, b) => a / b;
      Console.WriteLine($"the result of 3 / 4 : {division(3, 4)}");

      // create a dictionary of functions
      var fnDict = new Dictionary<string, Func<int, int, double>>() {
        {"sum", (a, b) => a + b},
        {"product", (a, b) => a * b},
       };

      Console.WriteLine($"call sum from dictionary : {fnDict["sum"](1, 1)}");
      Console.WriteLine($"call product from dictionary : {fnDict["product"](2, 2)}");

      // extension methods
      var squared = (3).Square();
      Console.WriteLine(squared);

      var ints = new List<int>() { 3, 5, 7 };
      var total = ints.Total();
      Console.WriteLine(total);

      (new int[] { 3, 5, 7 }).Map(i => $"i is {i * 2}").ToList().ForEach(x => Console.WriteLine(x));

      // linq extension methods
      (new int[] { 3, 4, 5, 7 })
      .Where(val => val <= 5)
      .Select((int val, int idx) => $"{val}-{idx}")
      .ToList()
      .ForEach(s =>
        {
          Console.WriteLine($"s :: {s}");
        });
    }
  }
}
