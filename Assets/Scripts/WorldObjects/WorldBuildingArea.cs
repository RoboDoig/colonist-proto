using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBuildingArea : WorldObject
{
    [Header("Market Stall")]
    public List<WorldItem> marketStallPreconditions;
    public List<WorldItem> marketStallEffects;
    public GameObject marketStallPrefab;

    [Header("House")]
    public List<WorldItem> housePreconditions;
    public List<WorldItem> houseEffects;
    public GameObject housePrefab;

    protected override void Start()
    {
        base.Start();

        // Add build actions
        actions.Add(new BuildAction("Build Market Stall", marketStallPreconditions, marketStallEffects, this, marketStallPrefab));
        actions.Add(new BuildAction("Build House", housePreconditions, houseEffects, this, housePrefab));
    }
}
