using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "BalloonScriptableObject",menuName = "Balloon")]
public class BalloonAbility : Ability
{
    public float balooonVelocity;
    public GameObject myBalloon1;
    public GameObject myBalloon2;
    public GameObject myBalloon3;
    public PlayerController target;
    public GameObject balloon1;
    public BalloonRotation balloon2;
    public BalloonRotation balloon3;

    public override void Activate(int level)
    {
        target = FindObjectOfType<PlayerController>();
        if (level == 1)
        {

            balloon1 = Instantiate(myBalloon1, target.transform.position + new Vector3(0, 1, 3), Quaternion.identity) as GameObject;
            balloon1.transform.SetParent(target.transform);
        }
        else if (level == 2)
        {
            GameObject balloon = Instantiate(myBalloon1, target.transform.position + new Vector3(0, 1, 3), Quaternion.identity) as GameObject;
            GameObject balloon2 = Instantiate(myBalloon2, target.transform.position + new Vector3(0, 1, -3), Quaternion.identity) as GameObject;
            balloon.transform.SetParent(target.transform);
            balloon2.transform.SetParent(target.transform);
        }
        else if (level == 3)
        {
            GameObject balloon = Instantiate(myBalloon1, target.transform.position + new Vector3(0, 1, 3.6f), Quaternion.identity) as GameObject;
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
    }
 
    public override void Deactivate(int level)
    {
        if (level == 1)
        {
            Destroy(balloon1);
        }
        else
        {

        }
    }
        //Debug.Log("Spawning Balloon");
}

