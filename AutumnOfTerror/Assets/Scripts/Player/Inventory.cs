using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private static Inventory _instance;
    public static Inventory Instance { get { return _instance; } }

    public InventoryObject inventory;

    public Canvas inventoryCanvas;
    public Canvas notebookCanvas;

    private bool UIOpen = false;

    public string equippedObj;

    void Awake()
    {
        //singleton pattern
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }

    void Start()
    {
        inventoryCanvas.enabled = UIOpen;
        notebookCanvas.enabled = UIOpen;
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.P) && !notebookCanvas.enabled)
        //{
        //    ToggleInventoryShow();
        //}
        ////    if (Input.GetKeyDown(KeyCode.P))
        ////    {
        ////        ToggleInventoryShow();
        ////    }

        //if (UIOpen)
        //{
        //    ToggleNotebook();
        //}

        OpenCloseUI();
    }

    void OpenCloseUI()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (UIOpen)
            {
                UIOpen = false;
                inventoryCanvas.enabled = UIOpen;
                notebookCanvas.enabled = UIOpen;
                CloseUI();
            }
            else    //opening the UI always leads to inventory first
            {
                UIOpen = true;
                inventoryCanvas.enabled = UIOpen;
                OpenUI();
            }
        }

        if (UIOpen)
        {
            UIToggle();
        }
    }

    void OpenUI()
    {
        this.gameObject.transform.GetChild(0).GetComponent<MouseLook>().enabled = false;
        this.gameObject.GetComponent<PlayerMovement>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        inventoryCanvas.enabled = true;
    }

    void CloseUI()
    {
        this.gameObject.transform.GetChild(0).GetComponent<MouseLook>().enabled = true;
        this.gameObject.GetComponent<PlayerMovement>().enabled = true;
        inventoryCanvas.enabled = false;
        UIOpen = false;
    }

    void UIToggle()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && inventoryCanvas.enabled)
        {
            inventoryCanvas.enabled = false;
            notebookCanvas.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && notebookCanvas.enabled)
        {
            inventoryCanvas.enabled = true;
            notebookCanvas.enabled = false;
        }
    }

    public void OnTriggerEnter(Collider otherObj)
    {
        Item item = otherObj.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.item);
            Destroy(otherObj.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        inventory.container.Clear();
    }

    public void SetEquippedObject(string objName)
    {
        equippedObj = objName;
    }

    //Call this with Inventory.Instance.GetEquippedObject()
    public string GetEquippedObject()
    {
        return equippedObj;
    }
}
