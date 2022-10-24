// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;

Console.WriteLine ("Hello, World!");
//ThreadRunner.Start ();
DelegateRunner.Start ();
Console.Read ();

class DelegateRunner {
  delegate int NumDelegate (int a);

  public static void Start () {
    NumDelegate del1 = delegate (int a) {
      return a * 2;
    };
    NumDelegate del2 = delegate (int a) {
      return a * 3;
    };

    var del3 = del1 + del2;
    var result = del3 (5);
    Console.WriteLine (result);

  }
}

class ThreadRunner {

  static readonly object _locker = new ();
  static readonly ManualResetEvent _mre = new (false);
  static readonly Semaphore _semaphore = new (2, 3);
  static readonly Mutex _mutex = new ();
  public static void Start () {
    Console.WriteLine ("Main thread: Do some work.");
    for (int i = 0; i < 4; i++) {
      new Thread (ThreadMethod).Start ();
    }
    Console.WriteLine ("Main thread: Thread t has ended.");
  }
  private static void ThreadMethod () {
    try {
      Console.WriteLine ($"Thread {Environment.CurrentManagedThreadId} is wainitng");
      _semaphore.WaitOne ();
      Console.WriteLine ($"Thread {Environment.CurrentManagedThreadId} is running");
      Thread.Sleep (2000);
      Console.WriteLine ($"Thread {Environment.CurrentManagedThreadId} is completed");
      _semaphore.Release ();

    } catch (Exception exc) {
      Console.WriteLine (exc.Message);
    } finally { }
  }
}