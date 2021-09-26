using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Task6._1.reflection
{
  public class ClassFinder
  {
    private readonly string _path;
    public IEnumerable<Type> ClassesList { get; }

    public ClassFinder(string path)
    {
      _path = path;
      ClassesList = ClassesImplementingInterface();
    }

    private bool IsRealClass(Type testType)
    {
      return testType.IsAbstract == false
             && testType.IsGenericTypeDefinition == false
             && testType.IsInterface == false;
    }

    private IEnumerable<Type> ClassesImplementingInterface()
    {
      var types = Assembly.LoadFrom(_path)
        .GetTypes();
      var interfaces = types.Where(type => type.IsInterface);
      var interfacesList = interfaces.ToList();
      interfacesList.GetEnumerator().MoveNext();
      var mainInterface = interfacesList[0];

      return types
        .Where(type => type.GetInterfaces().Contains(mainInterface))
        .Where(IsRealClass);
    }
  }
}