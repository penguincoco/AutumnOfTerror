using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public NPCObject NPCObj; 

    void OnApplicationQuit()
    {
        NPCObj.suspectEvidence.Clear();
    }
}
