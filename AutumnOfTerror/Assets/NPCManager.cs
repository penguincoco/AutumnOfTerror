using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// <summary> NPC manager will be in change of tracking specifically WHO you have spoken to. NPC manager reports straight to GameManager, which only cares about HOW MANY NPCs you have spoken to.
public class NPCManager : MonoBehaviour
{
    public Dictionary<string, GameObject> NPCDict = new Dictionary<string, GameObject>();

    public List<string> notEncountered = new List<string>();         //all NPCs start not encountered, duh lol
    public List<string> encountered = new List<string>();
    
    public GameObject TOCObjs;   //drag this in from the inspector. This GameObject is the parent of all the Buttons for the Table of Contents in the notebook (first page when you open the notebook)

    void Start()
    {
        GenerateDictionary();
        foreach(Transform child in TOCObjs.transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    void GenerateDictionary()
    {
        Debug.Log("Generating Dictionary");
        foreach (Transform child in TOCObjs.transform)
        {
            Debug.Log(child.gameObject.name);       //Note on usage: All NPC buttons should be formatted as so: "EvieBrown", NO SPACE BETWEEN FIRST AND SURNAMES.
            NPCDict.Add(child.gameObject.name, child.gameObject);
        }
    }

    public void Encountered(string name)
    {
        //if an NPC's name is not on the encountered list, Update the TOC to show that NPCs button
        if (!encountered.Contains(name))
        {
            Debug.Log("Youve encountered a new NPC! " + name);
            encountered.Add(name);
            UpdateTOC(name);
            GameManager.Instance.NPCEncounterCounter();
        }
    }

    //if was just encountered for the first time, show their button (meaning you can view their profile page in the notebook)
    public void UpdateTOC(string name)
    {
        GameObject toActivate = NPCDict[name];
        toActivate.gameObject.SetActive(true);
    }
}
