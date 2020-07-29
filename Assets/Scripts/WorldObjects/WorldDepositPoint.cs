using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldDepositPoint : WorldObject
{

    public List<WorldItem> preconditions;
    public List<WorldItem> effects;

    protected override void Start() {
        base.Start();
        string descriptionString = "Deposit: " + effects[0].Description();

        actions.Add(new DepositItemAction(descriptionString, new List<WorldItem>(preconditions), new List<WorldItem>(effects), this));
    }
}
