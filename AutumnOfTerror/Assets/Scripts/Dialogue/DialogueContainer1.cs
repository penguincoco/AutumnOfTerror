using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogueContainer1 : MonoBehaviour
{
    public KeyAndDialogueList keyAndDialogueList;
    Dictionary<string, KeyAndDialogue> dialogue;


    public TextAsset currentJSONFile;
    public TextAsset act1JSONFile;
    public TextAsset act2JSONFile;
    public TextAsset act3JSONFile;


    public string currentObject;
    public int currentStage;
    public bool inRange;

    public static Func<int> getCurrentAct;

    public TextMesh textObj;

    public Inventory inventory;

    public Transform playerTransform;
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
        currentStage = (int)getCurrentAct?.Invoke();
        //currentObject = Inventory.Instance.GetEquippedObject();
        if (inventory && inventory.equippedObj != null)
        {
            currentObject = inventory.equippedObj;
        }

        if (currentStage == 1)
        {
            currentJSONFile = act1JSONFile;
        }
        if (currentStage == 2)
        {
            currentJSONFile = act2JSONFile;
        }
        if (currentStage == 3)
        {
            currentJSONFile = act3JSONFile;
        }

        if (inRange)
        {
            InRange();
        }

        if (Input.GetKeyDown(KeyCode.E) && inRange == true)
        {
            Debug.Log("E");
            if (dialogue.ContainsKey(currentObject))
            {
                print(dialogue[currentObject].dialogue);
                textObj.text = dialogue[currentObject].dialogue;
            }
        }

        InventorySelect();
    }

    void InRange()
    {
        transform.LookAt(playerTransform);
    }

    void InventorySelect()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            textObj.text = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = false;
            textObj.text = null;
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
