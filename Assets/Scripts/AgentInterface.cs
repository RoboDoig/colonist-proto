using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentInterface : MonoBehaviour
{
    public Material selectMaterial;
    public Material deselectMaterial;
    private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select() {
        GetComponent<MeshRenderer>().material = selectMaterial;
    }

    public void Deselect() {
        GetComponent<MeshRenderer>().material = deselectMaterial;
    }
}
