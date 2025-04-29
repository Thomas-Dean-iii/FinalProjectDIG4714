using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CakeScriptableObject", menuName = "Cake")]
public class CakeAbility : Ability
{
    public GameObject myCake1;
    public GameObject myCake2;
    public PlayerController target;

    public override void Activate(int level)
    {

        if (level == 1)
        {
            target = FindObjectOfType<PlayerController>();
            GameObject cake = Instantiate(myCake1, target.transform.position + new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        }
        else if (level == 2)
        {
            target = FindObjectOfType<PlayerController>();
            GameObject cake1 = Instantiate(myCake1, target.transform.position + new Vector3(1, 0, 0), Quaternion.identity) as GameObject;
            GameObject cake2 = Instantiate(myCake1, target.transform.position + new Vector3(-1, 0, 0), Quaternion.identity) as GameObject;
        }
        else if (level == 3)
        {
            target = FindObjectOfType<PlayerController>();
            GameObject cake1 = Instantiate(myCake2, target.transform.position + new Vector3(1, 0, 0), Quaternion.identity) as GameObject;
            GameObject cake2 = Instantiate(myCake2, target.transform.position + new Vector3(-1, 0, 0), Quaternion.identity) as GameObject;
        }
        else
        {
            return;
        }
    }
}