using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "WorldItem", menuName = "ScriptableObjects/WorldItemDefinition", order = 1)]
public class WorldItemDefinition : ScriptableObject
{
    public string type;
    public Sprite icon;
    public enum BaseType {Resource, Tool, Stat}
    public BaseType baseType;
    public int maxStack;
    public bool consumable;
}