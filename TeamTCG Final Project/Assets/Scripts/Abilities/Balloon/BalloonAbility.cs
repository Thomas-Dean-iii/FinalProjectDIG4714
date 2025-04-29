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
    private GameObject balloon1;
    private GameObject balloon2;
    private GameObject balloon3;

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
            balloon1 = Instantiate(myBalloon1, target.transform.position + new Vector3(0, 1, 3), Quaternion.identity) as GameObject;
            balloon2 = Instantiate(myBalloon2, target.transform.position + new Vector3(0, 1, -3), Quaternion.identity) as GameObject;
            balloon1.transform.SetParent(target.transform);
            balloon2.transform.SetParent(target.transform);
        }
        else if (level == 3)
        {
            balloon1 = Instantiate(myBalloon1, target.transform.position + new Vector3(0, 1, 3.6f), Quaternion.identity) as GameObject;
            balloon2 = Instantiate(myBalloon2, target.transform.position + new Vector3(-3, 1, -2), Quaternion.identity) as GameObject;
            balloon3 = Instantiate(myBalloon3, target.transform.position + new Vector3(3, 1, -2), Quaternion.identity) as GameObject;
            balloon1.transform.SetParent(target.transform);
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
        if (level == 2)
        {
            Destroy(balloon1);
            Destroy(balloon2);
        }
        if (level == 3)
        {
            Destroy(balloon1);
            Destroy(balloon2);
            Destroy(balloon3);
        }
    }
        //Debug.Log("Spawning Balloon");
}

