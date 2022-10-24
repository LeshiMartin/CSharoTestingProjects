using System.Reflection;

namespace Reflections {
  public static class ReflectionHelper {
    public static PropertyInfo CachedData = typeof (PublicClass)
      .GetProperty ("PrivateStr", BindingFlags.Instance | BindingFlags.NonPublic) !;

    public static Func<PublicClass, string> Compiled =
      (Func<PublicClass, string>) Delegate.CreateDelegate (
        typeof (Func<PublicClass, string>),
        CachedData!.GetGetMethod (true) !);
  }
}