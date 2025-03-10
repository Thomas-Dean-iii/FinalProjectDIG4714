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
    }

    void FixedUpdate()
    {
        
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        // Ensure the movement is horizontal (ignore camera tilt)
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        
        Vector3 move = (forward * yInput + right * xInput).normalized;

        
        rb.MovePosition(transform.position + move * Time.deltaTime * moveSpeed);
    }
}