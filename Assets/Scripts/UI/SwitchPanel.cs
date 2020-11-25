using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchPanel : MonoBehaviour
{
    public bool inView = true;
    public Button toggleButton;
    delegate void UpdateFunction();
    UpdateFunction updateFunction;

    Vector3 targetPosUp;
    Vector3 targetPosDown;

    void Start() {
        toggleButton.onClick.AddListener(Toggle);
        targetPosUp = transform.position;
        targetPosDown = transform.position - new Vector3(0f, 450f, 0f);
        updateFunction = SlideUp;
    }

    void Update() {
        updateFunction();
    }

    public void Toggle() {
        if (inView) {
            updateFunction = SlideDown;
            inView = false;
        } else {
            updateFunction = SlideUp;
            inView = true;
        }

    }

    void SlideDown() {
        transform.position = Vector3.MoveTowards(transform.position, targetPosDown, 5f / Time.deltaTime);
    }

    void SlideUp() {
        transform.position = Vector3.MoveTowards(transform.position, targetPosUp, 5f / Time.deltaTime);
    }
}
