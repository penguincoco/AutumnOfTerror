using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New NPC", menuName = "NPC System/Suspect NPC")]

public class NPCSuspectObject : NPCObject
{
    public string[] suspectObjects = new string[1];
    public override void OnEnable()
    {
        base.OnEnable();
        Debug.Log("Awake from Suspect Obj");
        //suspectObjects[0] = "some piece of evidence";
    }
}
