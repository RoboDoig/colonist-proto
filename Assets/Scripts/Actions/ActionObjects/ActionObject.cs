using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionObject : MonoBehaviour
{

    public List<WorldItem> preconditions;
    public List<WorldItem> effects;

    public virtual Action GetAction(WorldObject _parentObject) {
        return new Action("Action", preconditions, effects, _parentObject);
    }
}
