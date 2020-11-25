using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldAgent : WorldObject
{

    [Header("Eat Action")]
    public List<WorldItem> eatPreconditions;
    public List<WorldItem> eatEffects;

    protected override void Start() {
        base.Start();

        actions.Add(new EatAction("Eat Food", eatPreconditions, eatEffects, this));
    }
}
