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
    public float firingSpeed;

    public override void Activate(int level)
    {
        target = FindObjectOfType<PlayerController>();
        GameObject watergun = Instantiate(myWaterGun1, target.transform.position + new Vector3(0, 1, 2), Quaternion.identity) as GameObject;
        watergun.transform.SetParent(target.transform);
        //Debug.Log("Spawning Water Gun");
    }
}
