using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldResource : WorldObject
{
    protected override void Start() {
        base.Start();
        string descriptionString = "Collect Resource: " + effects[0].item.type + " (" + effects[0].amount.ToString() + ")";

        actions.Add(new CollectResourceAction(descriptionString, new List<WorldItem>(preconditions), new List<WorldItem>(effects), this));
    }
}
