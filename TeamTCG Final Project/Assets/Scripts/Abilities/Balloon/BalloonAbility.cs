using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BalloonScriptableObject",menuName = "Balloon")]
public class BalloonAbility : Ability
{
    public float balooonVelocity;
    public GameObject myBalloon;
    public GameObject target;

    public override void Activate(GameObject parent)
    {
        GameObject balloon = Instantiate(myBalloon, new Vector3 (0, 0, 10), Quaternion.identity) as GameObject;
        balloon.transform.SetParent(target.transform);
    }
}
