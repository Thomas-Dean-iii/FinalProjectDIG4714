using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PinataScriptableObject", menuName = "Pinata")]
public class PinataAbility : Ability
{
    public GameObject myPinata1;
    public GameObject myPinata2;
    public PlayerController target;

    public override void Activate(int level)
    {
        target = FindObjectOfType<PlayerController>();
        GameObject pinata = Instantiate(myPinata1, target.transform.position + new Vector3(3,0,0), Quaternion.identity) as GameObject;
    }
}
