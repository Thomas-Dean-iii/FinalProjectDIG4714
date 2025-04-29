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
    private GameObject waterGun;  

    public override void Activate(int level)
    {
        target = FindObjectOfType<PlayerController>();
        if (level == 1)
        {
            waterGun = Instantiate(myWaterGun1, target.transform.position + new Vector3(0, 1, 2), Quaternion.identity) as GameObject;
            waterGun.transform.SetParent(target.transform);
        }
        else if (level == 2)
        {
            waterGun = Instantiate(myWaterGun2, target.transform.position + new Vector3(0, 1, 0), Quaternion.identity) as GameObject;
            waterGun.transform.SetParent(target.transform);
        }
        else if (level == 3)
        {
            waterGun = Instantiate(myWaterGun3, target.transform.position + new Vector3(0, 1, 0), Quaternion.identity) as GameObject;
            waterGun.transform.SetParent(target.transform);
        }
        else
        {
            return;
        }
        //Debug.Log("Spawning Water Gun");
    }

    public override void Deactivate(int level)
    {
        Destroy(waterGun);
    }
}
