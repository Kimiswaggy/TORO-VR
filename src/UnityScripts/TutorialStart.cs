using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialStart : MonoBehaviour
{
    public GameObject panel;
    public GameObject button;
    float triggerValue;
    public InputActionReference ButtonPress = null;
    int layerN = 1 << 5;

    void Start()
    {
        panel.SetActive(true);
    }


    public void Update()
    {
        RaycastHit hit;
        triggerValue = ButtonPress.action.ReadValue<float>();

        if (Physics.Raycast(transform.position, transform.forward, out hit, 100, layerN) && triggerValue > 0.5f)
        {
            panel.SetActive(false);
        }
    }
}
