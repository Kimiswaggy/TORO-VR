using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonControl : MonoBehaviour
    
{
    public float speed = 3.0f;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(transform.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(transform.forward*-1* Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(transform.right*-1 * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(transform.right * Time.deltaTime * speed);
        }

        float MouseX = Input.GetAxis("MouseX");
        float MouseY = Input.GetAxis("MouseY");
        transform.Rotate(-MouseY, MouseX, 0);
        //transform.Rotate(MouseY, 0, 0);
    }
}
