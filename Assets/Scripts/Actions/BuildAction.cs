using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildAction : Action
{
    GameObject buildingPrefab;

    public BuildAction(string _description, List<WorldItem> _preconditions, List<WorldItem> _effects, WorldObject _parentObject, GameObject _buildingPrefab) 
    : base(_description, _preconditions, _effects, _parentObject) {
        baseWorkTime = 5f;
        buildingPrefab = _buildingPrefab;
    }

    public override void PerformAction(Agent agent) {
        base.PerformAction(agent);
    }

    public override void ActionComplete(Agent agent)
    {
        base.ActionComplete(agent);

        parentObject.DestroyThisObject();

        agent.CreateObject(buildingPrefab, parentObject.transform.position, parentObject.transform.rotation);
    }
}
