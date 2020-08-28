using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldToolMaker : WorldObject
{
    public List<WorldItem> preconditions;
    public List<WorldItem> effects;

    protected override void Start() {
        base.Start();
        string descriptionString = "Craft: " + effects[0].Description();

        actions.Add(new CraftItemAction(descriptionString, new List<WorldItem>(preconditions), new List<WorldItem>(effects), this));
    }
}
