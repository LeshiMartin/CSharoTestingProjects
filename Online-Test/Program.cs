// See https://aka.ms/new-console-template for more information
Console.WriteLine ("Hello, World!");

static void PrintCombinations2 (char[] elems) {
  var passedCombinations = new Dictionary<string, string> ();
  for (var i = 0; i < elems.Length; i++) {
    var current = elems[i];
    for (int j = i + 1; j < elems.Length; j++) {
      var next = elems[j];
      var combination = string.Join ("", new char[] { current, next });
      if (passedCombinations.ContainsKey (combination))
        continue;
      Console.WriteLine (combination);
    }
  }
}
static void PrintCombinations3 (char[] elems) {
  var passedCombinations = new Dictionary<string, string> ();
  for (var i = 0; i < elems.Length; i++) {
    var current = elems[i];
    for (int j = i + 1; j < elems.Length; j++) {
      var next = elems[j];
      for (int u = j + 1; u < elems.Length; u++) {
        var combination = string.Join ("", new char[] { current, next, elems[u] });
        if (passedCombinations.ContainsKey (combination))
          continue;
        Console.WriteLine (combination);
      }
    }
  }
}

static void PrintCombinations (char[] elems, int k) {
  var passedCombinations = new Dictionary<string, string> ();
  for (var i = 0; i < elems.Length; i++) {
    var current = elems[i];
    _printCombinations (elems, k - 1, i + 1, current.ToString(), passedCombinations);
  }
}

static void _printCombinations (char[] elems,
  int k,
  int currentIndex,
  string comb,
  Dictionary<string, string> passedCombinations) {

  for (var i = currentIndex; i < elems.Length; i++) {
    var current = elems[i];
    var newComb = comb + current;
    if (k == 1) {
      if (passedCombinations.ContainsKey (newComb)) { continue; }
      Console.WriteLine (newComb);
      passedCombinations.Add (newComb, newComb);
      continue;
    }
    _printCombinations (elems, k - 1, i + 1, newComb, passedCombinations);
  }
}

var testElems = new char[] { 'a', 'b', 'c', 'd', 'e' };
var k = 1;
PrintCombinations (testElems,k);