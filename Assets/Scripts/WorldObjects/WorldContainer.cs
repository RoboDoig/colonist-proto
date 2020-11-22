using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldContainer : WorldObject
{
    public List<WorldItem> preconditions;
    public List<WorldItem> items = new List<WorldItem>();

    protected override void Start() {
        base.Start();

        foreach(WorldItem item in items) {
            string descriptionString = "Collect: " + item.Description();

            List<WorldItem> contentItem = new List<WorldItem>();
            contentItem.Add(new WorldItem(item.itemDefinition, item.amount));

            actions.Add(new ItemPickupAction(descriptionString, new List<WorldItem>(preconditions), contentItem, this));
        }
    }
}
