using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//do not attach SceneChanger component, SceneChanger is a Singleton! 
public class BoundaryZone : MonoBehaviour
{
    public string boundaryName;
    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.name == "Player")
        {
            Teleport(boundaryName);
        }
    }

    void Teleport(string teleportTo)
    {
        SceneChanger.Instance.LoadScene(teleportTo);
    }
}
