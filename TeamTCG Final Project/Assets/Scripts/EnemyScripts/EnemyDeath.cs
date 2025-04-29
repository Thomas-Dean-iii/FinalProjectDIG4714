using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
            //Physics.IgnoreCollision(collision, GetComponent<SphereCollider>());
            Debug.Log("Enemy is killed");
        }
    }
}
