using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogueContainer1 : MonoBehaviour
{
    public KeyAndDialogueList keyAndDialogueList;
    Dictionary<string, KeyAndDialogue> dialogue;


    public TextAsset currentJSONFile;


    public string currentObject;
    public int currentStage;
    public bool InRange;

    public static Func<int> getCurrentStage;

    public TextMesh textObj;

    public Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        //print(JsonUtility.ToJson(keyAndDialogueList).ToString());

        keyAndDialogueList = JsonUtility.FromJson<KeyAndDialogueList>(currentJSONFile.ToString());
        dialogue = new Dictionary<string, KeyAndDialogue>();
        foreach (KeyAndDialogue _k in keyAndDialogueList.keyAndDialogueList)
        {
            dialogue.Add(_k.objectName, _k);
        }

        inventory = FindObjectOfType<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        //currentStage = (int)getCurrentStage?.Invoke();
        //currentObject = Inventory.Instance.GetEquippedObject();
        currentObject = inventory.equippedObj;
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E");
            if (dialogue.ContainsKey(currentObject))
            {
                print(dialogue[currentObject].dialogue);
                textObj.text = dialogue[currentObject].dialogue;
            }
        }
    }
}

[System.Serializable]
public class KeyAndDialogue
{
    public string objectName;
    public string dialogue;
}

[System.Serializable]
public class KeyAndDialogueList
{
    public List<KeyAndDialogue> keyAndDialogueList;
}
