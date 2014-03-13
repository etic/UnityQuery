UnityQuery
==========

UnityQuery makes scene traversal in Unity3D cleaner.

Let's say you want to color every other child of the current GameObject red.  A straightforward implementation might look like this:
```csharp
for (int i = 0; i < transform.childCount; i += 2) {
    Transform child = transform.GetChild(i);
    Renderer r = child.GetComponent<Renderer>();
    if (r != null) {
        r.sharedMaterial.color = Color.red;
    }
}
```

Using LINQ instead, you might end up with something like this:
```csharp
Enumerable
    .Range(0, transform.childCount)
    .Where(n => n % 2 == 0)
    .Select(n => transform.GetChild(n).GetComponent<Renderer>())
    .OfType<Renderer>()
    .Select(r => r.sharedMaterial.color = Color.red);
```

Here's what it looks like with UnityQuery:
```csharp
UQ(transform)
    .Children()
    .Even()
    .ForEach<Renderer>(r => r.sharedMaterial.color = Color.red);
```

Version
----

Don't use this (yet).  I'm pushing things to Github just 'cause.

License
----

MIT
