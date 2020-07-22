using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WorldItemDefinitions : MonoBehaviour
{
    [Header("Resources")]
    public ItemDefinition Wood;
    public ItemDefinition Stone;
    public ItemDefinition Metal;

    [Serializable]
    public class ItemDefinition {
        public string type;
        public Sprite icon;
        public enum BaseType {Resource, Tool, Stat}
        public BaseType baseType;
        public int maxStack;
    }
}
