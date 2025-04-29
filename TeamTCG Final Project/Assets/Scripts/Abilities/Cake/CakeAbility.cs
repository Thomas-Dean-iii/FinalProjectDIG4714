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
        target = FindObjectOfType<PlayerController>();
        if (level == 1)
        {
            GameObject cake = Instantiate(myCake1, target.transform.position + new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        }
        else if (level == 2)
        {
            GameObject cake1 = Instantiate(myCake1, target.transform.position + new Vector3(1.5f, 0, 0), Quaternion.identity) as GameObject;
            GameObject cake2 = Instantiate(myCake1, target.transform.position + new Vector3(-1.5f, 0, 0), Quaternion.identity) as GameObject;
        }
        else if (level == 3)
        {
            GameObject cake1 = Instantiate(myCake2, target.transform.position + new Vector3(2, 0, 0), Quaternion.identity) as GameObject;
            GameObject cake2 = Instantiate(myCake2, target.transform.position + new Vector3(-2, 0, 0), Quaternion.identity) as GameObject;
        }
        else
        {
            return;
        }
    }
}