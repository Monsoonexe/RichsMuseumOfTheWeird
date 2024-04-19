public static void AccountForEverything (double a)
{
    double b = 5.0;

    if (a >= b)
    {
        Console.WriteLine("a is gte b");
    }
    else if (a <= b)
    {
        Console.WriteLine("a is lte b");
    }
    else
    {
        // control can reach here if a: double.NaN;
        Console.WriteLine("wat?");
    }
}

///////////////////////////////////////////////////////

public class MyMonoBehaviour : MyMonoBehaviour
{
    public void Print() => Debug.Log("wat?");
}

public static void UnityDerpiness()
{
    // assemble
    GameObject gameObject = new GameObject();
    MyMonoBehaviour mono = gameObject.AddComponent<MyMonoBehaviour>();

    if (mono == null)
    {
         // doesn't throw
        throw new Exception();
    }

    // act
    UnityEngine.Object.Destroy(mono);

    if (mono != null)
    {
         // doesn't throw
        throw new Exception();
    }

    object pointerToMono = mono; // null?

    if (pointerToMono == null)
    {
         // doesn't throw
        throw new Exception();
    }

    mono.Print(); // doesn't throw nullref
}

///////////////////////////////////////////////////////

[System.Serializable]
public class MyClass
{
    public readonly object myObject;
    
    public MyClass(object obj)
    {
        // this could NEVER be null, right?
        myObject = obj ?? "wat?";
    }
}

public class MyMonoBehaviour : MyMonoBehaviour
{
    public MyClass MyThing { get; set; } // unity doesn't serialize properties, right? So this is null, right???

    public void Awake()
    {
        if (MyThing != null)
        {
            object theObject = MyThing.myObject; // this can't be null, right?
            Debug.Log(theObject.ToString()); // throws NullReferenceException on .ToString()!
        }
    }
}

///////////////////////////////////////////////////////

public void HowDidThisWork()
{
    object nullObject = null;
    nullObject.MemberFunctionImposter(); // doesn't throw nullref
    Debug.Log("Wat? How did I get here? How did you call a member function on a null object without throwing a null-ref?"); // 
}

public static class MyExtensionClass
{
    // I'm an extension method!
  public static void MemberFunctionImposter(this object myObject)
  {
    // null-safe
    if (myObject == null)
        return;
    
    // ...
  }

}

