using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<WorldItem> inventoryItems = new List<WorldItem>();

    public void AddItem(WorldItem item) {
        // Check ItemDefinition type is in inventory, if it is add to the amount
        foreach(WorldItem inventoryItem in inventoryItems) {
            // TODO - this structure is repeating alot
            if (item.itemDefinition == inventoryItem.itemDefinition) {
                inventoryItem.amount += item.amount;
                return;
            }
        }

        inventoryItems.Add(new WorldItem(item.itemDefinition, 1));
    }

    public void RemoveItem(WorldItem item) {
        // HERE TODO
        foreach(WorldItem inventoryItem in inventoryItems) {
            if (item.itemDefinition == inventoryItem.itemDefinition) {
                inventoryItem.amount -= item.amount;
            }
        }
    }

    public bool HasItem(WorldItem item) {
        // AND HERE TODO
        foreach(WorldItem inventoryItem in inventoryItems) {
            if (item.itemDefinition == inventoryItem.itemDefinition) {
                if (inventoryItem.amount >= item.amount) {
                    return true;
                }
            }
        }
        return false;
    }

    public void Transfer(WorldItem item, Inventory toInventory) {

    }

    public List<WorldItem> GetItems() {
        return new List<WorldItem>(inventoryItems);
    }
}
