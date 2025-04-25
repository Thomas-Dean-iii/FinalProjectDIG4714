using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentData : MonoBehaviour
{
    public static PersistentData instance {get; private set; }
    public int myCharacter;
    public StoreButton[] buttons;
    private GameObject spawnPoint;


    [Header("Selectable Characters")]
    public GameObject clown;
    public GameObject princess;
    public GameObject magician;
    
    
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void LoadCharacterScene()
    {
        foreach (StoreButton btn in buttons)
        {
            if(btn.isSelected)
            {
                StartCoroutine(WaitForSceneLoad());
                break;
            }
        }
        
    }

    private IEnumerator WaitForSceneLoad()
    {
        SceneManager.LoadScene("LevelDesign");

        yield return null;

        spawnPoint = GameObject.FindWithTag("SpawnPoint");
        ChunkManager chunk = FindObjectOfType<ChunkManager>();
        

        if (spawnPoint == null)
        {
            Debug.LogError("SpawnPoint not found in the scene!");
            yield break;
        }
            switch(myCharacter)
            {
                case 0:
                    GameObject temp1 = Instantiate(magician, spawnPoint.transform.position,spawnPoint.transform.rotation);
                    chunk.player = temp1.transform;
                    break;
                case 1:
                    GameObject temp2 = Instantiate(princess, spawnPoint.transform.position,spawnPoint.transform.rotation);
                    chunk.player = temp2.transform;
                    break;
                case 2: 
                    GameObject temp3 = Instantiate(clown, spawnPoint.transform.position,spawnPoint.transform.rotation);
                    chunk.player = temp3.transform;
                    break;
            }
    }
    
    void Update()
    {
        //LoadCharacterScene();
    }
}
