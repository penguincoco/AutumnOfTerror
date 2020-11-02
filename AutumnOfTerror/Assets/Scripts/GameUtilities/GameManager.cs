using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// <summary> 
// Game manager is used specifically for managing changing scenes. All external GameObjects just call GameManager.Instance.LoadScene(sceneToLoad). GameManager will take care of the rest!
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private SceneChanger sceneChanger;
    private TimeManager timeManager;
    private NPCManager npcManager;
    private StartGame startGame;

    private int InteractedWithNPCs;

    public bool debugFeatures;
    public string sceneToLoad;                          //NUKE THESE CHANGES BEFORE COMMITTING. THIS WILL CAUSE A MERGE CONFLICT

    void Awake()
    {
        //singleton pattern
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }

    void Start()
    {
        sceneChanger = this.gameObject.GetComponent<SceneChanger>();
        timeManager = this.gameObject.GetComponent<TimeManager>();
        npcManager = this.gameObject.GetComponent<NPCManager>();
        //startGame = this.gameObject.GetComponent<StartGame>();

        if (!debugFeatures)
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        //sceneChanger.LoadScene("Pub");    //restore this
        sceneChanger.LoadScene(sceneToLoad);            //NUKE THESE CHANGES BEFORE COMMITTING. THIS WILL CAUSE A MERGE CONFLICT
    }

    //THIS METHOD WILL BE CALLED BY ALL OTHER OBJECTS IN THE SCENE.
    //MainStreet, Pub, Docks, Neighbourhood, PoliceStation
    public void LoadScene(string sceneToLoad)
    {
        sceneChanger.LoadScene(sceneToLoad);
       
        Inventory.Instance.CloseUI();       //close UI if it is open

        if (InteractedWithNPCs >= 1)
        {
            SetTime();
            InteractedWithNPCs = 0;         //reset because this only persists per scene. Travelling between scenes only impacts time if you've spoken to at least one NPC. 
        }
    }

    //this should be private eventually, public right now just for debugging and testing purposes, yo 
    public void SetTime()
    {
        timeManager.SetTime();
    }

    public void GetDate()
    {
        timeManager.GetDate();
    }

    public void Encountered(string name)
    {
        npcManager.Encountered(name);
    }

    public void NPCEncounterCounter()
    {
        InteractedWithNPCs++;
    }
}
