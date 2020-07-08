using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action
{
    public static List<Action> availableActions = new List<Action>();
    public string description;

    public bool inUse = false;
    // List of preconditions
    public List<WorldItem> preconditions;
    // List of effects
    public List<WorldItem> effects;
    public WorldObject parentObject;

    public Action(string _description, List<WorldItem> _preconditions, List<WorldItem> _effects, WorldObject _parentObject) {
        description = _description;
        preconditions = _preconditions;
        effects = _effects;
        parentObject = _parentObject;

        availableActions.Add(this);
    }

    // Checks if a given agent can perform this action
    public bool CheckProcedural(Agent agent) {
        if (inUse) {
            return false;
        }
        return true;
    }

    // Request to reserve action so that other agents cannot use it. Some actions, might not need to be reserved, e.g. common actions
    public void Reserve(Agent agent) {
        inUse = true;
    }

    // Tells a given agent how to perform this action
    public bool PerformAction(Agent agent) {
        agent.SetDestination(parentObject.transform.position);
        if ((agent.transform.position - parentObject.transform.position).magnitude < agent.reachDistance) {
            ActionComplete();
            return true;
        }

        return false;
    }

    public void ActionComplete() {
        Debug.Log("action complete!");
        availableActions.Remove(this);
        parentObject.actions.Remove(this);
    }
}
