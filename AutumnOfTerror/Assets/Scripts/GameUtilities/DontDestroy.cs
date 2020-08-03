using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public Canvas thisCanvas;
    void Awake()
    {
        if (thisCanvas != null)
            DontDestroyOnLoad(thisCanvas);
        else 
            DontDestroyOnLoad(this.gameObject);
    }
}
