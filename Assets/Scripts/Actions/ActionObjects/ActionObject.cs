using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionObject : MonoBehaviour
{
    public virtual Action GetAction(WorldItem item, WorldObject _parentObject) {
        return new Action("Action", new List<WorldItem>(), new List<WorldItem>(), _parentObject);
    }
}
