using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BalloonScriptableObject",menuName = "Balloon")]
public class BalloonAbility : Ability
{
    public float balooonVelocity;
    public GameObject myBalloon1;
    public GameObject myBalloon2;
    public GameObject myBalloon3;
    public PlayerController target;
    public float rotationSpeed;

    public override void Activate(int level)
    {
        if (level == 1)
        {
            target = FindObjectOfType<PlayerController>();
            GameObject balloon = Instantiate(myBalloon1, target.transform.position + new Vector3(0, 1, 3), Quaternion.identity) as GameObject;
            balloon.transform.SetParent(target.transform);
        }
        else if (level == 2)
        {
            target = FindObjectOfType<PlayerController>();
            GameObject balloon = Instantiate(myBalloon1, target.transform.position + new Vector3(0, 1, 3), Quaternion.identity) as GameObject;
            GameObject balloon2 = Instantiate(myBalloon2, target.transform.position + new Vector3(0, 1, -3), Quaternion.identity) as GameObject;
            balloon.transform.SetParent(target.transform);
            balloon2.transform.SetParent(target.transform);
        }
        else if (level == 3)
        {
            target = FindObjectOfType<PlayerController>();
            GameObject balloon = Instantiate(myBalloon1, target.transform.position + new Vector3(0, 1, 3), Quaternion.identity) as GameObject;
            GameObject balloon2 = Instantiate(myBalloon2, target.transform.position + new Vector3(-3, 1, -2), Quaternion.identity) as GameObject;
            GameObject balloon3 = Instantiate(myBalloon3, target.transform.position + new Vector3(3, 1, -2), Quaternion.identity) as GameObject;
            balloon.transform.SetParent(target.transform);
            balloon2.transform.SetParent(target.transform);
            balloon3.transform.SetParent(target.transform);
        }
        else
        {
            return;
        }
        //Debug.Log("Spawning Balloon");
    }
}
