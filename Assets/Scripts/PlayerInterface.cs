using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterface : MonoBehaviour
{
    // Camera
    public Camera playerCamera;
    public float moveSpeed = 5f;

    // UI
    public UIManager UIManager;

    private Agent currentSelectedAgent;

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
                if (hit.transform.GetComponent<Agent>()) {
                    if (currentSelectedAgent)   {
                        currentSelectedAgent.Deselect();
                        currentSelectedAgent.onActionComplete.RemoveAllListeners();    
                    }
            
                    currentSelectedAgent = hit.transform.GetComponent<Agent>();
                    currentSelectedAgent.Select();

                    // Update UI Hooks and view
                    currentSelectedAgent.onActionComplete.AddListener(() => UIManager.UpdateActionScrollView(currentSelectedAgent));
                    currentSelectedAgent.onActionComplete.AddListener(() => UIManager.UpdateInventoryScrollView(currentSelectedAgent));

                    UIManager.UpdateActionScrollView(currentSelectedAgent);
                    UIManager.UpdateInventoryScrollView(currentSelectedAgent);
                }
            }
        }
    }
    

}
