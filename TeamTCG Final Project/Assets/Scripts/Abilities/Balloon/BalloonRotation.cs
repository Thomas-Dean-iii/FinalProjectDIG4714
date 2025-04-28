using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BalloonRotation : MonoBehaviour
{

    public float rotationSpeed = 100f;
    public PlayerController target;

    void Update()
    {
        target = FindObjectOfType<PlayerController>();
        this.gameObject.transform.RotateAround(target.transform.position, new Vector3(0, 1, 0), rotationSpeed * Time.deltaTime);
    }
}
