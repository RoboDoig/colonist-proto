using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAction : Action
{
    public GuardAction(string _description, List<WorldItem> _preconditions, List<WorldItem> _effects, WorldObject _parentObject) 
    : base(_description, _preconditions, _effects, _parentObject) {

    }

    public override bool PerformAction(Agent agent) {
        agent.SetDestination(parentObject.transform.position);

        if ((agent.transform.position - parentObject.transform.position).magnitude < agent.reachDistance) {
            if (agent.UpdateWorkTimer() >= 10f) {
                ActionComplete(agent);
                return true;
            }
        }

        return false;
    }

    public override void ActionComplete(Agent agent) {
        base.ActionComplete(agent);

        // Temporary? Once the action is completed it just gets added again
        parentObject.actions.Add(new GuardAction(this.description, this.preconditions, this.effects, this.parentObject));
    }
}
