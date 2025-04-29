using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "WaterGunScriptableObject", menuName = "WaterGun")]
public class WaterGunAbility : Ability
{
    public GameObject myWaterGun1;
    public GameObject myWaterGun2;
    public GameObject myWaterGun3;
    public PlayerController target;

    public override void Activate(int level)
    {
        target = FindObjectOfType<PlayerController>();
        if (level == 1)
        {
            GameObject watergun = Instantiate(myWaterGun1, target.transform.position + new Vector3(0, 1, 2), Quaternion.identity) as GameObject;
            watergun.transform.SetParent(target.transform);
        }
        else if (level == 2)
        {
            GameObject watergun = Instantiate(myWaterGun2, target.transform.position + new Vector3(0, 1, 0), Quaternion.identity) as GameObject;
            watergun.transform.SetParent(target.transform);
        }
        else if (level == 3)
        {
            GameObject watergun = Instantiate(myWaterGun3, target.transform.position + new Vector3(0, 1, 0), Quaternion.identity) as GameObject;
            watergun.transform.SetParent(target.transform);
        }
        else
        {
            return;
        }
        //Debug.Log("Spawning Water Gun");
    }
}
