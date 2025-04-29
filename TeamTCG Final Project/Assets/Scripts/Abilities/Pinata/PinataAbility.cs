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

        if (level == 1)
        {
            target = FindObjectOfType<PlayerController>();
            GameObject pinata = Instantiate(myPinata1, target.transform.position + new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        }
        else if (level == 2)
        {
            target = FindObjectOfType<PlayerController>();
            GameObject pinata1 = Instantiate(myPinata1, target.transform.position + new Vector3(1, 0, 0), Quaternion.identity) as GameObject;
            GameObject pinata2 = Instantiate(myPinata1, target.transform.position + new Vector3(-1, 0, 0), Quaternion.identity) as GameObject;
        }
        else if (level == 3)
        {
            target = FindObjectOfType<PlayerController>();
            GameObject pinata1 = Instantiate(myPinata2, target.transform.position + new Vector3(1, 0, 0), Quaternion.identity) as GameObject;
            GameObject pinata2 = Instantiate(myPinata2, target.transform.position + new Vector3(-1, 0, 0), Quaternion.identity) as GameObject;
        }
        else
        {
            return;
        }
    }
}
