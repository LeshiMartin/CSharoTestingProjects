using System.Runtime.InteropServices;

namespace System;

public static partial class UsingExtensions {
  public static R Using<Tdisp, R> (this Tdisp disposable, Func<Tdisp, R> predicate) where Tdisp : IDisposable {
    using (disposable) return predicate (disposable);
  }

  public static R Using<R> (Func<IDisposable> dispf, Func<IDisposable, R> predicate) {
    using var d = dispf ();
    return predicate (d);
  }

  public static ValueTuple ReadOnlyForEach<T> (this List<T> list, Action<T> ? predicate = null) {
    var items = CollectionsMarshal.AsSpan (list);
    foreach (var item in items) {
      if (predicate is not null)
        predicate (item);
    }
    return default;
  }
}