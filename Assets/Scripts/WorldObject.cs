using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject : MonoBehaviour
{
    public string objectName;

    public List<WorldItem> preconditions;
    public List<WorldItem> effects;

}
