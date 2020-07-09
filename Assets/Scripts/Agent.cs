using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    // Selection
    public Material selectMaterial;
    public Material deselectMaterial;

    // Interaction params
    public float reachDistance = 1f;  

    private NavMeshAgent navMeshAgent;
    private Inventory inventory;
    private List<Action> actionQueue;
    private Action currentAction;

    void Start() {
        actionQueue = new List<Action>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        inventory = GetComponent<Inventory>();
    }

    void Update() {
        // Check if we need to switch actions
        if (currentAction == null && actionQueue.Count > 0) {
            currentAction = actionQueue[0];
        }

        if (currentAction != null) {
            // If action completes this update loop, remove it from the queue
            if (currentAction.PerformAction(this)) {
                actionQueue.Remove(currentAction);
                currentAction = null;
            }
        }
    }

    public void Select() {
        GetComponent<MeshRenderer>().material = selectMaterial;
    }

    public void Deselect() {
        GetComponent<MeshRenderer>().material = deselectMaterial;
    }

    // Returns a list of actions that are doable by this agent
    public List<Action> AvailableActions() {
        List<Action> availableActions = new List<Action>();

        foreach(Action action in Action.availableActions) {
            if (action.CheckProcedural(this)) {
                availableActions.Add(action);
            }
        }

        return availableActions;
    }

    // Adds an action to the queue of actions to be done
    public void AddActionToQueue(Action action) {
        actionQueue.Add(action);
        action.Reserve(this);
    }

    // Sets the agent's destination
    public void SetDestination(Vector3 target) {
        navMeshAgent.SetDestination(target);
    }

    // Give an item to this agent
    public void GiveItem(WorldItem item) {
        inventory.AddItem(item);
    }
}
