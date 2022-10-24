// See https://aka.ms/new-console-template for more information

using System.Reflection;
using Reflections;
static void Test () {

  var publicClass = new PublicClass ();
  System.Console.WriteLine ($"{publicClass.PublicStr} {ReflectionHelper.Compiled (publicClass)}");
}

Test ();