using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Notebook : MonoBehaviour
{
    public List<NPCObject> NPCs;
    public TextMeshProUGUI name;
    public TextMeshProUGUI sex;
    public TextMeshProUGUI occupation;
    public TextMeshProUGUI address;
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
            name.text = NPCs[counter].name;
            sex.text = NPCs[counter].sex;
            occupation.text = NPCs[counter].occupation;
            address.text = NPCs[counter].address;

            counter++;
        }
    }

    private void OnApplicationQuit()
    {
        foreach (NPCObject npc in NPCs)
        {
            npc.suspectEvidence.Clear();
        }
    }
}
