using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "New Game Utility", menuName = "Game Utilities/SceneChanger")]

//how to set up the level load: 
//0 - Main street
//1 - Police station
//2 - Pub
//3 - Neighbourhood
//4 - Docks 

public class SceneChanger : MonoBehaviour
{
    private static SceneChanger _instance;
    public static SceneChanger Instance { get { return _instance; } }

    private float waitTime = 1f;

    //Note: System.Action MUST return VOID. 
    public Dictionary<string, System.Action> sceneDict = new Dictionary<string, System.Action>();

    [SerializeField]private string currentScene;

    public GameObject fadeImg;

    //void Awake()
    //{
    //    //singleton pattern
    //    if (_instance != null && _instance != this)
    //        Destroy(this.gameObject);
    //    else
    //        _instance = this;
    //}

    void Awake()
    {
        sceneDict.Add("MainStreet", LoadMainStreet);
        sceneDict.Add("PoliceStation", LoadPoliceStation);
        sceneDict.Add("Pub", LoadPub);
        sceneDict.Add("Neighbourhood", LoadNeighbourhood);
        sceneDict.Add("Docks", LoadDocks);
    }

    public void LoadScene(string sceneToLoad)
    {
        sceneDict[sceneToLoad]();
    }

    //different functions for teleporting to each different scene. 
    public void LoadMainStreet()
    {
        StartCoroutine(Load(1, waitTime));
    }

    public void LoadPoliceStation()
    {
        //SceneManager.LoadScene(1);
        StartCoroutine(Load(2, waitTime));
    }

    public void LoadPub()
    {
        //SceneManager.LoadScene(2);
        StartCoroutine(Load(3, waitTime));
    }

    public void LoadNeighbourhood()
    {
        //SceneManager.LoadScene(3);
        StartCoroutine(Load(4, waitTime));
    }

    public void LoadDocks()
    {
        //SceneManager.LoadScene(4);
        StartCoroutine(Load(5, waitTime));
    }

    //kind of spaghetti, but all Load methods are overloaded, because functions with a return type cannot be stored in a dictionary (at least not to my pea brained knowledge lmao) 
    //This HAS to be a coroutine because FindWithTag does not work the immediate second after loading a scene. 
    private IEnumerator Load(int sceneIndex, float waitTime)
    {
        StartCoroutine(fadeImg.GetComponent<FadeObj>().Fade(true));

        yield return new WaitForSeconds(2.5f);

        //transition to another scene
        string currSceneName = SceneManager.GetActiveScene().name;

        Debug.Log("Currently in: " + currSceneName);

        SceneManager.LoadScene(sceneIndex);

        yield return new WaitForSeconds(waitTime);

        //some scenes have multiple entry points (like the main street, oof)
        GameObject[] teleportObjs = GameObject.FindGameObjectsWithTag("Player Teleport Spot");

        Vector3 teleportSpot = new Vector3(0f, 0f, 0f);
        Vector3 newRotation = new Vector3(0f, 0f, 0f);

        //based on the scene we were just in, select the start position for the scene the player is entering
        //loop through all the names of the teleportObjs until we find one that contains the name of the previous scene
        foreach (GameObject teleportObj in teleportObjs)
        {
            Debug.Log(teleportObj.name);
            if (teleportObj.name.Contains(currSceneName))
            {
                teleportSpot = teleportObj.transform.position;
                Debug.Log("jumping to: " + teleportSpot);
                newRotation = teleportObj.transform.rotation.eulerAngles;
                break;
            }
        }

        PlayerMovement.Instance.SetPosition(teleportSpot, newRotation);

        //after everything has been loaded in, fade the scene in
        StartCoroutine(fadeImg.GetComponent<FadeObj>().Fade(false));
    }
}
