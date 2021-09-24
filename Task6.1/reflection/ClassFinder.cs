using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using VehiclesLibrary.model;

namespace Task6._1.reflection
{
  public class ClassFinder
  {
    private bool IsRealClass(Type testType)
    {
      return testType.IsAbstract == false
             && testType.IsGenericTypeDefinition == false
             && testType.IsInterface == false;
    }

    public IEnumerable<Type> ClassesImplementingInterface(string libraryName)
    {
      var types = Assembly.LoadFrom(libraryName)
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