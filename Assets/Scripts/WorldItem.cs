using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class WorldItem
{
    public WorldItemDefinition item;
    public float amount;

    public string Description() {
        string descriptorString = amount + " " + item.type;

        return descriptorString;
    }
}