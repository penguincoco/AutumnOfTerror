using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventControllerReceiver : MonoBehaviour
{
    public MasterEventTracker masterEventTracker;

    private void OnEnable()
    {
        EventControllerCaller.Act0 += Act0;
        DialogueContainer.getCurrentStage += ReturnData;
    }

    private void OnDisable()
    {
        EventControllerCaller.Act0 -= Act0;
        DialogueContainer.getCurrentStage -= ReturnData;
    }

    void Act0()
    {
        masterEventTracker.currentAct = 0;
    }

    void ActIncrement()
    {
        masterEventTracker.currentActEvent += 1;
    }

    void EventIncrement()
    {
        masterEventTracker.currentActEvent += 1;
    }

    void ResetEventCounter()
    {
        masterEventTracker.currentActEvent = 0;
    }

    int ReturnData()
    {
        return masterEventTracker.currentAct;
    }
}
