using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    float xInput;
    float yInput;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input for movement
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

       // Vector3 forceMovement = new Vector3 (xInput, 0f, yInput) * moveSpeed;
        //rb.AddForce(forceMovement);
    }

    void FixedUpdate()
    {
      Vector3 movement =(xInput * transform.right + yInput * transform.forward).normalized;
     if(movement == Vector3.zero)
     {
        rb.linearVelocity = Vector3.zero;
     }
     else
     {
         rb.linearVelocity = movement * moveSpeed;
     }
    }
}