using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealActionObject : ActionObject
{
    public override Action GetAction(WorldItem item, WorldObject _parentObject)
    {
        List<WorldItem> preconditions = new List<WorldItem>();
        List<WorldItem> effects = new List<WorldItem>();

        effects.Add(item);

        return new StealAction("Steal: " + item.Description(), preconditions, effects, _parentObject);
    }
}
