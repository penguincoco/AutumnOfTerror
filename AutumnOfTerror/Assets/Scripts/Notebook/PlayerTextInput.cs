using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerTextInput : MonoBehaviour
{
    public string input;
    public GameObject inputField;
    public GameObject textDisplay;

    void GetInput()
    {
        input = inputField.GetComponent<Text>().text;
        textDisplay.GetComponent<Text>().text = input;
    }
}
