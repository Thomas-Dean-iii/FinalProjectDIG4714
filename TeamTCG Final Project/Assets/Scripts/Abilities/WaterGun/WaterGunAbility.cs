using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "WaterGunScriptableObject", menuName = "WaterGun")]
public class WaterGunAbility : Ability
{
    public GameObject myWaterGun;
    public PlayerController target;
    public float firingSpeed;

    public override void Activate()
    {
        target = FindObjectOfType<PlayerController>();
        GameObject watergun = Instantiate(myWaterGun, target.transform.position + new Vector3(-1, 0, 0), Quaternion.identity) as GameObject;
        watergun.transform.SetParent(target.transform);
        //Debug.Log("Spawning Water Gun");
    }
}
