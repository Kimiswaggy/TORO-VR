using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    CharacterController cc;
    public float speed;
    public LayerMask groundLayer;
    public bool disabled = false;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        Vector3 movementVector = new Vector3(horizontal * speed * Time.deltaTime,
            rb.velocity.y,
            vertical * speed * Time.deltaTime);

        cc.Move(movementVector);

    }


}
