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
        // Actions that every world object should have
        actions.Add(new GuardAction("Guard: " + objectName, new List<WorldItem>(), new List<WorldItem>(), this));
    }

    // TODO - this is broken as is, if object is destroyed while there is a reference to its actions it will break reference
    public void DestroyThisObject() {
        Destroy(this.gameObject);

        foreach(Action action in actions) {
            action.Remove();
            // need a check in here that action is not reserved?
        }
    }
}
