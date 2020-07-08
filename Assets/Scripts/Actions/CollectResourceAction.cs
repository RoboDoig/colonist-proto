﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectResourceAction : Action
{
    public CollectResourceAction(string _description, List<WorldItem> _preconditions, List<WorldItem> _effects, WorldObject _parentObject) 
    : base(_description, _preconditions, _effects, _parentObject) {

    }

    
}