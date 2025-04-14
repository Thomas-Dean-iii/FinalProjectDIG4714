using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;

    public float moveSpeed;
    public float RotateSpeed = 150f;
    public float GravityMultiplier = 2f;

    float xInput;
    float yInput;

    private float _vInput;
    private float _hInput;

    public Transform cameraTransform;


    Rigidbody rb;
    public CharacterScriptableObject characterData;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input for movement
        //xInput = Input.GetAxis("Horizontal");
        //yInput = Input.GetAxis("Vertical");

       // Vector3 forceMovement = new Vector3 (xInput, 0f, yInput) * moveSpeed;
        //rb.AddForce(forceMovement);

        //the vertical and horizontal input values
        _vInput = Input.GetAxis("Vertical") * characterData.MoveSpeed;
        _hInput = Input.GetAxis("Horizontal") * characterData.MoveSpeed;


    }

    void FixedUpdate()
    {

      //get camera direction
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        //combine the forward and right inputs with the camera's direction
        Vector3 direction = forward * _vInput + right * _hInput;

        //movement
        if (direction != Vector3.zero)
        {
            rb.MovePosition(rb.position + direction * Time.fixedDeltaTime);
            Quaternion targetRotation = Quaternion.LookRotation(direction);
           // rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, Time.fixedDeltaTime * RotateSpeed));
        }

        //manual gravity to avoid camera shake
        rb.AddForce(Physics.gravity * GravityMultiplier, ForceMode.Acceleration);
    }
}