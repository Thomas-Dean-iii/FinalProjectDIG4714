using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreController : MonoBehaviour
{
    public static Vector3 newPose;
    public static bool SelectMove;
    public Transform storeContainer;
    public float lerpTime;


    // Update is called once per frame
    private void Update()
    {
        if(storeContainer.position != newPose && SelectMove)
        {
            storeContainer.position = Vector3.Lerp(storeContainer.position, newPose, lerpTime * Time.deltaTime);
        }
        if(Vector3.Distance(storeContainer.position, newPose) < .1f)
        {
            storeContainer.position = newPose;
            SelectMove = false; 
        }
    }
}
