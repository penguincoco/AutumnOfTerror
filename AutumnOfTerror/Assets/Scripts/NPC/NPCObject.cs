using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New NPC", menuName = "NPC System/Default NPC")]

/// <summary>
/// NPCs are scriptable objects. All information for an NPC (like name, sex, address, etc...) will be stored in a text file. Awake() will parse the text file and populate the information for the given NPC
/// </summary>
public class NPCObject : ScriptableObject
{
    public string name;
    public string sex;
    public string address;
    public string occupation;

    // public List<string> dialogue;
    public string[] dialogue;
    public TextAsset NPCFile;

    void Awake()
    {
        Parse();
        name = dialogue[0];
        sex = dialogue[1];
        occupation = dialogue[2];
    }

    //Note on setting up the file to parse: 
    //ShowDialogue() gets called every time we exit a window in the rhythm game, so if you want a specific line to stay up
    //for multiple notes (that the player hits, not notes in the song), then put an empty, new line between spoken lines!! 
    private void Parse()
    {
        string text = NPCFile.text;

        dialogue = text.Split('\n');

        foreach (string line in dialogue)
        {
            Debug.Log(line);
        }
    }
}
