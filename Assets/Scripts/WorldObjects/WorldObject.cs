using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject : MonoBehaviour
{
    public string objectName;

    public List<WorldItem> preconditions;
    public List<WorldItem> effects;
    public List<Action> actions = new List<Action>();

    protected virtual void Start() {
        actions.Add(new Action("Guard: " + objectName, new List<WorldItem>(), new List<WorldItem>(), this));
    }
}
