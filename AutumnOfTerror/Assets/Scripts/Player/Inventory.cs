using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private static Inventory _instance;
    public static Inventory Instance { get { return _instance; } }

    public InventoryObject inventory;

    public Canvas inventoryCanvas;

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
        inventoryCanvas.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ToggleInventoryShow();
        }
    }

    void ToggleInventoryShow()
    {
        if (!inventoryCanvas.enabled)
        {
            //When the inventory is enabled, freeze player movement, camera movement and make cursor visible 
            this.gameObject.transform.GetChild(0).GetComponent<MouseLook>().enabled = false;
            this.gameObject.GetComponent<PlayerMovement>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            inventoryCanvas.enabled = true;
        }
        else
        {
            this.gameObject.transform.GetChild(0).GetComponent<MouseLook>().enabled = true;
            this.gameObject.GetComponent<PlayerMovement>().enabled = true;
            inventoryCanvas.enabled = false;
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

    public string GetEquippedObject()
    {
        return equippedObj;
    }
}
