using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public namespace UnityQuery {

	public static class UQExtensions {

    public static UQObject UQ(this Object, GameObject gameObject) {
      return new UQObject(new GameObject[]{gameObject});
    }

    public static UQObject UQ(this Object, IEnumerable<GameObject> gameObjects) {
      return new UQObject(gameObjects);
    }

    public static UQObject UQ(this Object, Component component) {
      return new UQObject(new GameObject[]{component.gameObject});
    }

    public static UQObject UQ(this Object, IEnumerable<Component> components) {
      return new UQObject(components.Select(x => x.gameObject));
    }

    public static UQObject UQ(this Component) {
      return new UQObject(new GameObject[]{this.gameObject});
    }

	}

}
