using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PickupDebris : MonoBehaviour
{

    public InputActionReference grab = null;

    float grabValue;

    void Start()
    {
       // count = 0;
    }

    void Update()
    {
        RaycastHit hit;
        int layerN = 1 << 6;

        //if grab set inactive
        grabValue = grab.action.ReadValue<float>();

        if (Physics.Raycast(transform.position, transform.forward, out hit, 100, layerN) )
        {
            hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;

          /*  if (grabValue > 0.5f)
            {
                StartCoroutine(DestroyDebris(hit.transform.gameObject));
                SetCountText();
            }*/
            
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.yellow);

        }
        else
        {         
           // hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
            
            Debug.DrawRay(transform.position, transform.forward * 1000, Color.yellow);
            Debug.Log("Did not Hit");
        }

    }

    IEnumerator DestroyDebris(GameObject hit)
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(hit.transform.gameObject);
       // count++;
    }

       //increase count
    void SetCountText ()
    {
       // countText.text = count.ToString();
    }
}
