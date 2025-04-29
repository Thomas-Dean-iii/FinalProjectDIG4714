using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CakeExplosion : MonoBehaviour
{
    public float detonationTime = 3f;
    public GameObject Confetti1;
    public GameObject Confetti2;
    public MeshRenderer CakeMesh;
    private void Start()
    {
        CakeMesh = GetComponent<MeshRenderer>();
    }
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
            CakeMesh.enabled = false;
            GameObject confetti1exp = Instantiate(Confetti1, gameObject.transform.position + new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            GameObject confetti2exp = Instantiate(Confetti2, gameObject.transform.position + new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            Destroy(confetti1exp, .5f);
            Destroy(confetti2exp, .5f);
            Destroy(gameObject, .5f);
        }
    }
}