using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatActionObject : ActionObject
{

    public override Action GetAction(WorldItem item, WorldObject _parentObject)
    {
        List<WorldItem> preconditions = new List<WorldItem>();
        List<WorldItem> effects = new List<WorldItem>();

        preconditions.Add(item);

        for (int x = 0; x < item.amount; x++) {
            foreach (WorldItem consumeEffect in item.itemDefinition.agentUseEffects) {
                effects.Add(new WorldItem(consumeEffect.itemDefinition, consumeEffect.amount));
            }
        }

        return new EatAction("Eat: " + item.Description(), preconditions, effects, _parentObject);
    }
}