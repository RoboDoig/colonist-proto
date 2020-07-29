using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItemPickup : WorldObject
{

    public List<WorldItem> preconditions;
    public List<WorldItem> effects;

    protected override void Start() {
        base.Start();
        string descriptionString = "Pick up: " + effects[0].Description();

        actions.Add(new ItemPickupAction(descriptionString, new List<WorldItem>(preconditions), new List<WorldItem>(effects), this));
    }
}
