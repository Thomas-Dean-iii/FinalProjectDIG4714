using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRateManager : MonoBehaviour
{
    [System.Serializable]

    public class Drops 
    {
        public string name;
        public GameObject itemPrefab;
        public float dropRate;
    }
    public List<Drops> drops;

    void OnDestroy()
    {
        float randomNumer = Random.Range(0f, 100f);
        List<Drops> possibleDrops = new List<Drops>();


        foreach (Drops rate in drops)
        {
           if(randomNumer <= rate.dropRate)
           {
             possibleDrops.Add(rate);
           } 
        }
        //Check if there are possible drops
        if(possibleDrops.Count > 0)
        {
            Drops drops = possibleDrops[UnityEngine.Random.Range(0, possibleDrops.Count)];
            Instantiate(drops.itemPrefab, transform.position, Quaternion.identity);
        }
    }
}
