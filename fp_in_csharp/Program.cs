// See https://aka.ms/new-console-template for more information
Func<T, bool> NegatePredicate<T> (Func<T, bool> predicate) => f => !predicate (f);

var predicated = Enumerable.Range (0, 100).Where (NegatePredicate<int> (x => x % 4 != 0)).ToArray ();
var predicatedStr = string.Join (',', predicated);
Console.WriteLine (predicatedStr);