// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var _class = new TestClass();
var _manager = new TestClassManager(_class);
var _weakManager = new WeakManager(_class);
_class.Name = "NewName";

Console.WriteLine(_manager.TestClass.Name);
_manager.TestClass.Name="Test";
GC.Collect();
Console.WriteLine(_manager.TestClass.Name);
Console.WriteLine(_class.Name);
_class = null;

GC.Collect();
_weakManager.TestClass.TryGetTarget(out var target);
Console.WriteLine(target?.Name);
GC.Collect();

Console.WriteLine(target?.Name);


class TestClassManager{
  public TestClassManager(TestClass TestClass){
    this.TestClass = TestClass;  
  }

  public TestClass TestClass { get; private set; }
}

class WeakManager {
  public WeakManager(TestClass TestClass) {
    this.TestClass = new WeakReference<TestClass>(TestClass);
  }

  public WeakReference<TestClass> TestClass { get; private set; }
}
class TestClass{
  public string Name { get; set; } = string.Empty;
}