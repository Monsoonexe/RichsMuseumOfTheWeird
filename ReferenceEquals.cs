public void NewStringsAreEqual()
{
    string x = new string(new char[0]);
    string y = new string(new char[0]);
    Assert.IsTrue(object.ReferenceEquals(x, y));
}

// https://stackoverflow.com/questions/194484/whats-the-strangest-corner-case-youve-seen-in-c-sharp-or-net#:~:text=What%20will%20this%20function%20do%20if%20called%20as%20Rec(0)%20(not%20under%20the%20debugger)%3F
static void Rec(int i)
{
    Console.WriteLine(i);
    if (i < int.MaxValue)
    {
        Rec(i + 1);
    }
}