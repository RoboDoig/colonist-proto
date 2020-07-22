using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    // Selection
    public Material selectMaterial;
    public Material deselectMaterial;

    // Interaction params
    public float reachDistance = 1f;  

    private NavMeshAgent navMeshAgent;
    public Inventory inventory;
    public Stats stats;
    private List<Action> actionQueue;
    private Action currentAction;
    public float workTimer {get; private set;}
    private List<Action> agentActions = new List<Action>();

    // Events
    public UnityEvent onActionComplete;

    void Start() {
        actionQueue = new List<Action>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        inventory = GetComponent<Inventory>();
        stats = GetComponent<Stats>();
        workTimer = 0f;

        // add personal actions
    }

    void Update() {
        // Check if we need to switch actions
        if (currentAction == null && actionQueue.Count > 0) {
            currentAction = actionQueue[0];
        }

        if (currentAction != null) {
            currentAction.PerformAction(this);
            if (currentAction.isComplete) {
                ActionComplete(currentAction);
            }
        }
    }

    public void Select() {
        GetComponent<MeshRenderer>().material = selectMaterial;
    }

    public void Deselect() {
        GetComponent<MeshRenderer>().material = deselectMaterial;
    }

    // Returns a list of actions that are doable by this agent in its current state
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

    public void ActionComplete(Action action) {
        action.ActionComplete(this);

        actionQueue.Remove(currentAction);
        currentAction = null;
        workTimer = 0f;

        // Fire an action complete event
        onActionComplete.Invoke();
    }

    public float UpdateWorkTimer() {
        workTimer += Time.deltaTime;
        return workTimer;
    }

    // Sets the agent's destination
    public void SetDestination(Vector3 target) {
        navMeshAgent.SetDestination(target);
    }

    // Get the agent's current WorldItem state (inventory + stats)
    public List<WorldItem> GetState() {
        return new List<WorldItem>();
    }
}
