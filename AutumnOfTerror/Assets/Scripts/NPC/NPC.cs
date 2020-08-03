using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public NPCObject NPCObj;

    public bool spokenWith = false;

    void OnApplicationQuit()
    {
        NPCObj.suspectEvidence.Clear();
    }

    //call this function when an NPC has been spoken to
    public void SpokenTo()
    {
        if (!spokenWith)        //the same NPC can be spoken to multiple times, but only when they were spoken the first time does it really matter for the counter.
        {
            spokenWith = true;
            GameManager.Instance.NPCEncounterCounter();
        }
    }
}
