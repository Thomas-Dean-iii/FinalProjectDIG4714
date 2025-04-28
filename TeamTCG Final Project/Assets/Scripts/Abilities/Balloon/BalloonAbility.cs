using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BalloonScriptableObject",menuName = "Balloon")]
public class BalloonAbility : Ability
{
    public float balooonVelocity;
    public GameObject myBalloon;
    public PlayerController target;
    public float rotationSpeed;

    public override void Activate()
    {
        target = FindObjectOfType<PlayerController>();
        GameObject balloon = Instantiate(myBalloon, target.transform.position + new Vector3(0,0,3), Quaternion.identity) as GameObject;
        balloon.transform.SetParent(target.transform);
        //Debug.Log("Spawning Balloon");
    }
}
