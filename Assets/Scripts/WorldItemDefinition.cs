using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "WorldItem", menuName = "ScriptableObjects/WorldItemDefinition", order = 1)]
public class WorldItemDefinition : ScriptableObject
{
    public string type;
    public Sprite icon;
    public enum BaseType {Resource, Tool, Stat, Building}
    public BaseType baseType;
    public int maxStack;
    // Does use of this item deplete it (true, e.g. food, gold, wood) or does it have multiple uses (false, e.g. axe, sword) - TODO, this might cause problems with inventory transfer of tools.
    public bool consumable;
}