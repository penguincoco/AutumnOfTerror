using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New NPC", menuName = "NPC System/Default NPC")]

/// <summary>
/// NPCs are scriptable objects. All information for an NPC (like name, sex, address, etc...) will be stored in a text file. Awake() will parse the text file and populate the information for the given NPC
/// </summary>
public class NPCObject : ScriptableObject
{
    public string[] NPCData;
    public TextAsset NPCFile;

    public string name;
    public string sex;
    public string occupation;
    public string address;

    public List<string> suspectEvidence;

    public virtual void OnEnable()
    {
        Parse();
        SetDefaultFields();

        //Set suspect evidence data if there is any
        if (NPCData.Length > 4)
        {
            Debug.Log("Setting suspect evidence");
            SetSuspectFields();
        }
    }


    private void Parse()
    {
        string text = NPCFile.text;

        NPCData = text.Split('\n');

        foreach (string line in NPCData)
        {
            Debug.Log(line);
        }
    }

    public void SetDefaultFields()
    {
        name = NPCData[0];
        sex = NPCData[1];
        address = NPCData[2];
        occupation = NPCData[3];
    }

    public void SetSuspectFields()
    {
        for (int i = 4; i < NPCData.Length; i++)
        {
            suspectEvidence.Add(NPCData[i]);
        }
    }
}
