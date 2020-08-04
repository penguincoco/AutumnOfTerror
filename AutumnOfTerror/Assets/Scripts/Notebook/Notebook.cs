using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq.Expressions;

public class Notebook : MonoBehaviour
{
    public List<NPCObject> NPCs;
    public int counter = 0;

    public GameObject NPCButtons;

    void ShowTableOfContents()
    {
        NPCButtons.SetActive(true);
    }

    private void OnApplicationQuit()
    {
        foreach (NPCObject npc in NPCs)
        {
            npc.suspectEvidence.Clear();
        }
    }
}
