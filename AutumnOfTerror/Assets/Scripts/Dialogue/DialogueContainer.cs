using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogueContainer : MonoBehaviour
{
    private ObjectTimeAndDialogueList objectTimeAndDialogue;
    Dictionary<string, ObjectTimeAndDialogue> dialogue;

    public TextAsset trialJSon;

    public string currentObject;
    public int currentStage;
    public bool InRange;

    public static Func<int> getCurrentStage;
    // Start is called before the first frame update
    void Start()
    {
        //print(JsonUtility.ToJson(objectTimeAndDialogue).ToString());
        objectTimeAndDialogue = JsonUtility.FromJson<ObjectTimeAndDialogueList>(trialJSon.ToString());
        foreach (ObjectTimeAndDialogue ob in objectTimeAndDialogue.objectTimeAndDialogueList)
        {
            dialogue.Add(ob.objectName, ob);
            //dialogue.Add(ob.time, ob);
        }

        //for(int i = 0; i < objectTimeAndDialogue.)
    }

    // Update is called once per frame
    void Update()
    {
        currentStage = (int)getCurrentStage?.Invoke();
        currentObject = Inventory.Instance.GetEquippedObject();
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (dialogue.ContainsKey(currentStage.ToString()) && dialogue.ContainsKey(currentObject))
            {
                print(dialogue[currentObject].dialogue);
            }
        }
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
