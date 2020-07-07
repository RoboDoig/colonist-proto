using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action
{
    public static List<Action> availableActions = new List<Action>();
    // List of preconditions
    public List<WorldItem> preconditions;
    // List of effects
    public List<WorldItem> effects;

    public Action(List<WorldItem> _preconditions, List<WorldItem> _effects) {
        preconditions = _preconditions;
        effects = _effects;
        availableActions.Add(this);
    }

    // Checks if a given agent can perform this action
    public bool CheckPreconditions(Agent agent) {
        return true;
    }

    // Tells a given agent how to perform this action
    public bool PerformAction(Agent agent) {
        return true;
    }

    public void ActionComplete() {
        availableActions.Remove(this);
    }
}
