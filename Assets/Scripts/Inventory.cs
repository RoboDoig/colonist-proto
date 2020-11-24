using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<InventoryItem> inventoryItems = new List<InventoryItem>();
    public List<WorldItem> startItems;
    public Agent agent;

    class InventoryItem {
        public WorldItem worldItem;
        public List<Action> associatedActions;

        public InventoryItem(WorldItem _worldItem, Agent _agent) {
            worldItem = new WorldItem(_worldItem.itemDefinition, _worldItem.amount);
            associatedActions = new List<Action>();
        }
    }

    void Start() {
        foreach(WorldItem item in startItems) {
            AddItem(item);
        }

        agent = GetComponent<Agent>();
    }

    public void AddItem(WorldItem item) {
        // Check ItemDefinition type is in inventory, if it is add to the amount
        foreach(InventoryItem inventoryItem in inventoryItems) {
            // TODO - this structure is repeating alot
            if (item.itemDefinition == inventoryItem.worldItem.itemDefinition) {
                inventoryItem.worldItem.amount += item.amount;
                UpdateItemActions(inventoryItem);
                return;
            }
        }

        InventoryItem newItem = new InventoryItem(item, agent);
        inventoryItems.Add(newItem);
        UpdateItemActions(newItem);
    }

    public void RemoveItem(WorldItem item) {
        // HERE TODO
        foreach(InventoryItem inventoryItem in inventoryItems) {
            if (item.itemDefinition == inventoryItem.worldItem.itemDefinition) {
                inventoryItem.worldItem.amount -= item.amount;
                UpdateItemActions(inventoryItem);
            }
        }
    }

    public bool HasItem(WorldItem item) {
        // AND HERE TODO
        foreach(InventoryItem inventoryItem in inventoryItems) {
            if (item.itemDefinition == inventoryItem.worldItem.itemDefinition) {
                if (inventoryItem.worldItem.amount >= item.amount) {
                    return true;
                }
            }
        }
        return false;
    }

    // When an inventory item is modified (added, removed) we must remap its associated actions
    void UpdateItemActions(InventoryItem inventoryItem) {
        // foreach(Action action in inventoryItem.associatedActions) {
        //     Action.availableActions.Remove(action);
        // }

        // inventoryItem.associatedActions.Clear();

        // if (inventoryItem.worldItem.amount > 0) {
        //     foreach (ActionObject actionObject in inventoryItem.worldItem.itemDefinition.agentActions) {
        //         inventoryItem.associatedActions.Add(actionObject.GetAction(inventoryItem.worldItem, agent.worldAgent));
        //     }
        // }
    }

    public void Transfer(WorldItem item, Inventory toInventory) {

    }

    public List<WorldItem> GetItems() {
        List<WorldItem> worldItemList = new List<WorldItem>();
        foreach(InventoryItem inventoryItem in inventoryItems) {
            worldItemList.Add(inventoryItem.worldItem);
        }
        return worldItemList;
    }
}
