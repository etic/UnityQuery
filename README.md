UnityQuery
==========

UnityQuery is a library for cleaner Unity3D scene traversal.

LINQ makes it easy to handle enumerables in a functional style 90% of the time,
but a lot of operations related to scene traversal in Unity still end up being
verbose and no clearer than the straightforward implementation.  UnityQuery aims
to fix this.

Let's say you want to color every other child of the current GameObject red.
A straightforward implementation might look like this:
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

And with UnityQuery:
```csharp
UQ(transform)
    .Children()
    .Even()
    .ForEach<Renderer>(r => r.sharedMaterial.color = Color.red);
```

UnityQuery wraps each query in a `UQObject`, which lets you return to earlier
parts of a query without having to explicitly cache the results along the way.

```csharp
UQ(transform)
    .Children()
    .Even()
        .ForEach<Renderer>(r => r.sharedMaterial.color = Color.red)
        .End()
    .Odd()
        .ForEach<Renderer>(r => r.sharedMaterial.color = Color.blue);
```

`UQObject` implements `IEnumerable`, so you can use LINQ on the current query's
GameObjects without any extra work.  To return to `UQObjects`, just use the
`UQ()` extension.

```csharp
UQ(transform)
    .Descendants()
    .GetComponent<Renderer>()
    .Where(r => r.sharedMaterial.color == Color.red)
    .UQ()
    .Hidden()
    .Destroy();
```

Installation
------------

Clone the repository onto your machine and copy the `UQ` folder into your
project's `Assets` folder.

License
----

MIT
