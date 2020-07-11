using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    public bool isComplete {get; protected set;}

    public Action(string _description, List<WorldItem> _preconditions, List<WorldItem> _effects, WorldObject _parentObject) {
        description = _description;
        preconditions = _preconditions;
        effects = _effects;
        parentObject = _parentObject;

        availableActions.Add(this);
        isComplete = false;
    }

    // Checks if a given agent can perform this action
    public bool CheckProcedural(Agent agent) {
        // Check action is not in use (reserved)
        if (inUse) {
            return false;
        }

        // Check agent has required preconditions
        foreach (WorldItem precondition in preconditions) {
            if (!agent.inventory.HasItem(precondition)) {
                return false;
            }
        }

        return true;
    }

    // Request to reserve action so that other agents cannot use it. Some actions, might not need to be reserved, e.g. common actions
    public void Reserve(Agent agent) {
        inUse = true;
    }

    // Tells a given agent how to perform this action
    public virtual void PerformAction(Agent agent) {
        agent.SetDestination(parentObject.transform.position);

        if ((agent.transform.position - parentObject.transform.position).magnitude < agent.reachDistance) {
            isComplete = true;
        }
    }

    // When an action completes
    public virtual void ActionComplete(Agent agent) {
        availableActions.Remove(this);
        parentObject.actions.Remove(this);

        foreach(WorldItem effect in effects) {
            agent.inventory.AddItem(effect);
        }
    }

    public void Remove() {
        availableActions.Remove(this);
    }
}
