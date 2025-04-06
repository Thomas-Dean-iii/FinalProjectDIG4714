using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollecter : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.TryGetComponent(out ICollectible collectible))
        {
            collectible.Collect();
        }
    }
}
