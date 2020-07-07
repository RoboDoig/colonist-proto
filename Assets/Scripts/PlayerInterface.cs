using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterface : MonoBehaviour
{
    public Camera playerCamera;
    public float moveSpeed = 5f;

    private AgentInterface currentSelectedAgent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized * Time.deltaTime * moveSpeed;

        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {

                // If we select an agent
                if (hit.transform.GetComponent<AgentInterface>()) {
                    if (currentSelectedAgent)   
                        currentSelectedAgent.Deselect();                
                    currentSelectedAgent = hit.transform.GetComponent<AgentInterface>();
                    currentSelectedAgent.Select();
                }
            }
        }
    }
}
