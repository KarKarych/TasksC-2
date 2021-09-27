using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ConsoleApplication1
{
  internal class Program
  {
    public static void Main()
    {
      var classType = typeof(Test).Assembly.GetType();
      
      var args = new ArrayList
      {
        "213",
        21
      };

      var classInstance = Activator.CreateInstance(classType, args);
      var methods = classType.GetMethods();
      
      foreach (var method in methods)
      {
        Console.WriteLine(method); 
      }

      var result = methods[0].Invoke(classInstance, null);
      Console.WriteLine(result);
    }
  }

  class Test
  {
    Test(string f, int h)
    {
      F = "sda";
      H = 1;

      Console.WriteLine(f);
      Console.WriteLine(h);
    }

    private string f;

    private int h;

    public string F
    {
      get => f;
      set => f = value;
    }

    public int H
    {
      get => h;
      set => h = value;
    }
  }
}