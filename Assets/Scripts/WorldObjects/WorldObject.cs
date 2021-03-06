﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject : MonoBehaviour
{
    public string objectName;
    public List<Action> actions = new List<Action>();
    // How many actions are default? i.e. come from the parent class defaults
    public int nDefaultActions {get; protected set;}

    protected virtual void Start() {
        // Actions that every world object should have
        actions.Add(new GuardAction("Guard: " + objectName, new List<WorldItem>(), new List<WorldItem>(), this));

        nDefaultActions = actions.Count;
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
