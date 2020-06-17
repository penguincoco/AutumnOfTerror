using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStates : MonoBehaviour
{
    [SerializeField] string currentState = "idle";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == "idle")
        {
            Idle();
        }
    }

    void Idle()
    {

    }
}
