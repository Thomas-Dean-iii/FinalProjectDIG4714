using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    //public Transform player;

    [SerializeField] private float timer = 5;
    float delay;
    private float bulletTime;

    public GameObject enemyBullet;
    public Transform spawnPoint;
    public float enemySpeed;
    bool CanShoot;

    public void Start()
    {

    }

    private void Update()
    {
        FacePlayer();

        if (CanShoot == true)
        {
            ShootAtPlayer();
            FirstShotDelay();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Detected Firing");
            CanShoot = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Out of Range");
            CanShoot = false;
        }
    }

    public void FirstShotDelay()
    {
        delay -= Time.deltaTime;
        delay = 2;
    }

    private void FacePlayer()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            Vector3 direction = GameObject.FindWithTag("Player").transform.position - transform.position;
            direction.y = 0f; // Ignore vertical (y-axis) difference
            if (direction.magnitude > 0.1f)
            {
                Quaternion rotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10f);
            }
        }
    }

    void ShootAtPlayer()
    {
        bulletTime -= Time.deltaTime; //decrease bullet time

        if (bulletTime > 0 + delay)
        {
            return;
        }

        bulletTime = timer; //bullets lifetime

        GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject; //spawning the projectile
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * enemySpeed); //shooting the projectile
        Destroy(bulletObj, 5f);
    }
}