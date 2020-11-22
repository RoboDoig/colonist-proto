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
        string descriptionString = "Eat: " + eatPreconditions[0].Description();

        // actions.Add(new EatAction(descriptionString, new List<WorldItem>(eatPreconditions), new List<WorldItem>(eatEffects), this));
    }
}
