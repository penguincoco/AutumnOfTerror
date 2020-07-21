using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Notebook : MonoBehaviour
{
    public List<NPCObject> NPCs;
    public TextMeshProUGUI NPCData;
    public int counter = 0;

    void Update()
    {
        ShowTableOfContents();
        ShowNPCData();
    }

    void ShowTableOfContents()
    {

    }

    void ShowNPCData()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            NPCData.text = NPCs[counter].name;
            counter++;
        }
    }
}
