using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeExplosion : MonoBehaviour
{
    public float detonationTime = 3f;
    // Update is called once per frame
    void Update()
    {
        if (detonationTime > 0)
        {
            detonationTime -= Time.deltaTime;
        }
        else
        {
            gameObject.tag = "Projectile";
        }
    }
}
