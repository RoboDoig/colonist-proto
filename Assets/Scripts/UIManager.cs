using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Transform actionScrollViewContents;
    public Transform inventoryScrollViewContents;
    public GameObject actionDisplay;
    public GameObject itemDisplay;

    public void UpdateActionScrollView(Agent agent) {
        // Clear the scroll view
        foreach(Transform child in actionScrollViewContents) {
            Destroy(child.gameObject);
        }

        // Add the actions
        foreach(Action action in agent.AvailableActions()) {
            GameObject newActionDisplay = Instantiate(actionDisplay);
            newActionDisplay.transform.SetParent(actionScrollViewContents);

            // set the action text
            newActionDisplay.GetComponentInChildren<Text>().text = action.description;

            // set the clicked function for the action
            Button buttonComponent = newActionDisplay.GetComponent<Button>();
            buttonComponent.onClick.AddListener(() => { agent.AddActionToQueue(action); });
            buttonComponent.onClick.AddListener(() => { UpdateActionScrollView(agent); });
        }
    }

    public void UpdateInventoryScrollView(Agent agent) {
        // Clear ther scroll view
        foreach(Transform child in inventoryScrollViewContents) {
            Destroy(child.gameObject);
        }

        // Add item displays
        List<WorldItem> items = agent.inventory.GetItems();
        foreach(WorldItem item in items) {
            GameObject newItemDisplay = Instantiate(itemDisplay);
            newItemDisplay.transform.SetParent(inventoryScrollViewContents);

            newItemDisplay.GetComponent<Image>().sprite = item.itemDefinition.icon;
            newItemDisplay.GetComponentInChildren<Text>().text = item.amount.ToString();
        }
    }
}
