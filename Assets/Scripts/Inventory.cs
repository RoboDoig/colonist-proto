using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<WorldItem> inventoryItems = new List<WorldItem>();

    public void AddItem(WorldItem item) {
        inventoryItems.Add(item);
    }

    public void RemoveItem(WorldItem item) {
        inventoryItems.Remove(item);
    }
}
