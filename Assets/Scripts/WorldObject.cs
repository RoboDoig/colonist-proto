using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject : MonoBehaviour
{
    public string objectName;

    public List<WorldItem> preconditions;
    public List<WorldItem> effects;
    public List<Action> actions;

    void Start() {
        actions = new List<Action>();
        actions.Add(new Action(new List<WorldItem>(preconditions), new List<WorldItem>(effects)));
    }
}
