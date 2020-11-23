using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;
using UnityEngine.UI;

public class Agent : MonoBehaviour
{
    // Selection
    public Material selectMaterial;
    public Material deselectMaterial;

    // Interaction params
    public float reachDistance = 1f;  

    private NavMeshAgent navMeshAgent;
    public Inventory inventory;
    private List<Action> actionQueue;
    private Action currentAction;
    public float workTimer {get; private set;}
    public List<Action> agentActions = new List<Action>();
    private WorldItemDefinitions worldItemDefinitions;
    public WorldAgent worldAgent {get; private set;}

    // Events
    public UnityEvent onActionComplete;

    // UI - maybe should be moved to different component
    private Slider workProgressBar;

    // Animation
    Animator anim;
    Vector3 lastPosition = Vector3.zero;

    void Start() {
        actionQueue = new List<Action>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        inventory = GetComponent<Inventory>();
        worldAgent = GetComponent<WorldAgent>();
        workTimer = 0f;

        //worldItemDefinitions = GameObject.FindGameObjectWithTag("ItemDefinitions").GetComponent<WorldItemDefinitions>();

        // UI, maybe should be moved to different component
        workProgressBar = GetComponentInChildren<Slider>();

        // Animation, maybe should be moved to a different component
        anim = GetComponent<Animator>();

        // add personal actions - actually what we need to do, every time agent's state is changed, loop through all its defined actions, add action for each relevant state item
        // List<WorldItem> preconditions = new List<WorldItem>(new WorldItem[] {new WorldItem(worldItemDefinitions.Food, 1)});
        // agentActions.Add(new EatAction("Eat: ", preconditions, new List<WorldItem>(), null));
    }

    void Update() {
        // UI Update, maybe should be moved to different component
        UpdateUI();

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

        // calculate speed and send speed to animator
        float currentSpeed = (transform.position - lastPosition).magnitude / Time.deltaTime;
        lastPosition = transform.position;
        anim.SetFloat("moveSpeed", currentSpeed);
    }

    public void Select() {
        GetComponent<Outline>().OutlineWidth = 1f;
    }

    public void Deselect() {
        GetComponent<Outline>().OutlineWidth = 0f;
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

    // maybe should be moved to separate component / event system
    private void UpdateUI() {
        if (currentAction != null) {
            workProgressBar.value = workTimer / currentAction.baseWorkTime;
        } else {
            workProgressBar.value = 0f;
        }
    }
}
