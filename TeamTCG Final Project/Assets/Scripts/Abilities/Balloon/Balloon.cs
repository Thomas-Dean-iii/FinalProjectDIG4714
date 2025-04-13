using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BalloonScriptableObject",menuName = "Balloon")]
public class BalloonAbility : Ability
{
    public float balooonVelocity;
    public GameObject balloon;
    public GameObject target;

    public override void Activate(GameObject parent)
    {
        Instantiate(balloon);
        balloon.transform.SetParent(target.transform);
        
    }
}
