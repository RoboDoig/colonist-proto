﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Test : MonoBehaviour
{
    public List<Stuff> stuff;

}

[Serializable]
public class Stuff {
    public WorldItem worldItem;
    public float amount;
}
