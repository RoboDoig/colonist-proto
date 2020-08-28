using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Pretty sure this is OBSOLETE with WorldAgent, WorldAgent arch. is cleaner
public class AgentActions : MonoBehaviour
{
    [Header("Eat Action")]
    public List<WorldItem> eatPreconditions;
    public List<WorldItem> eatEffects;

    void Start() {
        Agent agent = GetComponent<Agent>();

        string descriptionString = "Eat: " + eatPreconditions[0].Description();
        agent.agentActions.Add(new EatAction(descriptionString, eatPreconditions, eatEffects, null));
    }
}
