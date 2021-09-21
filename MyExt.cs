using System;
using System.Collections.Generic;

namespace MyExt
{
  public static class MyMethods
  {
    public static int Square(this int n)
    {
      return n * n;
    }

    public static int Total(this List<int> ints)
    {
      int total = 0;
      ints.ForEach(i =>
      {
        total += i;
      });
      return total;
    }

    public static IEnumerable<T> Map<T, U>(this IEnumerable<U> enumerable, Func<U, T> fn)
    {
      var storage = new List<T>();
      foreach (var item in enumerable)
      {
        var result = fn(item);
        storage.Add(result);
      }
      return storage;
    }
  }
}
