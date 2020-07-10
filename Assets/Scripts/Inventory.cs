using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<WorldItem> inventoryItems = new List<WorldItem>();

    public void AddItem(WorldItem item) {
        // Check ItemDefinition type is in inventory, if it is add to the amount
        foreach(WorldItem inventoryItem in inventoryItems) {
            if (item.itemDefinition == inventoryItem.itemDefinition) {
                inventoryItem.amount += item.amount;
                return;
            }
        }

        inventoryItems.Add(new WorldItem(item.itemDefinition, 1));
    }

    public void RemoveItem(WorldItem item) {
        foreach(WorldItem inventoryItem in inventoryItems) {
            if (item.itemDefinition == inventoryItem.itemDefinition) {
                inventoryItem.amount -= item.amount;
            }
        }
    }

    public void Transfer(WorldItem item, Inventory toInventory) {

    }
}
