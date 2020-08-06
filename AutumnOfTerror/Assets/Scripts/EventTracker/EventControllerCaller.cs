using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventControllerCaller : MonoBehaviour
{
    public int date;

    public static Action Act0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        date = TimeManager.Instance.GetDay();
    }

    void ActSetting()
    {
        if (date == 9)
        {
            Act0?.Invoke();
        }
    }
}
