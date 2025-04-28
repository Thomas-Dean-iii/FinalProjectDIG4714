using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PinataScriptableObject", menuName = "Pinata")]
public class PinataAbility : Ability
{
    public GameObject myPinata;
    public PlayerController target;

    public override void Activate()
    {
        target = FindObjectOfType<PlayerController>();
        GameObject pinata = Instantiate(myPinata, target.transform.position + new Vector3(3,0,0), Quaternion.identity) as GameObject;
        pinata.transform.SetParent(target.transform);
    }
}
