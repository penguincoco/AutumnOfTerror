using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCPage : MonoBehaviour
{
    public NPCObject NPC;

    public TextMeshProUGUI name;
    public TextMeshProUGUI sex;
    public TextMeshProUGUI occupation;
    public TextMeshProUGUI address;

    public GameObject TOC;

    public GameObject components;

    void Start()
    {
        SetData();
    }

    private void SetData()
    {
        name.text = NPC.name;
        sex.text = NPC.sex;
        occupation.text = NPC.occupation;
        address.text = NPC.address;
    }

    public void ShowData()
    {
        components.SetActive(true);
        TOC.SetActive(false);
    }

    public void ReturnToTOC()
    {
        //disable the current NPC page
        components.SetActive(false);
        TOC.SetActive(true);
    }

    public void HideData()
    {
        components.SetActive(false);
    }
}
