using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Transform actionScrollViewContents;
    public GameObject actionDisplay;

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
}
