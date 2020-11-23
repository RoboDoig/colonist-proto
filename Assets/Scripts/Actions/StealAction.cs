using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealAction : Action
{
    public StealAction(string _description, List<WorldItem> _preconditions, List<WorldItem> _effects, WorldObject _parentObject) 
    : base(_description, _preconditions, _effects, _parentObject) {
        actionType = ActionType.OtherAgentOnly;
    }

    public override void PerformAction(Agent agent) {
        base.PerformAction(agent);
    }

    public override void ActionComplete(Agent agent) {
        base.ActionComplete(agent);

        // In steal, we need to remove the amount stolen from the victim
        Inventory otherAgentInventory = parentObject.GetComponent<Inventory>();
        foreach (WorldItem effect in effects) {
            otherAgentInventory.GetComponent<Inventory>().RemoveItem(effect);
        }

    }
}
