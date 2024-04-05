// sometimes we refactor foreach-loops into for-loops, but this changes the semantics
// of closures due to language design choices.

public void FunWithClosures()
{
  string[] printEach = new string[] { "First", "Second", "Third" };
  List<Func<string>> printQueue = new();

  // foreach
  foreach (string message in printEach)
  {
    // captures the variable 'message' as if it were a local
    // variable each iteration, which is what you probably want
    printQueue.Add(() => message);
  }

  foreach (Func<string> closure in printQueue)
  {
    // prints "First", "Second", "Third"
    Console.WriteLine(closure());
  }

  printQueue.Clear();

  // for
  for (int i = 0; i < printEach.Length; ++i)
  {
    // captures the variable 'i', which is shared amongst all closures
    printQueue.Add(() => printEach[i]);
  }

  foreach (Func<string> closure in printQueue)
  {
    // IndexOutOfRangeException
    // because the variable 'i' was captured and the loop counter increased
    // it beyond 'printEach.Length'
    Console.WriteLine(closure());
  }

  // to fix it
  for (int i = 0; i < printEach.Length; ++i)
  {
     // this local variable is enclosed uniquely each iteration
    string message = printEach[i];
    printQueue.Add(() => message);
  }
}
