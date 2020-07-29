using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    void Awake()
    {
        //singleton pattern
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Calling");
            LoadPub();
        }
    }

    public void LoadMainStreet()
    {
        Debug.Log("Changing");
        SceneManager.LoadScene(0);
    }

    public void LoadPoliceStation()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadPub()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadNeighbourhood()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadDocks()
    {
        SceneManager.LoadScene(3);
    }
}
