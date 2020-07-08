using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueContainer : MonoBehaviour
{
    private ObjectTimeAndDialogueList objectTimeAndDialogueList;
    Dictionary<string, ObjectTimeAndDialogue> dialogue;
    // Start is called before the first frame update
    void Start()
    {
        print(JsonUtility.ToJson(objectTimeAndDialogueList).ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class ObjectTimeAndDialogue
{
    public string objectName;
    public string time;
    public string dialogue;
}

[System.Serializable]
public class ObjectTimeAndDialogueList
{
    public List<ObjectTimeAndDialogue> objectTimeAndDialogueList;
}
