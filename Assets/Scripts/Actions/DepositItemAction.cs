using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepositItemAction : Action
{
    public DepositItemAction(string _description, List<WorldItem> _preconditions, List<WorldItem> _effects, WorldDepositPoint _parentObject) 
    : base(_description, _preconditions, _effects, _parentObject) {

    }

    public override void ActionComplete(Agent agent) {
        base.ActionComplete(agent);

        
    }
}
