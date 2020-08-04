using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//VARIOUS DEBUGGING FEATURES SCRIPT. DELETE THIS IN THE FUTURE. 
public class RandomTest : MonoBehaviour
{ // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            GameManager.Instance.SetTime();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameManager.Instance.Encountered("EvieBrown");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameManager.Instance.Encountered("TomPerry");
        }
    }
}
