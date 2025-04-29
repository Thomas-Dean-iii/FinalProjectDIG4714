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

    public GameObject rButton4;
    public GameObject rButton5;
    public GameObject rButton6; 
    
    
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

    void Start()
    {
        Rereference();
    }

    private IEnumerator WaitForSceneLoad()
    {
        SceneManager.LoadScene("SampleScene");

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

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene loaded: " + scene.name);

        // Re-reference your buttons here after the scene loads
        Rereference();
    }
    
    void Update()
    {
         SceneManager.sceneLoaded += OnSceneLoaded;
        //LoadCharacterScene();
    }

    public void Rereference()
    {
        rButton4 = GameObject.Find("Clown");
        rButton5 = GameObject.Find("Princess");
        rButton6 = GameObject.Find("Magician");

        // Reassign the buttons to unlockButtons array (assuming it's sized properly)
        if (buttons == null || buttons.Length < 3)
        {
            buttons = new StoreButton[3]; // Ensure enough space
        }

        if (rButton4 != null) buttons[0] = rButton4.GetComponent<StoreButton>();
        if (rButton5 != null) buttons[1] = rButton5.GetComponent<StoreButton>();
        if (rButton6 != null) buttons[2] = rButton6.GetComponent<StoreButton>();

    }
}
