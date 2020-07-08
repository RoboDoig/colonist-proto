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
    // List of effectss
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
    public virtual bool PerformAction(Agent agent) {
        agent.SetDestination(parentObject.transform.position);
        if ((agent.transform.position - parentObject.transform.position).magnitude < agent.reachDistance) {
            ActionComplete(agent);
            return true;
        }

        return false;
    }

    // When an action completes
    public virtual void ActionComplete(Agent agent) {
        Debug.Log("Action Complete");
        availableActions.Remove(this);
        parentObject.actions.Remove(this);
    }

    public void Remove() {
        availableActions.Remove(this);
    }
}
