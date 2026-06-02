using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HitRayHand : MonoBehaviour
{
    int layerN = 1 << 3;
    public GameObject match;
    public GameObject flame;
    public InputActionReference light = null;
    float triggerValue;
    bool isTriggered;

    void Start()
    {

    }

    void Update()
    {
        RaycastHit hit;
        triggerValue = light.action.ReadValue<float>();

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100, layerN) && triggerValue > 0.5f)
        {
            if (!isTriggered)
            {
                Debug.Log(hit.transform.gameObject + "got hit");
                Vector3 pos = new Vector3(hit.transform.position.x, hit.transform.position.y + 0.5f, hit.transform.position.z);
                GameObject newFlame = Instantiate(flame, pos, Quaternion.identity);

                Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.yellow);
                Debug.Log("Did Hit" + hit.transform.gameObject);

                isTriggered = true;
            }
           
        }

        else
        {
            Debug.DrawRay(transform.position, transform.forward * 1000, Color.yellow);
            // Debug.Log("Did not Hit");
            isTriggered = false;
        }
    }
}
