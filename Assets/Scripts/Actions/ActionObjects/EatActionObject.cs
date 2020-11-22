using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatActionObject : ActionObject
{

    public override Action GetAction(WorldObject _parentObject)
    {
        return new EatAction("Eat", preconditions, effects, _parentObject);
    }

}