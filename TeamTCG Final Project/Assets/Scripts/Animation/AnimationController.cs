using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash; 

    float velocityZ = 0f;
    float velocityX = 0f;
    public float acceleration = 2.0f;
    public float deceleration = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
    }

    // Update is called once per frame
    void Update()
    {
        bool backwardPressed = Input.GetKey("w");
        bool forwardPressed = Input.GetKey("s");
        bool leftPressed = Input.GetKey("d");
        bool rightPressed = Input.GetKey("a");

        if(forwardPressed && velocityZ < 1.0f)
        {
            velocityZ += Time.deltaTime * acceleration;
        } 
        if(backwardPressed && velocityZ > -1.0f)
        {
            velocityZ -= Time.deltaTime * acceleration;
        }
        if(leftPressed && velocityX > -0.5f)
        {
            velocityX -= Time.deltaTime * acceleration;
        }
        if(rightPressed && velocityX < 0.5f)
        {
            velocityX += Time.deltaTime * acceleration;
        }

        //decrease velocityX
        if(!forwardPressed && velocityZ > 0.0f)
        {
            velocityZ -= Time.deltaTime * deceleration;
        }
        if(!backwardPressed && velocityZ < 0.0f)
        {
            velocityZ += Time.deltaTime * deceleration;
        }

        //reset velocity Z
        if(!forwardPressed && !backwardPressed && velocityZ != 0.0f && (velocityZ > -0.05f && velocityZ < 0.05f))
        {
            velocityZ = 0.0f;
        }

        //increase velocity if left not pressed and veloxity < 0
        if(!leftPressed && velocityX < 0.0f)
        {
            velocityX += Time.deltaTime * deceleration;
        }
        if(!rightPressed && velocityX > 0.0f)
        {
            velocityX -= Time.deltaTime * deceleration;
        }
        //reset velocityX
        if(!leftPressed && !rightPressed && velocityX != 0.0f && (velocityX > -0.05f && velocityX < 0.05f))
        {
            velocityX = 0.0f;
        }
        animator.SetFloat("Velocity Z", velocityZ);
        animator.SetFloat("Velocity X", velocityX);
    
    }
}
