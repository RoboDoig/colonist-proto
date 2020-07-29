using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentActions : MonoBehaviour
{
    [Header("Eat Action")]
    public List<WorldItem> eatPreconditions;
    public List<WorldItem> eatEffects;
}
